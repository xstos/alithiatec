using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
/// <summary>
/// Summary description for Util
/// </summary>
public class Util {
	public Util() {
		//
		// TODO: Add constructor logic here
		//
	}
	public static string Escape(string html) {
		string res="\"";
		for (int i = 0; i < html.Length; i++) {
			if (html[i] == '\"') {
				res = string.Concat(res , "\\\"");
			} else {
				res = string.Concat(res, html[i]);
			}
		}
		return res+"\"";
	}
	public static bool FieldsEmpty(params string[] fields) {
		for (int i = 0; i < fields.Length; i++) {
			if (String.IsNullOrEmpty(fields[i])) return true;
		}
		return false;
	}
	public static string SendMail(string from, string to, string subject, string body) {
		MailMessage message = new MailMessage();
		try {
			message.From = new MailAddress(from);
		} catch {
			message.From = new MailAddress("anonymous@alithiatec.com");
		}
		message.To.Add(new MailAddress(to));
		message.Subject = subject;
		message.Body = body;
		SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
		client.Credentials = (System.Net.ICredentialsByHost)System.Net.CredentialCache.DefaultCredentials;
		client.DeliveryMethod = SmtpDeliveryMethod.Network;
		try {
			client.Send(message);
		} catch (Exception ex) { return ex.Message.ToString(); }
		return "Message was submitted successfully";
	}
	public class WebFileList {
		public class WebFileInfoWrapper {
			private FileInfo info;
			string root;
			public string NavigateUrl {
				get { return string.Concat(root, info.Name); }
			}
			public string Text {
				get { return info.Name; }
			}
			public string Size {
				get { return string.Format("{0:n0} Bytes", info.Length); }
			}
			public string Modified {
				get { return string.Format("{0}", info.LastWriteTime); }
			}
			public WebFileInfoWrapper(FileInfo info, string root) {
				this.info = info;
				if (root.EndsWith("/")) this.root = root;
				else this.root = root + "/";
			}

		}
		private string searchPatterns = "*.*";

		public string SearchPatterns {
			get { return searchPatterns; }
			set { searchPatterns = value; }
		}
		private string path = "~/";

		public string Path {
			get { return path; }
			set { path = value; }
		}
		List<WebFileInfoWrapper> fi = new List<WebFileInfoWrapper>();
		System.Web.UI.UserControl hostControl;
		public System.Collections.ObjectModel.ReadOnlyCollection<WebFileInfoWrapper> Files {
			get { return fi.AsReadOnly(); }
		}
		public void Read(System.Web.UI.UserControl hostControl) {
			this.hostControl = hostControl;
			Read();
		}
		public void Read() {
			if (hostControl != null) {
				if (string.IsNullOrEmpty(path)) path = "~/";
				path = hostControl.ResolveClientUrl(path);
				DirectoryInfo di = new DirectoryInfo(hostControl.Server.MapPath(path));

				if (string.IsNullOrEmpty(searchPatterns)) searchPatterns = "*.*";
				string[] pats = searchPatterns.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < pats.Length; i++) {
					foreach (FileInfo var in di.GetFiles(pats[i])) {
						fi.Add(new WebFileInfoWrapper(var, path));
					}
				}
			}
		}
		public WebFileList() {

		}
	}
}
