using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.IO.IsolatedStorage;
using AlithiaLib;

namespace RapidFetch {
	internal partial class uiMainForm : Form {
#warning add folder to group <name>,
		HardDisk hd;
		List<DataCol> DataCols = new List<DataCol>();
		DataTable curResults = new DataTable();
		DataView curView;
		Graphics g;
		Stack<IconArgs> cellsNeeded = new Stack<IconArgs>();
		sealed class DataCol {
			internal string ID;
			internal string Name;
			internal Type MemType;
			internal Type GridType;
			internal DataCol(string id, string name, Type memType, Type gridType) {
				ID = id;
				Name = name;
				MemType = memType;
				GridType = gridType;
			}
		}
		sealed class IconArgs {
			internal string FullName;
			internal string Query;
			internal int RowIndex;
			internal Icon icon;
			internal IconArgs(string fullName, int rowIndex, string query) {
				FullName = fullName;
				RowIndex = rowIndex;
				Query = query;
			}
		}
		private void iconWorker_DoWork(object sender, DoWorkEventArgs e) {
			IconArgs ia = (IconArgs)e.Argument;
			ia.icon = IconHandler.IconFromFileName(ia.FullName, IconSize.Small);
			if (ia.icon == null) ia.icon = Properties.Resources.error;
			e.Result = ia;
		}
		private void iconWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			IconArgs res = (IconArgs)e.Result;
			if (uiDGVResults.Rows.Count > res.RowIndex)
				if (uiDGVResults.Rows[res.RowIndex].Cells[0].Displayed & res.Query == uiTSTxtSearch.Text) {
					Rectangle rect = uiDGVResults.GetCellDisplayRectangle(0, res.RowIndex, false);
					g.DrawIconUnstretched(res.icon, rect);
				}
			if (cellsNeeded.Count > 0) {
				IconArgs arg = cellsNeeded.Pop();
				if (uiDGVResults.Rows.Count > arg.RowIndex) {
					if (uiDGVResults.Rows[arg.RowIndex].Cells[0].Displayed) {
						iconWorker.RunWorkerAsync(arg);
					}
				}

			}
		}
		void setCol(DataGridView dg, string id, string title, Type type) {
			dg.Columns.Add(id, title);
			DataGridViewColumn dc = dg.Columns[id];
			dc.ValueType = type;
		}

