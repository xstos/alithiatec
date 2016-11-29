using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using A = AlithiaLib;
using System.IO;
namespace DeDupify {
	public partial class DeDupify : Form {
		public DeDupify() {
			InitializeComponent();
		}
		DataTable resultTable; Dictionary<string, DataGridViewRow> duplicates = new Dictionary<string, DataGridViewRow>();
		private void DeDupify_Load(object sender, EventArgs e) {
			Init();
		}
		void Init() {
			A.Errors.DealWithError = Err;
			if (DateTime.Now.Ticks - Properties.Settings.Default.lastUpdateCheck.Ticks > new TimeSpan(2, 0, 0, 0).Ticks) {
				Properties.Settings.Default.lastUpdateCheck = DateTime.Now;
				Properties.Settings.Default.Save();
				checkUpdates(true);
			}
			resultTable = createResults();
			dataGridView1.DataSource = resultTable;
			resultTable.TableCleared += new DataTableClearEventHandler(resultTable_TableCleared);
			new A.Forms.ColorGroupsBySortedColumn(dataGridView1, dataGridView1.Columns["checksum"]);
			new A.Forms.SecondarySortColumn(dataGridView1, dataGridView1.Columns["checksum"]);
			this.Text = String.Format("{0} {1} - {2}", Application.ProductName, Application.ProductVersion, Application.CompanyName);
			A.Shell.FileDragDropHandler fdh = new AlithiaLib.Shell.FileDragDropHandler(uiLbFolders);
			fdh.FilesDropped += new AlithiaLib.Shell.FileDragDropHandler.DragDropOccured(fdh_FilesDropped);
			uiLbFolders.DataSource = folders;
			dataGridView1.Columns["size"].DefaultCellStyle.Format = "n0";
			dataGridView1.Columns["size"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["checksum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			for (int i = 0; i < resultTable.Columns.Count; i++) {
				dataGridView1.Columns[i].HeaderText = resultTable.Columns[i].Caption;
			}
		}
		void resultTable_TableCleared(object sender, DataTableClearEventArgs e) {
			//throw new Exception("The method or operation is not implemented.");
		}
		void fdh_FilesDropped(string[] files) {
			for (int i = 0; i < files.Length; i++) {
				AddPath(files[i]);
			}
		}
		BindingList<A.IO.Path> folders = new BindingList<A.IO.Path>();
		private void uiBtnAddFolder_Click(object sender, EventArgs e) {
			AddPathViaDialog();
		}
		void AddPath(string path) {
			try {
				DirectoryInfo di = new DirectoryInfo(path);
				if (di.Exists) {
					A.IO.Path p = new AlithiaLib.IO.Path(di.FullName);
					if (!folders.Contains(p)) folders.Add(p);
				}
			} catch { }
		}
		void AddPathViaDialog() {
			uiFBD.Description = "Select a folder to check for duplicates.";
			uiFBD.ShowDialog();
			AddPath(uiFBD.SelectedPath);
		}
		private void uiBtnDelSelected_Click(object sender, EventArgs e) {
			A.Forms.RemoveSelectedListboxItems<A.IO.Path>(uiLbFolders, folders);
		}
		private void uiBtnCheckNow_Click(object sender, EventArgs e) {
			startHarvesting();
		}
		void startHarvesting() {
			if (!bw.IsBusy) {
				A.IO.DiskCache dc = new AlithiaLib.IO.DiskCache();
				dc.Recursive = uiChkAddSubFolders.Checked;
				dc.LoadComplete += new AlithiaLib.IO.DiskCache.LoadCompleteDelegate(dc_LoadComplete);
				StatusUpdate("File gathering started");
				for (int i = 0; i < folders.Count; i++) {
					dc.Load(folders[i]);
				}
			} else {
				bw.CancelAsync();
				pending = true;
			}
		}
		void RemoveUniqueEntries<TKey, TValue>(A.DictionaryList<TKey, TValue> list) {
			List<TKey> remove = new List<TKey>();
			foreach (TKey key in list.Keys) { //find all single size occurences
				if (list[key].Count == 1) remove.Add(key);
			}
			for (int i = 0; i < remove.Count; i++) { //take em out
				list.Remove(remove[i]);
			}
		}
		bool pending = false;
		void dc_LoadComplete(DirectoryInfo[] directories, FileInfo[] files) {
			StatusUpdate("File gathering complete");
			uiBtnCancel.Enabled = true;
			if (!bw.IsBusy) bw.RunWorkerAsync(new object[] { files, resultTable });
			else {
				bw.CancelAsync();
				pending = true;
			}
		}
		private void uiBtnClearFolders_Click(object sender, EventArgs e) {
			folders.Clear();
		}
		void Err(Exception ex) {
			StatusUpdate(ex.Message);
		}
		void StatusUpdate(string msg) {
			this.Invoke((MethodInvoker)delegate {
				uiLblStatus.Text = msg;
			});
		}
		private void bw_DoWork(object sender, DoWorkEventArgs e) {
			object[] args = e.Argument as object[];
			FileInfo[] files = args[0] as FileInfo[];
			DataTable results = args[1] as DataTable;
			StatusUpdate("Binning files by size");
			A.DictionaryList<long, FileInfo> binnedBySize = new AlithiaLib.DictionaryList<long, FileInfo>();
			long len;
			for (int i = 0; i < files.Length; i++) {
				len = files[i].Length;
				if (len > 0) binnedBySize.Add(len, files[i]);
			}
			RemoveUniqueEntries<long, FileInfo>(binnedBySize);
			Dictionary<long, A.DictionaryList<string, FileInfo>> binnedByPartialCheckSum = new Dictionary<long, AlithiaLib.DictionaryList<string, FileInfo>>();
			//temp vars
			List<FileInfo> possDupes; FileInfo file; string checksum; byte[] sample;
			StatusUpdate("Calculating fast checksums of candidate files");
			foreach (long l in binnedBySize.Keys) {
				possDupes = binnedBySize[l];
				binnedByPartialCheckSum.Add(l, new AlithiaLib.DictionaryList<string, FileInfo>());
				for (int i = 0; i < possDupes.Count; i++) {
					file = possDupes[i];
					if (bw.CancellationPending)
						return;
					if (file.Exists) {
						sample = A.IO.MD5HashSample(file.FullName, 8);
						if (sample.LongLength > 0) {
							checksum = A.Checksums.ByteArrayToString(sample);
							binnedByPartialCheckSum[l].Add(checksum, file);
							StatusUpdate(String.Format("Fast Checksum: {0} {1}", file.Name, file.Directory.FullName));
						}
					}
				}
			}
			foreach (long l in binnedByPartialCheckSum.Keys) {
				RemoveUniqueEntries<string, FileInfo>(binnedByPartialCheckSum[l]);
			}
			StatusUpdate("Calculating full checksums of suspected duplicates");
			Dictionary<long, A.DictionaryList<string, FileInfo>> binnedByFullCheckSum = new Dictionary<long, AlithiaLib.DictionaryList<string, FileInfo>>();
			foreach (long l in binnedByPartialCheckSum.Keys) {
				binnedByFullCheckSum.Add(l, new AlithiaLib.DictionaryList<string, FileInfo>());
				foreach (string localChecksum in binnedByPartialCheckSum[l].Keys) {
					possDupes = binnedByPartialCheckSum[l][localChecksum];
					for (int i = 0; i < possDupes.Count; i++) {
						if (bw.CancellationPending)
							return;
						file = possDupes[i];
						checksum = A.Checksums.ByteArrayToString(A.IO.MD5HashFile(file.FullName));
						binnedByFullCheckSum[l].Add(checksum, file);
						StatusUpdate(String.Format("Full Checksum: {0} {1}", file.Name, file.Directory.FullName));
					}
				}
			}
			foreach (long l in binnedByFullCheckSum.Keys) {
				RemoveUniqueEntries<string, FileInfo>(binnedByFullCheckSum[l]);
			}
			DataRow dr;
			this.Invoke((MethodInvoker)delegate {
				results.BeginLoadData();
				results.Clear();
				foreach (long l in binnedByFullCheckSum.Keys) {
					foreach (string localChecksum in binnedByFullCheckSum[l].Keys) {
						for (int i = 0; i < binnedByFullCheckSum[l][localChecksum].Count; i++) {
							file = binnedByFullCheckSum[l][localChecksum][i];
							if (bw.CancellationPending)
								return;
							dr = results.NewRow();
							dr["path"] = file.Directory.FullName;
							dr["name"] = file.Name;
							dr["checksum"] = localChecksum;
							dr["size"] = l / 1024;
							dr["fullpath"] = file.FullName;
							results.Rows.Add(dr);
						}
					}
				}
				results.EndLoadData();
			});

			StatusUpdate("Job Complete");
		}
		DataTable createResults() {
			DataTable dt = new DataTable("results");
			dt.BeginInit();
			dt.Columns.Add(new DataColumn("path", typeof(string)));
			dt.Columns.Add(new DataColumn("name", typeof(string)));
			dt.Columns.Add(new DataColumn("checksum", typeof(string)));
			dt.Columns.Add(new DataColumn("size", typeof(long)));
			dt.Columns.Add(new DataColumn("fullpath", typeof(string)));
			dt.Columns["path"].Caption = "File Path";
			dt.Columns["name"].Caption = "Filename";
			dt.Columns["checksum"].Caption = "Checksum (MD5)";
			dt.Columns["size"].Caption = "Size(KB)";
			dt.Columns["fullpath"].Caption = "Full Path";
			dt.EndInit();
			return dt;
		}
		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (pending) {
				pending = false;
				startHarvesting();
			} else {
				uiBtnCancel.Enabled = false;
				dataGridView1.Sort(dataGridView1.Columns["checksum"], ListSortDirection.Ascending);
				resizeCols();
				refreshDeletedFiles();
			}
		}
		void resizeCols() {
			A.Forms.ResizeDataGridCols(dataGridView1);
		}
		private void uiBtnCancel_Click(object sender, EventArgs e) {
			bw.CancelAsync();
			uiLblStatus.Text = "Cancelled";
		}
		private void uiBtnResize_Click(object sender, EventArgs e) {
			resizeCols();
		}
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			A.Shell.ShellExecute("http://www.alithiatec.com");
		}
		string[] GetSelectedPaths() {
			string[] paths = new string[dataGridView1.SelectedRows.Count];
			for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) {
				paths[i] = dataGridView1["fullpath", dataGridView1.SelectedRows[i].Index].Value.ToString();
			}
			return paths;
		}
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			A.Shell.ShellExecute("http://www.alithiatec.com/Contact.aspx");
		}
		private void uiCMSCopy_Click(object sender, EventArgs e) {
			A.Shell.CopyToClipboard(GetSelectedPaths());
		}
		private void uiCMSCut_Click(object sender, EventArgs e) {
			A.Shell.CutToClipboard(GetSelectedPaths());
		}
		private void uiCMSDelete_Click(object sender, EventArgs e) {
			deleteSelected();
		}
		void deleteSelected() {
			ReallyDelete rd = new ReallyDelete();
			for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) {
				rd.Files.Add(new FileInfo(dataGridView1["fullpath", dataGridView1.SelectedRows[i].Index].Value.ToString()));
			}

			if (rd.ShowDialog(this) == DialogResult.Yes) {
				int j=0;
				for (int i = 0; i < rd.Files.Count; i++) {
					if (rd.Files[i].Exists) rd.Files[i].Delete();
					else j++; 
				}
				StatusUpdate((rd.Files.Count-j) + " files deleted successfully");
				rd.Files.Clear();
				refreshDeletedFiles();
			}
		}
		void refreshDeletedFiles() {
			for (int i = resultTable.Rows.Count - 1; i > -1; i--) {
				if (!File.Exists(resultTable.Rows[i]["fullpath"].ToString())) {
					resultTable.Rows[i].Delete();
				}
			}
		}
		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			A.Shell.ShellExecute(dataGridView1["fullpath", e.RowIndex].Value.ToString());
		}
		private void uiBtnLoadResults_Click(object sender, EventArgs e) {
			uiDlgOpen.ShowDialog();
		}
		private void uiBtnSaveResults_Click(object sender, EventArgs e) {
			uiDlgSave.ShowDialog();
		}
		private void uiDlgSave_FileOk(object sender, CancelEventArgs e) {
			try {
				for (int i = 0; i < resultTable.Columns.Count; i++) {
					dataGridView1.Columns[i].HeaderText = resultTable.Columns[i].ColumnName;
				}
				A.Forms.DataGridViewToFile(uiDlgSave.FileName, dataGridView1);
				for (int i = 0; i < resultTable.Columns.Count; i++) {
					dataGridView1.Columns[i].HeaderText = resultTable.Columns[i].Caption;
				}
			} catch (Exception ex) { StatusUpdate(ex.Message); }
		}
		private void uiDlgOpen_FileOk(object sender, CancelEventArgs e) {
			try {
				string[][] content = A.IO.ParseDelimitedText(A.IO.TextFileToString(uiDlgOpen.FileName), "\t");
				Dictionary<int, string> headers = new Dictionary<int, string>();
				for (int i = 0; i < content[0].Length; i++) {
					headers.Add(i, content[0][i]);
				}
				DataRow dr;
				resultTable.Clear();
				resultTable.BeginLoadData();
				for (int i = 1; i < content.Length; i++) {
					dr = resultTable.NewRow();
					for (int j = 0; j < content[i].Length; j++) {
						dr[headers[j]] = content[i][j];
					}
					resultTable.Rows.Add(dr);
				}
				resultTable.EndLoadData();
				dataGridView1.Sort(dataGridView1.Columns["checksum"], ListSortDirection.Ascending);
				resizeCols();
				refreshDeletedFiles();
			} catch (Exception ex) { StatusUpdate(ex.Message); }
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				deleteSelected();
			}
		}

		private void uiBtnRefresh_Click(object sender, EventArgs e) {
			refreshDeletedFiles();
		}
		DateTime releaseDate = new DateTime(2007, 3, 7);
		void checkUpdates(bool silent) {
			AlithiaLib.AppUpdater au = new AlithiaLib.AppUpdater(@"http://www.alithiatec.com/downloads/dedupify.exe", releaseDate, Application.ProductName,silent);
		}

		private void uiBtnCheck4Updates_Click(object sender, EventArgs e) {
			checkUpdates(false);
		}
	}
}