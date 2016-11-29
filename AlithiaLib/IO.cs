using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace AlithiaLib {
	public class IO {
		public static bool PathsAreEqual(string path1, string path2) {
			if (path1 == null | path2 == null) return false;
			return String.Equals(path1.TrimEnd(System.IO.Path.DirectorySeparatorChar), path2.TrimEnd(System.IO.Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase);
		}
		public sealed class Path : IEquatable<Path> {
			string path = "";
			public Path() { }
			public Path(string path) {
				this.path = path;
			}
			public static implicit operator string(Path p) {
				return p.ToString();
			}
			public override string ToString() {
				return path.ToString();
			}
			public override bool Equals(object obj) {
				return PathsAreEqual(this, obj.ToString());
			}
			public override int GetHashCode() {
				return path.ToLower().GetHashCode();
			}
			#region IEquatable<Path> Members

			public bool Equals(Path other) {
				return PathsAreEqual(this, other);
			}

			#endregion
		}
		public sealed class DiskCache {
			public delegate void LoadCompleteDelegate(DirectoryInfo[] folders, FileInfo[] files);
			public event LoadCompleteDelegate LoadComplete;
			Queue<Path> queuedFolders = new Queue<Path>();
			List<FileInfo> files = new List<FileInfo>();
			List<DirectoryInfo> folders = new List<DirectoryInfo>();
			BackgroundWorker bw = new BackgroundWorker();
			private bool recursive = true;
			public bool Recursive {
				get { return recursive; }
				set { recursive = value; }
			}
			public ReadOnlyCollection<FileInfo> Files {
				get { return files.AsReadOnly(); }
			}
			public ReadOnlyCollection<DirectoryInfo> Folders {
				get { return folders.AsReadOnly(); }
			}
			public DiskCache() {
				bw.DoWork += new DoWorkEventHandler(bw_DoWork);
				bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
			}

			void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
				if (queuedFolders.Count > 0)
					bw.RunWorkerAsync(queuedFolders.Dequeue());
				else
					if (LoadComplete != null)
						LoadComplete(folders.ToArray(), files.ToArray());
			}

			void bw_DoWork(object sender, DoWorkEventArgs e) {
				try {
					Path p = e.Argument as Path;
					Queue<DirectoryInfo> foldersLeft = new Queue<DirectoryInfo>();
					DirectoryInfo di;
					try { di = new DirectoryInfo(p); } catch { return; }
					foldersLeft.Enqueue(di);
					while (foldersLeft.Count > 0) {
						di = foldersLeft.Dequeue();
						folders.Add(di);
						try {
							files.AddRange(di.GetFiles());
						} catch { }
						if (recursive) {
							DirectoryInfo[] infos;
							try {
								infos = di.GetDirectories();
							} catch { infos = new DirectoryInfo[0]; }
							for (int i = 0; i < infos.Length; i++) {
								foldersLeft.Enqueue(infos[i]);
							}
						}
					}
				} catch (Exception ex) { Errors.OnException(ex); }
			}
			public void Load(string path) {
				Path p = new Path(path);
				if (!bw.IsBusy) { bw.RunWorkerAsync(p); } else queuedFolders.Enqueue(p);
			}

		}
		public static byte[] ByteSample(Stream s, long numBytes) {
			byte[] result = new byte[0];
			try {
				if (numBytes <= 0) return new byte[0];
				long len = s.Length;
				long blockLen = len / numBytes;
				long midBlockLen = blockLen / 2;
				result = new byte[numBytes];
				long pos;
				BinaryReader br = new BinaryReader(s);
				for (long i = 0; i < numBytes; i++) {
					pos = (i + 1) * blockLen - midBlockLen;
					s.Position = pos;
					result[i] = br.ReadByte();
				}
			} catch (Exception ex) { Errors.OnException(ex); }
			return result;
		}
		public static byte[] MD5HashSample(string path, long numBytes) {
			try {
				using (FileStream fs = new FileStream(path, FileMode.Open)) {
					return MD5Hash(ByteSample(fs, numBytes));
				}
			} catch (Exception ex) { Errors.OnException(ex); }
			return new byte[0];
		}
		public static byte[] MD5Hash(byte[] array) {
			return new MD5CryptoServiceProvider().ComputeHash(array);
		}
		public static byte[] MD5Hash(Stream s) {
			return new MD5CryptoServiceProvider().ComputeHash(s);
		}
		public static byte[] MD5HashFile(string path) {
			try {
				using (FileStream fs = new FileStream(path, FileMode.Open)) {
					return MD5Hash(fs);
				}
			} catch (Exception ex) { Errors.OnException(ex); }
			return new byte[0];

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="rethrows IO.FileNotFound and textreader"></exception>
		public static string TextFileToString(string path) {
			try {
				using (FileStream fs = new FileStream(path, FileMode.Open)) {
					TextReader tr = new StreamReader(fs);
					return tr.ReadToEnd();
				}
			} catch (Exception ex) { Errors.OnException(ex); }
			return "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="content"></param>
		/// <exception cref="Re-throws FileStream, TextWriter"></exception>
		public static void StringToTextFile(string path, string content) {
			try {
				using (FileStream fs = new FileStream(path, FileMode.Create)) {
					TextWriter tw = new StreamWriter(fs);
					tw.Write(content);
					tw.Flush();
				}
			} catch (Exception ex) { Errors.OnException(ex); }
		}
		public static string[][] ParseDelimitedText(string text, string delimiter) {
			try {
				string[][] result;
				string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				result = new string[lines.Length][];
				for (int i = 0; i < lines.Length; i++) {
					result[i] = lines[i].Split(new string[] { delimiter }, StringSplitOptions.None);
				}
				return result;
			} catch (Exception ex) { Errors.OnException(ex); }
			return new string[0][];
		}
		public static void stringToStream(Stream s, string str) {
			StreamWriter sw = new StreamWriter(s);
			sw.Write(str);
			sw.Flush();
			s.Seek(0, SeekOrigin.Begin);
		}
		public static string streamToString(Stream s) {
			s.Seek(0, SeekOrigin.Begin);
			TextReader tr = new StreamReader(s);
			string res = tr.ReadToEnd();
			s.Seek(0, SeekOrigin.Begin);
			return res;
		}
		public static byte[] ReadStreamToBufferBlind(Stream s, int bufferLen) {
			byte[] buffer = new byte[bufferLen];
			int length;
			List<byte[]> bytes = new List<byte[]>();
			length = s.Read(buffer, 0, bufferLen);

			while (length > 0) {
				if (length == buffer.Length) bytes.Add(buffer);
				else {
					Array.Resize<byte>(ref buffer, length);
					bytes.Add(buffer);
				}
				buffer = new byte[bufferLen];
				length = s.Read(buffer, 0, bufferLen);
			}
			long len = 0;
			for (int i = 0; i < bytes.Count; i++) {
				len += bytes[i].Length;
			}
			byte[] wholeStream = new byte[len];
			len = 0;
			for (int i = 0; i < bytes.Count; i++) {
				Array.Copy(bytes[i], 0, wholeStream, len, bytes[i].Length);
				len += bytes[i].Length;
			}
			return wholeStream;
		}
		public static string ReadStreamToString(Stream s, int bufferLen) {
			byte[] b = ReadStreamToBufferBlind(s, bufferLen);
			System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
			return enc.GetString(b);
		}
		/// <summary>
		/// Advances the position of the stream immediately after the next occurence of <paramref name="text"/>. If <paramref name="text"/> is null or empty the stream doesn't advance, if no string is found the stream pos is EOS as a side effect .
		/// </summary>
		/// <param name="s"></param>
		/// <param name="text"></param>
		/// <param name="encoding"></param>
		/// <returns>true if a string was found, false if not found</returns>
		public static byte[] GetBytes(Stream s) {
			BinaryReader br = new BinaryReader(s);
			return br.ReadBytes((int)s.Length);
		}
		public static bool FindString(BinaryReader br, char[] chars) {
			
				//if (string.IsNullOrEmpty(text)) return false;
				int i = 0;
				char cur;
				int charlen = chars.Length;
				long l = br.BaseStream.Length,pos=br.BaseStream.Position;
				while (pos<l) {
					cur = br.ReadChar();
					pos++;
					if (cur == chars[i]) 
						i++;
					else i = 0;
					if (i == charlen) 
						return true;
				}
				return false;
			
			
		}
	}
}
