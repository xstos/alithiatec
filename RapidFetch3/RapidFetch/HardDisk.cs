using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace RapidFetch {
	internal delegate void SearchCompleteDelegate(HardDisk.Query results);
	internal enum HardDiskOp {
		Add, Delete
	}

	internal sealed class FolderData {
		//public static Dictionary<string, object> SearchExtensions;
        //internal static FileStream fs = new FileStream("output.txt", FileMode.Create );
        //internal static StreamWriter sr = new StreamWriter(fs);
        internal static readonly string Type = IconHandler.TypeNameFromExtension(".", IconHandler.Attr.FILE_ATTRIBUTE_DIRECTORY);
		static readonly FileData[] empty = new FileData[] { };
		static readonly FileInfo[] empty2 = new FileInfo[] { };
		internal readonly long CreatedTicks;
		internal readonly long ModifiedTicks;
		internal readonly FileData[] Files;
		internal static readonly FolderData Empty = new FolderData();
		internal FolderData(DirectoryInfo di) {
			if (di.Exists) {
				FileInfo[] fi = null;

				CreatedTicks = di.CreationTime.Ticks;
				ModifiedTicks = di.LastWriteTime.Ticks;
				try {
					fi = di.GetFiles();
				} catch (Exception ex) {
					Console.Error.WriteLine(ex.Message);
					fi = empty2;
				}
				Files = new FileData[fi.Length];
				for (int i = 0; i < fi.Length; i++) {
					try {
						Files[i] = new FileData(fi[i]);
                        //sr.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", di.FullName, Files[i].FileName, Files[i].SizeKB, Files[i].CreatedTicks, Files[i].ModifiedTicks));
					} catch {
						Files[i] = new FileData();
					}
				}


			} else {
				Files = empty;
			}
		}
		internal FolderData() {
			Files = empty;
		}
	}
	internal sealed class FileData {
		//static Dictionary<string, Icon> IconCache = new Dictionary<string, Icon>();
		static Dictionary<string, string> TypeCache = new Dictionary<string, string>();
		internal static readonly FileData Empty = new FileData();
		internal readonly string FileName="";
		//public readonly long Size;
		internal readonly long SizeKB=0;
		internal readonly long CreatedTicks=0;
		internal readonly long ModifiedTicks=0;
		internal string TypeName {
			get { return TypeCache[extension]; }
		}
		string extension="";
		internal string Extension {
			get { return extension; }
		}
		//public Icon SmallIcon {
		//    get { return IconCache[extension]; }
		//}
		internal FileData() {
			if (!TypeCache.ContainsKey("")) TypeCache.Add("", "");
		}
		internal FileData(FileInfo fsi) {
			try {
				this.FileName = fsi.Name;
				//this.Size = fsi.Length;
				SizeKB = (long)Math.Round(fsi.Length / (double)1024, 0);
				this.CreatedTicks = fsi.CreationTime.Ticks;
				this.ModifiedTicks = fsi.LastWriteTime.Ticks;
				this.extension = fsi.Extension.TrimStart('.');
				if (!TypeCache.ContainsKey(extension)) {
					//string tn;
					//IconCache.Add(extension, IconHandler.IconFromExtension("." + extension, IconSize.Small, out tn, IconHandler.Attr.FILE_ATTRIBUTE_NORMAL));
					TypeCache.Add(extension, IconHandler.TypeNameFromExtension('.' + extension, IconHandler.Attr.FILE_ATTRIBUTE_NORMAL));

				}
			} catch (Exception ex) {
				Console.Error.WriteLine(ex.Message);
				throw;
			}
		}
		public override string ToString() {
			return FileName;
		}
	}
	internal sealed class HardDisk {
		#region Search
		internal event SearchCompleteDelegate SearchComplete;
		void OnSearchComplete(HardDisk.Query results) {
			if (SearchComplete != null) SearchComplete(results);
		}
		BackgroundWorker searchWorker;

		Query query = null;

		internal sealed class Query {
			internal string[] queryPhrases;
			internal string[] fullPaths;
			internal DataTable results;
			internal DataView resultView;
			internal Query(DataTable results, string[] phrases, string[] fullPaths, DataView resultView) {
				this.results = results;
				this.queryPhrases = phrases;
				this.fullPaths = fullPaths;
				this.resultView = resultView;
			}
		}
		Stack<Query> queries = new Stack<Query>();
		internal void Search(DataTable results, string[] phrases, string[] fullPaths) {
			query = new Query(results, phrases, fullPaths, null);
			if (searchWorker.IsBusy) searchWorker.CancelAsync();
			else {
				searchWorker.RunWorkerAsync(query);
				query = null;
			}
		}

		void bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			OnSearchComplete((Query)e.Result);
			if (query != null) {
				searchWorker.RunWorkerAsync(query);
				query = null;
			}
		}

		void bw2_DoWork(object sender, DoWorkEventArgs e) {
			Query q = (Query)e.Argument;
			q.queryPhrases = StringUtil.ToLower(q.queryPhrases);
			//q.results.Rows.Clear();
			Tree<FolderData>[] trees;
			Tree<FolderData> test;
			q.results.BeginLoadData();
			for (int i = 0; i < q.fullPaths.Length; i++) {
				test = dataStore.GetSubTreeByAddress(q.fullPaths[i]);
				if (test != null) {
					trees = test.GetSubTrees();
					for (int k = 0; k < trees.Length; k++) {
						if (ContainsAllPhrases(trees[k].GetPath().ToLower(), q.queryPhrases)) {
							q.results.Rows.Add(
								//FolderData.Icon,
								trees[k].Parent,
								trees[k].Key,
								"",
								0,
								FolderData.Type,
								//trees[k].Data.CreatedTicks,
								trees[k].Data.ModifiedTicks);
						}
						for (int j = 0; j < trees[k].Data.Files.Length; j++) {
							if (searchWorker.CancellationPending) {
								q.resultView = new DataView(q.results);
								e.Result = q;
								return;
							}
							if (ContainsAllPhrases(trees[k].Data.Files[j].FileName.ToLower(), q.queryPhrases)) {
								q.results.Rows.Add(
									//trees[k].Data.Files[j].SmallIcon,
									trees[k],
									trees[k].Data.Files[j].FileName,
									trees[k].Data.Files[j].Extension,

									trees[k].Data.Files[j].SizeKB,
									trees[k].Data.Files[j].TypeName,
									//trees[k].Data.Files[j].CreatedTicks,
									trees[k].Data.Files[j].ModifiedTicks);
							}
						}

					}
				}
			}
			q.results.EndLoadData();
			q.resultView = new DataView(q.results);
			e.Result = q;
		}
		bool ContainsAllPhrases(string text, string[] phrases) {
			for (int i = 0; i < phrases.Length; i++) {
				if (!text.Contains(phrases[i])) return false;
			}
			return true;
		}
		#endregion
		#region Indexer=============================================================================================
		internal delegate void TreeEventHandler(string fullPath, bool recurse);
		#region Events
		internal event TreeEventHandler JobComplete;
		internal event TreeEventHandler FolderProcessed;
		void OnJobComplete(string fullPath, bool recurse) {
			if (JobComplete != null) JobComplete(fullPath, recurse);
		}
		void OnFolderProcessed(string fullPath, bool recurse) {
			if (FolderProcessed != null) FolderProcessed(fullPath, recurse);
		}
		#endregion
		Tree<FolderData> dataStore;

		sealed class Job : IEquatable<Job> {
			internal HardDiskOp Action;
			internal string Path;
			internal bool Recurse;
			internal Job(HardDiskOp action, string path, bool recurse) {
				this.Action = action;
				this.Path = path;
				this.Recurse = recurse;
			}
			#region IEquatable<Job> Members
			public bool Equals(Job other) {
				return PathsAreEqual(Path, other.Path);
			}
			#endregion
		}
		BackgroundWorker indexingWorker;
		Queue<Job> JobBuffer = new Queue<Job>();
		Queue<string> CurrentJobBuffer = new Queue<string>();
		Tree<FolderData> ProcessedSoFar = new Tree<FolderData>(FolderData.Empty, new IgnoreCaseComparer());
		internal void QueueJob(HardDiskOp action, string fullPath, bool recurse) {
			switch (action) {
				case HardDiskOp.Add:
					JobBuffer.Enqueue(new Job(action, fullPath, recurse));
					if (!indexingWorker.IsBusy) {
						indexingWorker.RunWorkerAsync(new BWArgs(fullPath, recurse));
					}
					break;
				case HardDiskOp.Delete:
					if (recurse) {
						if (JobBuffer.Count > 0) { //processing
							if (PathsAreEqual(fullPath, JobBuffer.Peek().Path)) { //currently processing this path
								cancel = true; //cancel the addition of the last folder
								CurrentJobBuffer.Clear();
								dataStore.RemoveTree(ProcessedSoFar);
								ProcessedSoFar.Clear();
							} else if (JobBuffer.Contains(new Job(HardDiskOp.Add, fullPath, true))) { //path is pending
								foreach (Job j in JobBuffer) {
									if (PathsAreEqual(j.Path, fullPath)) {
										j.Path = "";
										break;
									}
								}
							} else { //path already processed
								Tree<FolderData> t = dataStore.GetSubTreeByAddress(fullPath);
								if (t != null) t.RemoveSubTrees();
							}
						} else { //indexer idle
							Tree<FolderData> t = dataStore.GetSubTreeByAddress(fullPath);
							if (t != null) t.RemoveSubTrees();
						}
						GC.Collect();

					} else dataStore.RemovePath(fullPath);
					break;
				default:
					break;
			}
		}
		bool cancel = false;
		static bool PathsAreEqual(string path1, string path2) {
			try {
				path1 = Path.GetFullPath(path1).ToLower().TrimEnd(Path.DirectorySeparatorChar);
                path2 = Path.GetFullPath(path2).ToLower().TrimEnd(Path.DirectorySeparatorChar);
				//if (!path1.EndsWith("\\")) path1 = path1 + '\\';
				//if (!path2.EndsWith("\\")) path2 = path2 + '\\';
				return string.Equals(path1, path2);
			} catch { return false; }
		}
		void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			BWResults results = (BWResults)e.Result;
			if (results.Exists & !cancel) {
				Tree<FolderData> node;
				node = dataStore.CreatePath(results.FullPath, FolderData.Empty);
				ProcessedSoFar.CreatePath(results.FullPath, FolderData.Empty); //track what folders we threw in so we can delete if necessary
				node.Data = results.FD;
				if (JobBuffer.Peek().Recurse) {
					for (int i = 0; i < results.Folders.Length; i++)
						CurrentJobBuffer.Enqueue(Path.Combine(results.FullPath, results.Folders[i]));
				} else {
					for (int i = 0; i < results.Folders.Length; i++)
						dataStore.CreatePath(Path.Combine(results.FullPath, results.Folders[i]), FolderData.Empty);
				}
			}
			OnFolderProcessed(results.FullPath, true);
			//OnJobComplete(results.FullPath, JobBuffer.Peek().Recurse);
			if (CurrentJobBuffer.Count > 0) { // finished a sub-job
				indexingWorker.RunWorkerAsync(new BWArgs(CurrentJobBuffer.Dequeue(), JobBuffer.Peek().Recurse));
			} else { //main job is done
				OnJobComplete(JobBuffer.Peek().Path, JobBuffer.Peek().Recurse);
				cancel = false;
				JobBuffer.Dequeue();
				if (JobBuffer.Count > 0) indexingWorker.RunWorkerAsync(new BWArgs(JobBuffer.Peek().Path, JobBuffer.Peek().Recurse));
			}
		}
		void bw_DoWork(object sender, DoWorkEventArgs e) {
			BWArgs args = (BWArgs)e.Argument;
			BWResults results;
			DirectoryInfo di;
			try {
				di = new DirectoryInfo(args.FullPath);
			} catch {
				e.Result = new BWResults(null, null, args.FullPath, false);
				return;
			}
			//if (di.Exists) {
			FolderData fd = new FolderData(di);
			string[] d = null;
			try {
				d = Directory.GetDirectories(di.FullName);
			} catch { d = StringUtil.Empty; }
			for (int i = 0; i < d.Length; i++) d[i] = d[i].Substring(d[i].LastIndexOf(Path.DirectorySeparatorChar) + 1);
			results = new BWResults(fd, d, args.FullPath, di.Exists);
			//} else {
			//results = new BWResults(fd, StringUtil.Empty, args.FullPath, false);
			//}
			e.Result = results;
		}

		class BWArgs {
			internal string FullPath;
			internal bool Recurse;
			internal BWArgs(string fullPath, bool recurse) {
				FullPath = fullPath;
				Recurse = recurse;
			}
		}
		class BWResults {
			internal string FullPath;
			internal FolderData FD;
			internal string[] Folders;
			internal bool Exists = true;
			internal BWResults(FolderData fd, string[] folders, string fullPath, bool exists) {
				FD = fd;
				Folders = folders;
				FullPath = fullPath;
				Exists = exists;
			}
		}
		#endregion


		Dictionary<string, FileSystemWatcher> watchers = new Dictionary<string, FileSystemWatcher>(new IgnoreCaseComparer());
		internal Tree<FolderData> DataStore {
			get { return dataStore; }
		}

		internal HardDisk(BackgroundWorker indexer, BackgroundWorker searcher) {
			dataStore = new Tree<FolderData>(FolderData.Empty, new IgnoreCaseComparer());
			indexingWorker = indexer;
			searchWorker = searcher;
			indexingWorker = new BackgroundWorker();
			indexingWorker.WorkerSupportsCancellation = true;
			indexingWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
			indexingWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
			searchWorker = new BackgroundWorker();
			searchWorker.WorkerSupportsCancellation = true;
			searchWorker.DoWork += new DoWorkEventHandler(bw2_DoWork);
			searchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw2_RunWorkerCompleted);
		}
		void hdbw_JobComplete(string fullPath, bool recurse) {
			//FileSystemWatcher fsw = new FileSystemWatcher(fullPath);
			//fsw.IncludeSubdirectories = recurse;
			//fsw.NotifyFilter = NotifyFilters.FileName;
			//fsw.Created += new FileSystemEventHandler(fsw_Created);
			//fsw.Deleted += new FileSystemEventHandler(fsw_Deleted);
			//fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
			//watchers.Add(fullPath, fsw);
		}
		void fsw_Renamed(object sender, RenamedEventArgs e) {

		}
		void fsw_Deleted(object sender, FileSystemEventArgs e) {

		}
		void fsw_Created(object sender, FileSystemEventArgs e) {
			
		}


	}
	internal class IgnoreCaseComparer : IEqualityComparer<string> {
		public bool Equals(string x, string y) {
			return String.Equals(x, y, StringComparison.OrdinalIgnoreCase);
		}

		public int GetHashCode(string obj) {
			return obj.ToLower().GetHashCode();
		}
	}

}