		private string lastMessage;
		public string LastMessage {
			get { return lastMessage; }
			set { lastMessage = value; uiTSStatus.Text = lastMessage; }
		}
		void hd_JobComplete(string fullPath, bool recurse) {
			LastMessage = "";
			uiTSTxtSearch_TextChanged(null, null);
			//toolStripStatusLabel1.Text = fullPath;
		}
		void hd_SearchComplete(HardDisk.Query results) {
			//Console.Write("done ");
			uiDGVResults.RowCount = 0;
			g.Clear(Color.White);
			curResults = results.results;
			curView = results.resultView;
			uiDGVResults.RowCount = curResults.Rows.Count;
			uiTSLblInfo.Text = curResults.Rows.Count + " Files Found | " + Microsoft.VisualBasic.Strings.FormatNumber(sumSizeCol(), 0, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True) + " KB Total";
			resizeColumns();
		}
		void hd_FolderProcessed(string fullPath, bool recurse) {
			LastMessage = "Indexing: " + fullPath;
		}
		protected override void WndProc(ref Message m) {
			if (m.Msg == SingleApplication.AppID) {
				this.Visible = true;
				this.Activate();
			} else {
				base.WndProc(ref m);
			}
		}
		void uiMainForm_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = !close;
		}
		private void uiMainForm_Load(object sender, EventArgs e) {
			Init();
		}
		void copyData_DataReceived(object sender, DataReceivedEventArgs e) {
			AddPath(e.Data.ToString());
			this.Visible = true;
			this.Activate();
		}
		void CreateFirstRunGroup() {
			NewGroup("Start Menu");
			AddPaths(Environment.SpecialFolder.Programs);
			AddPath(Path.Combine(System.Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), "Start Menu"));
			NewGroup("Desktop");
			AddPaths(Environment.SpecialFolder.DesktopDirectory);
			NewGroup("My Documents");
			AddPaths(Environment.SpecialFolder.MyDocuments);
			NewGroup("Favorites");
			AddPaths(Environment.SpecialFolder.Favorites);
			NewGroup("Make new groups and drag folders into this window!");
		}
		internal uiMainForm() {
			InitializeComponent();
		}

		private void uiTSTxtSearch_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				if (uiDGVResults.SelectedCells.Count > 0) executeRows();
				return;
			}
			if (e.KeyCode == Keys.Down) {
				if (uiDGVResults.Rows.Count > 0)
					this.ActiveControl = uiDGVResults;
				return;
			}
		}
		private void uiTSTxtSearch_TextChanged(object sender, EventArgs e) {
			SearchStrings ss = new SearchStrings(uiTSTxtSearch.Text);
			//label1.Text = ss;
			TreeNode tn = uiTVGroups.SelectedNode;
			if (tn == null) {
				if (uiTVGroups.Nodes.Count > 0) {
					uiTVGroups.SelectedNode = uiTVGroups.Nodes[0];
					tn = uiTVGroups.Nodes[0];
				} else return;
			}
			if (!IsHeadNode(tn)) tn = tn.Parent;
			List<string> paths = new List<string>();
			for (int i = 0; i < tn.Nodes.Count; i++) paths.Add(tn.Nodes[i].Text);
			if (paths.Count == 0) return;
			DataTable results = new DataTable("results");
			for (int i = 1; i < DataCols.Count; i++) {
				results.Columns.Add(DataCols[i].ID, DataCols[i].MemType);
			}
			hd.Search(results, ss.ToArray(), paths.ToArray());
			GC.Collect();
			//DirectoryInfo di = new DirectoryInfo();
		}
		private void uiTSBtnResizeCols_Click(object sender, EventArgs e) {
			resizeColumns();
		}
		private void uiTSBtnAbout_Click(object sender, EventArgs e) {
			new About().Show(this);
		}
		private void uiChkEntireRows_CheckedChanged(object sender, EventArgs e) {
			if (uiDGVResults.SelectionMode == DataGridViewSelectionMode.FullRowSelect) uiDGVResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
			else uiDGVResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		}
		private void uiTSBtnHelp_Click(object sender, EventArgs e) {
			Win32.ShellExecute("http://www.alithiatec.com/RapidFetch.aspx");
		}
		private void uiBtnDemoGroups_Click(object sender, EventArgs e) {
			CreateFirstRunGroup();
		}
		private void uiTSBtnRefresh_Click(object sender, EventArgs e) {
			RefreshNode();
		}

		bool mouseDown = false;

		string sf(Environment.SpecialFolder f) {
			return Environment.GetFolderPath(f);
		}
		string rf(string path) {
			return Path.Combine(path, "RapidFetch.lnk");
		}
		private void uiTSSearch_Resize(object sender, EventArgs e) {
			uiTSTxtSearch.Size = new Size(uiTSSearch.Width - 200, uiTSTxtSearch.Size.Height);
		}
		uiImagePreviewForm ipf = new uiImagePreviewForm();
		private void uiTSBtnImagePreview_Click(object sender, EventArgs e) {
			ipf.Visible = uiTSBtnImagePreview.Checked;
			//InvertVisible(frm);
			//InvertVisible(uiImgPrevTabCtl);
			uiDGVResults_SelectionChanged(null, null);
		}
		private void uiGroupTv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			if (e.Button == MouseButtons.Right) uiTVGroups.SelectedNode = e.Node;
		}
		private void uiTSBtnInfoPane_CheckedChanged(object sender, EventArgs e) {
			uiSplitLeftRight.Panel2Collapsed = (uiSplitInfoOptions.Panel2Collapsed & !uiTSBtnInfoPane.Checked);
			uiSplitInfoOptions.Panel1Collapsed = !uiTSBtnInfoPane.Checked;
			uiSplitInfoOptions.Panel2Collapsed = !uiTSBtnAdvancedOptions.Checked;
			Properties.Settings.Default.showInfoPane = uiTSBtnInfoPane.Checked;
			Properties.Settings.Default.Save();
		}
		private void uiTSBtnAdvancedOptions_CheckedChanged(object sender, EventArgs e) {
			uiSplitLeftRight.Panel2Collapsed = (uiSplitInfoOptions.Panel1Collapsed & !uiTSBtnAdvancedOptions.Checked);
			uiSplitInfoOptions.Panel2Collapsed = !uiTSBtnAdvancedOptions.Checked;
			uiSplitInfoOptions.Panel1Collapsed = !uiTSBtnInfoPane.Checked;
		}


		private void uiTSLblNewGrp_Click(object sender, EventArgs e) {
			NewGroup();
			uiTVGroups.SelectedNode.BeginEdit();
		}
		private void uiTSMIExit_Click(object sender, EventArgs e) {
			exit();
		}
		private void uiTSBtnExit_Click(object sender, EventArgs e) {
			exit();
		}
		private void uiTSBtnHideToTray_Click(object sender, EventArgs e) {
			this.Hide();
			if (Properties.Settings.Default.firstRunTrayBalloon) {
				Properties.Settings.Default.firstRunTrayBalloon = false;
				uiNotifyIcon.ShowBalloonTip(5000);
			}
		}
		private void uiTSBtnAddFolder_Click(object sender, EventArgs e) {
			uiFolderBrowserDlg.ShowDialog();
			if (!String.IsNullOrEmpty(uiFolderBrowserDlg.SelectedPath))
				AddPath(uiFolderBrowserDlg.SelectedPath);
		}
		private void uiBtnViewCache_Click(object sender, EventArgs e) {
			Cache f2 = new Cache();
			hd.DataStore.ToTreeView(f2.treeView1);
			Tree<FolderData>[] flat = hd.DataStore.GetSubTrees();
			for (int i = 0; i < flat.Length; i++) f2.listBox1.Items.Add(flat[i].GetPath());
			f2.Show();
		}
		private void uiTSBtnRemove_Click(object sender, EventArgs e) {
			DeleteNode();
		}
		private void uiTSBtnRename_Click(object sender, EventArgs e) {
			TreeNode tn = uiTVGroups.SelectedNode;
			if (tn != null) {
				if (IsHeadNode(tn)) {
					tn.BeginEdit();
				}
			}
		}
		private void uiTSBtnExplore_Click(object sender, EventArgs e) {
			try {
				if (uiDGVResults.SelectedCells.Count > 0) {
					string path = ((Tree<FolderData>)curView[uiDGVResults.SelectedCells[1].RowIndex]["path"]).ToString();
					Win32.ShellExecute(path);
				}
			} catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
		}
		private void uiTSMIAddSystemFolderItem_Click(object sender, EventArgs e) {
			ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
			if (tsmi.Tag is string) AddPath((string)tsmi.Tag);
			else AddPath(tsmi.Text);
		}
		private void uiExploreCmsItem_Click(object sender, EventArgs e) {
			try {
				Win32.ShellExecute(uiTVGroups.SelectedNode.Text);
			} catch { }
		}
		private void uiTSMIOpenFiles_Click(object sender, EventArgs e) {
			executeRows();

		}
		private void uiTSMISelectAll_Click(object sender, EventArgs e) {
			uiDGVResults.SelectAll();
		}
		private void uiTSMICopyText_Click(object sender, EventArgs e) {
			if (uiDGVResults.SelectedCells.Count > 0)
				Clipboard.SetDataObject(uiDGVResults.GetClipboardContent());
		}
		private void uiTSMICopyFiles_Click(object sender, EventArgs e) {
			Win32.CopyToClipboard(getSelectedPaths());
		}
		private void uiTSMICutFiles_Click(object sender, EventArgs e) {
			Win32.CutToClipboard(getSelectedPaths());
		}
		private void uiTSMISelectNone_Click(object sender, EventArgs e) {
			uiDGVResults.ClearSelection();
		}
		private void uiTSMIStartMenu_Click(object sender, EventArgs e) {
			NewGroup("Start Menu");
			AddPaths(Environment.SpecialFolder.Programs);
			AddPath(Path.Combine(System.Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), "Start Menu"));
		}
		private void uiTSMIDesktop_Click(object sender, EventArgs e) {
			NewGroup("Desktop");
			AddPaths(Environment.SpecialFolder.DesktopDirectory);
		}
		private void uiTSMIMyDocuments_Click(object sender, EventArgs e) {
			NewGroup("My Documents");
			AddPaths(Environment.SpecialFolder.MyDocuments);
		}
		private void uiTSMIMyMusic_Click(object sender, EventArgs e) {
			NewGroup("My Music");
			AddPaths(Environment.SpecialFolder.MyMusic);
		}
		private void uiTSMIMyPictures_Click(object sender, EventArgs e) {
			NewGroup("My Pictures");
			AddPaths(Environment.SpecialFolder.MyPictures);
		}
		private void uiTSMIFavorites_Click(object sender, EventArgs e) {
			NewGroup("Favorites");
			AddPaths(Environment.SpecialFolder.Favorites);
		}
		private void uiTSMIHistory_Click(object sender, EventArgs e) {
			NewGroup("History");
			AddPaths(Environment.SpecialFolder.History);
		}
		private void uiTSMIResizeColumns_Click(object sender, EventArgs e) {
			resizeColumns();
		}
		
		private void uiTVGroups_AfterSelect(object sender, TreeViewEventArgs e) {
			if (uiTVGroups.SelectedNode != null) {
				if (IsHeadNode(uiTVGroups.SelectedNode)) {
					uiTSBtnRename.Enabled = true;
					uiCMSRename.Visible = true;
					string t = uiTVGroups.SelectedNode.Text;
					uiTSLblSearchFor.Text = "Search \"" + t + "\" For:"; ;
				} else {
					uiTSBtnRename.Enabled = false;
					uiCMSRename.Visible = false;
					string t = uiTVGroups.SelectedNode.Parent.Text;
					uiTSLblSearchFor.Text = "Search \"" + t + "\" For:"; ;
				}
				uiTSTxtSearch_TextChanged(null, null);
			}
		}
		private void uiTVGroups_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Delete)
				DeleteNode();
		}
		private void uiTVGroups_DragOver(object sender, DragEventArgs e) {
			this.Activate();
			TreeNode tn = uiTVGroups.GetNodeAt(uiTVGroups.PointToClient(new Point(e.X, e.Y)));
			if (tn == null) return;
			if (!IsHeadNode(tn)) tn = tn.Parent;
			uiTVGroups.SelectedNode = tn;

		}
		private void uiTVGroups_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				Point pos = new Point(e.X, e.Y);
				uiTVGroups.SelectedNode = uiTVGroups.GetNodeAt(pos);
			}
		}
		private void uiTVGroups_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
			//e.Node.BeginEdit();
		}
		private void uiTVGroups_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (!IsHeadNode(e.Node)) e.CancelEdit = true;
		}
		private void uiTVGroups_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (String.IsNullOrEmpty(e.Label) | nodeCollectionContainsText(uiTVGroups.Nodes, e.Label)) {
				e.CancelEdit = true;
			} else SaveGroupList();
		}
		
		private void uiNotifyIcon_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (!this.Visible) this.Show();
				else this.Hide();
			}
		}
        private static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height) {
            //a holder for the result
            Bitmap result = new Bitmap(width, height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result)) {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                //draw the image into the target bitmap
                graphics.DrawImage(image, result.Width, result.Height);
            }

            //return the resulting bitmap
            return result;
        }
        private static void DrawImage(Graphics g,Image image,int width,int height)
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            
            g.Clear(Color.Black);
            float newWidth = image.Width, newHeight = image.Height, scale = 0;
            if (newWidth > width || newHeight > height)
            {
                float aw = width/newWidth, ah = height/newHeight;
                if ( aw< ah) {
                    scale = aw;
                } else {
                    scale = ah;
                }
                
            } else
            {
                scale = Math.Min(width/newWidth, height/newHeight);
            }
            newWidth *= scale;
            newHeight *= scale;
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }
		private void uiDGVResults_SelectionChanged(object sender, EventArgs e) {
			if (ipf.Visible) {
				try {
					if (uiDGVResults.SelectedCells.Count > 0) {
						string x = getPath(uiDGVResults.SelectedCells[0].RowIndex);
					    Image img = Image.FromFile(x);
                        //ipf.toolStripContainer1.ContentPanel.BackgroundImage = ResizeImage(img, );
                        DrawImage(ipf.toolStripContainer1.ContentPanel.CreateGraphics(), img, ipf.toolStripContainer1.ContentPanel.ClientSize.Width, ipf.toolStripContainer1.ContentPanel.ClientSize.Height);
					    //img.GetThumbnailImage(ipf.ClientRectangle.Width, ipf.ClientRectangle.Height, new Image.GetThumbnailImageAbort(Abort), IntPtr.Zero);
					}
				} catch {
					//ipf.toolStripContainer1.ContentPanel.BackgroundImage = null;
				}
			}
		}
		bool Abort() {
			return false;
		}
		private void uiDGVResults_MouseUp(object sender, MouseEventArgs e) {
			mouseDown = false;
		}
		private void uiDGVResults_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				uiCMSResults.Show(Win32.GetCursorPos());
			}
		}
		private void uiDGVResults_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) mouseDown = true;
		}
		private void uiDGVResults_MouseMove(object sender, MouseEventArgs e) {
			if (mouseDown) {
				mouseDown = false;
				try {
					Image img = ipf.toolStripContainer1.ContentPanel.BackgroundImage;
					ipf.toolStripContainer1.ContentPanel.BackgroundImage = null;
					img.Dispose();
					GC.Collect();
					ipf.Visible = false;
				} catch { }
				string[] p = getSelectedPaths();
				uiDGVResults.DoDragDrop(new DataObject(DataFormats.FileDrop, p), DragDropEffects.Copy | DragDropEffects.Move /* | DragDropEffects.Link */);
			}
		}
		bool dragDone = false;
		private void uiDGVResults_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
			if (e.Action == DragAction.Drop) {
				dragDone = true;
			} else {
				if (dragDone) {
					dragDone = false;
					e.Action = DragAction.Cancel;
				}
			}

			Console.WriteLine(e.Action);
		}
		private void timer1_Tick(object sender, EventArgs e) {
			timer1.Enabled = false;
			uiDGVResults.Refresh();
		}
		private void uiDGVResults_Scroll(object sender, ScrollEventArgs e) {
			timer1.Stop();
			timer1.Enabled = true;
		}
		private void uiDGVResults_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Up) {
				if (uiDGVResults.SelectedCells.Count > 0) {
					if (uiDGVResults.SelectedCells[0].RowIndex == 0) {
						uiTSTxtSearch.Focus();
					}
				}
			}
			if (e.KeyCode == Keys.Enter) {
				executeRows();
				e.Handled = true;
			}
		}
		private void uiDGVResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.RowIndex > -1) if (uiDGVResults.SelectedCells.Count > 0) executeRows();
		}
		private void uiDGVResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.Clicks == 1) {
				int colix = e.ColumnIndex;
				if (colix == 0) colix = uiDGVResults.Columns["type"].Index;
				if (curView.Sort.EndsWith("DESC")) curView.Sort = curResults.Columns[colix - 1].ColumnName;
				else curView.Sort = curResults.Columns[colix - 1].ColumnName + " DESC";
				uiDGVResults.Refresh();
			}
		}
		private void uiDGVResults_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
			if (e.ColumnIndex > 0) {
				if (e.ColumnIndex < 6) {
					e.Value = curView[e.RowIndex][e.ColumnIndex - 1];
				} else {
					e.Value = new DateTime((long)curView[e.RowIndex][e.ColumnIndex - 1]).ToString();
				}
			} else {
				string path = uiDGVResults.Rows[e.RowIndex].Cells[1].Value.ToString();
				string name = (string)curView[e.RowIndex][1];
				if (iconWorker.IsBusy) cellsNeeded.Push(new IconArgs(Path.Combine(path, name), e.RowIndex, uiTSTxtSearch.Text));
				else iconWorker.RunWorkerAsync(new IconArgs(Path.Combine(path, name), e.RowIndex, uiTSTxtSearch.Text));
				e.Value = " ";
			}

		}
		private void uiDGVResults_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
			
		}
		private void uiDGVResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {

		}

		string assemblyLocation = System.Reflection.Assembly.GetCallingAssembly().Location;
		private void uiBtnDesktop_Click(object sender, EventArgs e) {
			if (uiOptAllUsers.Checked) {
				Win32.SaveShortcut(assemblyLocation, rf(Win32.GetSpecialFolder(Win32.SpecialFolder.AllUsersDesktop)));
			} else {
				Win32.SaveShortcut(assemblyLocation, rf(sf(Environment.SpecialFolder.DesktopDirectory)));
			}
		}
		private void uiBtnStartMenu_Click(object sender, EventArgs e) {
			if (uiOptAllUsers.Checked) {
				Win32.SaveShortcut(assemblyLocation, rf(Win32.GetSpecialFolder(Win32.SpecialFolder.AllUsersStartMenu)));
				Win32.SaveShortcut(assemblyLocation, rf(Win32.GetSpecialFolder(Win32.SpecialFolder.AllUsersPrograms)));
			} else {
				Win32.SaveShortcut(assemblyLocation, rf(sf(Environment.SpecialFolder.StartMenu)));
				Win32.SaveShortcut(assemblyLocation, rf(sf(Environment.SpecialFolder.Programs)));
			}
		}
		private void uiBtnQuickLaunch_Click(object sender, EventArgs e) {
			string s = sf(Environment.SpecialFolder.ApplicationData);
			s = rf(Path.Combine(s, "Microsoft\\Internet Explorer\\Quick Launch"));
			Win32.SaveShortcut(assemblyLocation, s);
		}



		void tagHelp(Control c) {
			foreach (Control var in c.Controls) {
				if (var.Tag is string) {
					//if (var.Tag as string == "search") System.Diagnostics.Debugger.Break();
					if (!String.IsNullOrEmpty(var.Tag as string)) {
						Console.WriteLine(var.Tag as string);
						var.MouseEnter += new EventHandler(var_MouseEnter);
					}
				}
				tagHelp(var);
			}
			if (c is ToolStrip) {
				ToolStrip t = c as ToolStrip;
				foreach (ToolStripItem var in t.Items) {
					if (!String.IsNullOrEmpty(var.Tag as string)) {
						Console.WriteLine(var.Tag as string);
						var.MouseEnter += new EventHandler(var_MouseEnter);
					}
				}
			}
		}
		void loadHelp(object sender, EventArgs e) {
			string key = "";
			if (sender is Control) key = ((Control)sender).Tag.ToString();
			else if (sender is ToolStripItem) key = ((ToolStripItem)sender).Tag.ToString();
			//if (c.Tag as string == "search") System.Diagnostics.Debugger.Break();
			uiTSLblStatus.Text = HC[key].ShortDescription;
			if (HC[key].ExtendedDescription == "") uiLblInfoPane.Text = HC[key].ShortDescription;
			else uiLblInfoPane.Text = HC[key].ExtendedDescription;
		}
		void var_MouseEnter(object sender, EventArgs e) {
			loadHelp(sender, e);
		}
		HelpContent HC = new HelpContent();
		DateTime releaseDate = new DateTime(2007, 3, 7);
		void checkUpdates(bool silent) {
			AlithiaLib.AppUpdater au = new AlithiaLib.AppUpdater(@"http://www.alithiatec.com/downloads/rapidfetch.exe", releaseDate, Application.ProductName,silent);
		}
		void Init() {
			Console.SetError(Console.Out);
			if (Properties.Settings.Default.firstRunGroupCreation) {
				Properties.Settings.Default.Upgrade();
			}
            //if (Properties.Settings.Default.showDisclaimer) {
            //    Disclaimer d=new Disclaimer();
            //    if (d.ShowDialog(this) == DialogResult.Yes) {
            //        Properties.Settings.Default.showDisclaimer = false;
            //        Properties.Settings.Default.Save();
            //    } else {
            //        exit();
            //        return;
            //    }
            //}
            //if (DateTime.Now.Ticks - Properties.Settings.Default.lastCheckForUpdate.Ticks > new TimeSpan(2, 0, 0, 0).Ticks) {
            //    Properties.Settings.Default.lastCheckForUpdate = DateTime.Now;
            //    Properties.Settings.Default.Save();
            //    checkUpdates(true);
            //}
            uiTSMainMenu.Renderer = new CustomProfessionalToolStripRenderer();
            uiTSSearch.Renderer = new CustomProfessionalToolStripRenderer();
            uiToolStripResults.Renderer = new CustomProfessionalToolStripRenderer();
            uiTSGroups.Renderer = new CustomProfessionalToolStripRenderer();
            uiToolStripResults.Renderer = new CustomProfessionalToolStripRenderer();
		    uiTSBtnOpen.Click += uiTSMIOpenFiles_Click;
		    uiTSBtnExplore.Click += uiTSBtnExplore_Click;
		    uiTSBtnCut.Click += uiTSMICutFiles_Click;
		    uiTSBtnCopy.Click += uiTSMICopyFiles_Click;
		    uiTSBtnCopyText.Click += uiTSMICopyText_Click;
		    uiTSBtnImagePreview.Click += uiTSBtnImagePreview_Click;
		    uiTSBtnSelectAll.Click += uiTSMISelectAll_Click;
		    uiTSBtnSelectNone.Click += uiTSMISelectNone_Click;
		    uiTSBtnResizeCols.Click += uiTSBtnResizeCols_Click;
			ipf.Owner = this;
			tagHelp(this);
			loadHelp(uiTSMainMenu,null);
			this.SuspendLayout();
			uiGroupsTSContainer.Dock = DockStyle.Fill;
			uiSearchTSContainer.Dock = DockStyle.Fill;
			uiSplitGroupsResults.Dock = DockStyle.Fill;
			uiSplitInfoOptions.Dock = DockStyle.Fill;
			uiSplitLeftRight.Dock = DockStyle.Fill;
			uiTabAdvancedOptions.Dock = DockStyle.Fill;
			uiTabInfoPane.Dock = DockStyle.Fill;
			this.ResumeLayout();
			g = uiDGVResults.CreateGraphics();
			hd = new HardDisk(bw, resultWorker);
			hd.SearchComplete += new SearchCompleteDelegate(hd_SearchComplete);
			hd.JobComplete += new HardDisk.TreeEventHandler(hd_JobComplete);
			hd.FolderProcessed += new HardDisk.TreeEventHandler(hd_FolderProcessed);
			new FileDragDropHandler(uiTVGroups).FilesDropped += new DragDropOccured(fdd_FilesDropped);
			uiTSBtnAdvancedOptions_CheckedChanged(null, null);
			uiNotifyIcon.Icon = Properties.Resources.rf_icon_v2;
			this.Icon = Properties.Resources.rf_icon_v2;
			DataCols.Add(new DataCol("icon", "", typeof(string), typeof(string)));
			DataCols.Add(new DataCol("path", "Path", typeof(Tree<FolderData>), typeof(string)));
			DataCols.Add(new DataCol("name", "Name", typeof(string), typeof(string)));
			DataCols.Add(new DataCol("ext", "Extension", typeof(string), typeof(string)));
			DataCols.Add(new DataCol("size", "Size(KB)", typeof(long), typeof(long)));
			DataCols.Add(new DataCol("type", "Type", typeof(string), typeof(string)));
			//DataCols.Add(new DataCol("created", "Created", typeof(long), typeof(string)));
			DataCols.Add(new DataCol("modified", "Modified", typeof(long), typeof(string)));

			for (int i = 0; i < DataCols.Count; i++) {
				setCol(uiDGVResults, DataCols[i].ID, DataCols[i].Name, DataCols[i].GridType);
			}
			uiDGVResults.Columns["size"].DefaultCellStyle.Format = "n0";
			uiDGVResults.Columns["size"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			curResults = new DataTable("results");
			for (int i = 1; i < DataCols.Count; i++) {
				curResults.Columns.Add(DataCols[i].ID, DataCols[i].MemType);
			}
			curView = new DataView(curResults);
			//ToolStripMenuItem tsmi=new ToolStripMenuItem(
			//cmsAddSystemFolder.Items.Add("Start Menu Group", null, new EventHandler(cmsAddSystemFolderItem_Click));

			string[] s = Enum.GetNames(typeof(Environment.SpecialFolder));
			for (int i = 0; i < s.Length; i++) {
				s[i] = Environment.GetFolderPath((Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), s[i]));

			}
			Array.Resize<string>(ref s, s.Length + 1);
			s[s.Length - 1] = Path.Combine(System.Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), "Start Menu");
			Array.Sort<string>(s);
			for (int i = 0; i < s.Length; i++) {
				if (!String.IsNullOrEmpty(s[i])) {
					uiTSDDAddSysFolder.DropDownItems.Add(s[i], IconHandler.IconFromFileName(s[i], IconSize.Small).ToBitmap(), new EventHandler(uiTSMIAddSystemFolderItem_Click));
				}
			}

			ReadGroupList();
			if (Program.args != null) {
				if (Program.args.Length > 0) {
					string temp;
					//MessageBox.Show(PrintString(Program.args));
					List<string> cmdArgs = new List<string>();
					for (int i = 0; i < Program.args.Length; i++) {
						temp = Path.GetFullPath(Program.args[i]);
						if (Directory.Exists(temp) | File.Exists(temp)) cmdArgs.Add(temp);
					}
					AddPaths(cmdArgs.ToArray());
				}
			}
			if (Properties.Settings.Default.firstRunGroupCreation) {
				CreateFirstRunGroup();
				Properties.Settings.Default.firstRunGroupCreation = false;
				Properties.Settings.Default.Save();
			}
			CopyData copyData = new CopyData();
			copyData.AssignHandle(this.Handle);
			copyData.Channels.Add("1");
			copyData.DataReceived += new DataReceivedEventHandler(copyData_DataReceived);
			//makePerty(this);
			this.Text = String.Format("{0} {1} {2}", Application.ProductName, Application.ProductVersion, Application.CompanyName);
			uiTSBtnInfoPane.Checked = Properties.Settings.Default.showInfoPane;
			this.Activate();
		}

		void NewGroup() {
			TreeNode n = uiTVGroups.Nodes.Add(GetFreshGroupName());
			uiTVGroups.SelectedNode = n;
		}
		void NewGroup(string name) {
			TreeNode n = uiTVGroups.Nodes.Add(name);
			uiTVGroups.SelectedNode = n;
			SaveGroupList();
		}
		void AddPath(string fullPath) {
			AddPaths(new string[] { fullPath });
		}
		void AddPaths(string[] fullPaths) {
			if (uiTVGroups.Nodes.Count < 1) NewGroup();
			TreeNode n = uiTVGroups.SelectedNode;
			if (n == null) n = uiTVGroups.Nodes[0];
			if (!IsHeadNode(n)) n = n.Parent;
			for (int i = 0; i < fullPaths.Length; i++) {
				string s = fullPaths[i];
				if (String.IsNullOrEmpty(s)) continue;
				try {
					if (System.IO.File.Exists(fullPaths[i])) s = System.IO.Path.GetDirectoryName(s);
					else if (System.IO.Directory.Exists(fullPaths[i])) s = System.IO.Path.GetFullPath(s);
				} catch { continue; }
				if (!nodeCollectionContainsText(n.Nodes, s)) {
					n.Nodes.Add(Guid.NewGuid().ToString(), s);
					hd.QueueJob(HardDiskOp.Add, s, true);
				}

			}
			SaveGroupList();
			n.ExpandAll();
		}
		void AddPaths(params Environment.SpecialFolder[] folders) {
			string[] paths = new string[folders.Length];
			for (int i = 0; i < folders.Length; i++) {
				paths[i] = Environment.GetFolderPath(folders[i]);
			}
			AddPaths(paths);
		}

		void DeleteNode() {
			TreeNode tn = uiTVGroups.SelectedNode;
			if (tn != null) {
				if (IsHeadNode(tn)) {
					foreach (TreeNode n in tn.Nodes) {
						//OnGroupDeleted(n.Name);
						hd.QueueJob(HardDiskOp.Delete, n.Text, true);
						n.Remove();
					}
				} else {
					hd.QueueJob(HardDiskOp.Delete, tn.Text, true);
					//OnGroupDeleted(tn.Name);
				}
				uiTVGroups.Nodes.Remove(tn);
				SaveGroupList();
			}
		}
		void RefreshNode() {
			TreeNode tn = uiTVGroups.SelectedNode;
			if (tn != null) {
				if (IsHeadNode(tn)) {
					foreach (TreeNode n in tn.Nodes) {
						//OnGroupDeleted(n.Name);
						hd.QueueJob(HardDiskOp.Delete, n.Text, true);
						hd.QueueJob(HardDiskOp.Add, n.Text, true);
					}
				} else {
					hd.QueueJob(HardDiskOp.Delete, tn.Text, true);
					hd.QueueJob(HardDiskOp.Add, tn.Text, true);
					//OnGroupDeleted(tn.Name);
				}
			}
		}
		void fdd_FilesDropped(string[] files) {
			AddPaths(files);
		}
		bool IsHeadNode(TreeNode n) {
			if (n == null) throw new NullReferenceException("IsHeadNode received a null node");
			if (n.Parent == null) return true;
			return false;
		}
		string GetFreshGroupName() {
			int i = 1;
			while (nodeCollectionContainsText(uiTVGroups.Nodes, "Group " + i)) {
				i++;
			}
			return "Group " + i;
		}
		bool saveAllowed = true;
		void SaveGroupList() {
			if (saveAllowed) {
				MemoryStream ms = new MemoryStream();
				TextWriter tw = new StreamWriter(ms);
				for (int i = 0; i < uiTVGroups.Nodes.Count; i++) {
					tw.WriteLine(uiTVGroups.Nodes[i].Text);
					for (int j = 0; j < uiTVGroups.Nodes[i].Nodes.Count; j++) {
						tw.WriteLine("\t" + uiTVGroups.Nodes[i].Nodes[j].Text);
					}
				}
				tw.Flush();
				string str = streamToString(ms);
				Properties.Settings.Default.Groups = str;
				Properties.Settings.Default.Save();
			}
		}
		void ReadGroupList() {
			saveAllowed = false;
			MemoryStream ms = new MemoryStream();
			//RapidFetch.Properties.Settings.Default.Reload();
			string str = Properties.Settings.Default.Groups;
			if (string.IsNullOrEmpty(str)) {
				saveAllowed = true;
				return;
			}
			stringToStream(ms, str);
			TextReader tr = new StreamReader(ms);
			string line = "";
			while (tr.Peek() > -1) {
				line = tr.ReadLine();
				if (!string.IsNullOrEmpty(line)) {
					if (line.StartsWith("\t")) {
						//MessageBox.Show("addpath " + line.TrimStart('\t'));
						AddPath(line.TrimStart('\t'));
					} else
						NewGroup(line);
				}
			}
			saveAllowed = true;
		}
		bool close = false;
		void exit() {
			SaveGroupList();
			close = true;
			this.Close();
		}

		void resizeColumns() {
			uiDGVResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			if (uiDGVResults.Rows.Count > 0) uiDGVResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
			else uiDGVResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			int[] widths = new int[uiDGVResults.Columns.Count];
			for (int i = 0; i < uiDGVResults.Columns.Count; i++) {
				widths[i] = uiDGVResults.Columns[i].Width;
			}
			uiDGVResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			for (int i = 0; i < uiDGVResults.Columns.Count; i++) {
				uiDGVResults.Columns[i].Width = widths[i];
			}
		}
		void executeRows() {
			string[] p = getSelectedPaths();
			//if (MessageBox.Show("Open all " + p.Length + " files/folders?", "Batch Execute", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				for (int i = 0; i < p.Length; i++) {
					Win32.ShellExecute(p[i]);
				}
			//}
		}
		string[] getSelectedPaths() {
			List<int> rows = new List<int>(uiDGVResults.SelectedCells.Count);
			for (int i = 0; i < uiDGVResults.SelectedCells.Count; i++) {
				if (!rows.Contains(uiDGVResults.SelectedCells[i].RowIndex)) rows.Add(uiDGVResults.SelectedCells[i].RowIndex);
			}
			string[] paths = new string[rows.Count];
			for (int i = 0; i < rows.Count; i++) {
				paths[i] = getPath(rows[i]);
			}
			return paths;
		}
		string getPath(int rowIndex) {
			string path = ((Tree<FolderData>)curView[rowIndex]["path"]).ToString();
			string name = (string)curView[rowIndex]["name"];
			return Path.Combine(path, name);
		}
		long sumSizeCol() {
			long acc = 0;
			for (int i = 0; i < curView.Count; i++) {
				acc = acc + (long)curView[i]["size"];
			}
			return acc;
		}
		internal bool nodeCollectionContainsText(TreeNodeCollection nc, string text) {
			if (text == null) return false;
			for (int i = 0; i < nc.Count; i++) {
				if (nc[i].Text.ToLower() == text.ToLower()) return true;
			}
			return false;
		}
		void XMLSerializeToStream(Stream s, object o) {
			XmlSerializer xs = new XmlSerializer(o.GetType());
			TextWriter w = new StreamWriter(s);
			xs.Serialize(s, o);
		}
		object XMLDeSerializeFromStream(Stream s, Type t) {
			XmlSerializer xs = new XmlSerializer(t);
			return xs.Deserialize(s);
		}
		internal static void stringToStream(Stream s, string str) {
			StreamWriter sw = new StreamWriter(s);
			sw.Write(str);
			sw.Flush();
			s.Seek(0, SeekOrigin.Begin);
		}
		internal static string streamToString(Stream s) {
			s.Seek(0, SeekOrigin.Begin);
			TextReader tr = new StreamReader(s);
			string res = tr.ReadToEnd();
			s.Seek(0, SeekOrigin.Begin);
			return res;
		}
		void ChangeShellIntegration(bool enabled) {
			if (enabled) {
				try {
					string exec = "\"" + Application.ExecutablePath + "\" \"%1\"";
					//Registry.ClassesRoot.CreateSubKey("Applications\\RapidFetch.exe\\shell\\open\\command").SetValue("", exec, RegistryValueKind.String);
					Registry.ClassesRoot.CreateSubKey("*\\shell\\RapidFetch\\Command").SetValue("", exec, RegistryValueKind.String);
					Registry.ClassesRoot.CreateSubKey("Directory\\Shell\\RapidFetch\\Command").SetValue("", exec, RegistryValueKind.String);
				} catch (Exception e) { MessageBox.Show(e.ToString()); }
			} else {
				try {
					Registry.ClassesRoot.DeleteSubKeyTree("*\\shell\\RapidFetch");
				} catch (Exception e) { MessageBox.Show(e.ToString()); }
				try {
					Registry.ClassesRoot.DeleteSubKeyTree("Directory\\Shell\\RapidFetch");
				} catch (Exception e) { MessageBox.Show(e.ToString()); }
			}
		}
		string PrintString(string[] array) {
			if (array == null) return "";
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < array.Length; i++) {
				sb.AppendLine(array[i]);
			}
			return sb.ToString();
		}
		string CommaDelimit(params object[] items) {
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < items.Length; i++) {
				sb.Append(items[i].ToString());
				sb.Append(",");
			}
			return sb.ToString();
		}
		void InvertVisible(Control c) {
			c.Visible = !c.Visible;
		}

		private void uiMainForm_MouseLeave(object sender, EventArgs e) {
			loadHelp(sender, e);
		}
		private void uiBtnIntegrate_Click(object sender, EventArgs e) {
			ChangeShellIntegration(true);
		}
		private void uiBtnUnIntegrate_Click(object sender, EventArgs e) {
			ChangeShellIntegration(false);
		}

		private void uiTSBtnCheckForUpdates_Click(object sender, EventArgs e) {
			checkUpdates(false);
		}

		private void uiBtnResetToDefaults_Click(object sender, EventArgs e) {
			Properties.Settings.Default.Reset();
		}

		private void uiTSBtnInfoPane_Click(object sender, EventArgs e) {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uiTSBtnInfoPane.Checked = !uiTSBtnInfoPane.Checked;
        }

	}
}