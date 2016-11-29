using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.Globalization;
using System.ComponentModel;
namespace AlithiaLib {
	public class AppUpdater {
		BackgroundWorker bw = new BackgroundWorker();
		public AppUpdater(string url, DateTime createDate, string appName,bool silent) {
			try {
				if (CheckForFileUpdate(url, createDate)) {
					string name = System.Reflection.Assembly.GetEntryAssembly().Location;
					FileInfo fi = new FileInfo(name);
					if (MessageBox.Show("A new version of " + appName + " is available. Update now?", "Web Updater", MessageBoxButtons.YesNo) == DialogResult.Yes) {
						FileInfo fiNew = new FileInfo(fi.FullName + ".upgrade");
						try {
							fiNew.Delete();
						} catch { }
						CopyStreamToDisk(LoadFile(url), fi.FullName + ".upgrade");
						FileInfo fiOld = new FileInfo(fi.FullName + ".bak");
						try {
							fiOld.Delete();
						} catch { }
						fi.MoveTo(fi.FullName + ".bak");
						FileInfo fi2 = new FileInfo(name + ".upgrade");
						fi2.MoveTo(name);
						MessageBox.Show(appName + " updated successfully. Changes will take effect the next time the application is restarted.", "Web Updater", MessageBoxButtons.OK);
					}
				} else {
					if (!silent)
					MessageBox.Show("Your version is up to date");
				}
			} catch (Exception ex) {
				MessageBox.Show("Error updating " + appName + "\n" + ex.Message, "Web Updater Error", MessageBoxButtons.OK);
			}
		}
		public static bool CheckForFileUpdate(string url, DateTime lastModTime) {
			try {
				string dateUrl = url + ".txt";
				Stream s= LoadFile(dateUrl);

				string info = IO.ReadStreamToString(s, 5);
				info = new StringReader(info).ReadLine();
				DateTime lastUp = DateTime.Parse(info);
				int res = DateTime.Compare(lastUp, lastModTime);
				return res > 0;
			} catch { return false; }
		}
		public static DateTime GetLastModTime(string url) {
			HttpWebResponse Response;

			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			Request.Method = "HEAD";

			try {
				Response = (HttpWebResponse)Request.GetResponse();
			} catch (WebException e) {
				Debug.WriteLine("Error accessing Url " + url);
				if (e.Response != null)
					e.Response.Close();
				throw;
			}

			DateTime d = System.Convert.ToDateTime(Response.GetResponseHeader("Last-Modified"));
			return d;

		}
		public static Stream LoadFile(string url) {
			HttpWebResponse Response;
			//Retrieve the File
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			try {
				Response = (HttpWebResponse)Request.GetResponse();
			} catch (WebException) {
				Debug.WriteLine("Error accessing Url " + url);
				throw;
			}
			return Response.GetResponseStream();
		}
		
		private static void CopyStreamToDisk(Stream responseStream, String filePath) {
			byte[] buffer = new byte[4096];
			int length;

			//Copy to a temp file first so that if anything goes wrong with the network
			//while downloading the file, we don't actually update the real on file disk
			//This essentially gives us transaction like semantics.
			Random Rand = new Random();
			string tempPath = Environment.GetEnvironmentVariable("temp") + "\\";
			tempPath += filePath.Remove(0, filePath.LastIndexOf("\\") + 1);
			tempPath += Rand.Next(10000).ToString() + ".tmp";

			FileStream AFile = File.Open(tempPath, FileMode.Create, FileAccess.ReadWrite);

			length = responseStream.Read(buffer, 0, 4096);
			while (length > 0) {
				AFile.Write(buffer, 0, length);
				length = responseStream.Read(buffer, 0, 4096);
			}
			AFile.Close();

			if (File.Exists(filePath))
				File.Delete(filePath);
			File.Move(tempPath, filePath);
		}
		public static void CopyAndRename(string source, string dest) {
			string[] directories = Directory.GetDirectories(source);
			string[] files = Directory.GetFiles(source);
			string name;

			//If the directory doesn't exist, create it first
			if (!Directory.Exists(dest)) Directory.CreateDirectory(dest);

			foreach (string file in files) {
				name = file.Remove(0, file.LastIndexOf("\\") + 1);
				MessageBox.Show(name);

				if (File.Exists(dest + name)) File.Delete(dest + name);
				File.Move(file, dest + name);
			}

			foreach (string directory in directories) {
				name = directory.Remove(0, directory.LastIndexOf("\\") + 1);
				MessageBox.Show(name);

				if (!Directory.Exists(dest + name + "\\"))
					Directory.CreateDirectory(dest + name + "\\");

				CopyAndRename(source + name + "\\", dest + name + "\\");
			}

			Directory.Delete(source, true);
		}

	}
}
