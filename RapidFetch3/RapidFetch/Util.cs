using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Reflection;
using IWshRuntimeLibrary;
namespace RapidFetch {
	internal class Win32 {
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		struct SHFILEINFO {
			internal IntPtr hIcon;
			internal IntPtr iIcon;
			internal uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			internal string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			internal string szTypeName;
		};
		[DllImport("shell32.dll")]
		static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
		//public static System.Drawing.Icon GetSmallFileIcon(string fileName) {
		//    if (!System.IO.File.Exists(fileName)) return null;
		//    IntPtr hImgSmall;    //the handle to the system image list
		//    SHFILEINFO shinfo = new SHFILEINFO();
		//    hImgSmall = SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
		//    return System.Drawing.Icon.FromHandle(shinfo.hIcon);
		//}
		//public static System.Drawing.Icon GetLargeFileIcon(string fileName) {
		//    if (!System.IO.File.Exists(fileName)) return null;
		//    IntPtr hImgLarge;    //the handle to the system image list
		//    SHFILEINFO shinfo = new SHFILEINFO();
		//    hImgLarge = SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
		//    return System.Drawing.Icon.FromHandle(shinfo.hIcon);
		//}
		//struct SHFILEINFO {
		//    public IntPtr hIcon;
		//    public int iIcon;
		//    public int dwAttributes;
		//    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		//    public string szDisplayName;
		//    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		//    public string szTypeName;
		//}

		[Flags]
		enum FileInfoFlags : uint {
			SHGFI_ICON = 0x000000100,     // get icon
			SHGFI_DISPLAYNAME = 0x000000200,     // get display name
			SHGFI_TYPENAME = 0x000000400,     // get type name
			SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
			SHGFI_ICONLOCATION = 0x000001000,     // get icon location
			SHGFI_EXETYPE = 0x000002000,     // return exe type
			SHGFI_SYSICONINDEX = 0x000004000,     // get system icon index
			SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon
			SHGFI_SELECTED = 0x000010000,     // show icon in selected state
			SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes
			SHGFI_LARGEICON = 0x000000000,     // get large icon
			SHGFI_SMALLICON = 0x000000001,     // get small icon
			SHGFI_OPENICON = 0x000000002,     // get open icon
			SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon
			SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
			SHGFI_USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute
			SHGFI_ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays
			SHGFI_OVERLAYINDEX = 0x000000040,     // Get the index of the overlay in 
			// the upper 8 bits of the iIcon
		}

		internal struct ShellFileInfo {
			internal Bitmap Large;
			internal Bitmap Small;
			internal string DisplayName;
			internal string TypeName;
			internal ShellFileInfo(Bitmap large, Bitmap small, string displayName, string typeName) {
				Large = large;
				Small = small;
				DisplayName = displayName;
				TypeName = typeName;
			}
		}
		internal static ShellFileInfo GetShellFileInfo(string fullPath) {
			SHFILEINFO fis = new SHFILEINFO();

			//IntPtr h = SHGetFileInfo(fullPath, 0, out fis, (uint)Marshal.SizeOf(fis), (uint)(FileInfoFlags.SHGFI_ICON | FileInfoFlags.SHGFI_LARGEICON | FileInfoFlags.SHGFI_TYPENAME | FileInfoFlags.SHGFI_ATTR_SPECIFIED));
			IntPtr h = SHGetFileInfo(fullPath.ToLower(), 0, out fis, (uint)Marshal.SizeOf(fis), (uint)(FileInfoFlags.SHGFI_TYPENAME));
			//SHGetFileInfo(fullPath, 0, out fi, (uint)Marshal.SizeOf(fi), (uint)(FileInfoFlags.SHGFI_ICON | FileInfoFlags.SHGFI_LARGEICON));
			Bitmap s;
			//if (fi.hIcon == IntPtr.Zero)
			//    l = null;
			//else {
			//    try { l = (Icon.FromHandle(fi.hIcon)).ToBitmap(); } catch (Exception ex) { l = null; Console.WriteLine(ex); }
			//}
			if (fis.hIcon == IntPtr.Zero)
				s = null;
			else {
				try { s = (Icon.FromHandle(fis.hIcon)).ToBitmap(); } catch (Exception ex) { s = null; Console.WriteLine(ex); }
			}
			return new ShellFileInfo(null, s, fis.szDisplayName, fis.szTypeName);
		}
		internal static void ShellExecute(string fullPath) {
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.EnableRaisingEvents = false;
			proc.StartInfo.UseShellExecute = true;
			proc.StartInfo.FileName = fullPath; ;
			try { proc.Start(); } catch { }
		}
		internal static void CutToClipboard(string[] fullPaths) {
			IDataObject data = new DataObject(DataFormats.FileDrop, fullPaths);
			MemoryStream memo = new MemoryStream(4);
			byte[] bytes = new byte[] { 2, 0, 0, 0 };
			memo.Write(bytes, 0, bytes.Length);
			data.SetData("Preferred DropEffect", memo);
			//Place our objects on the clipboard
			Clipboard.SetDataObject(data, true);
		}
		internal static void CutToClipboard(string fullPath) {
			CutToClipboard(new string[] { fullPath });
		}
		internal static void CopyToClipboard(string[] fullPaths) {
			IDataObject data = new DataObject(DataFormats.FileDrop, fullPaths);
			MemoryStream memo = new MemoryStream(4);
			byte[] bytes = new byte[] { 5, 0, 0, 0 };
			memo.Write(bytes, 0, bytes.Length);
			data.SetData("Preferred DropEffect", memo);
			//Place our objects on the clipboard
			Clipboard.SetDataObject(data, true);
		}
		internal static void CopyToClipboard(string fullPath) {
			CopyToClipboard(new string[] { fullPath });
		}
		internal static string GetShortcutTargetFile(string shortcutFilename) {
			string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
			string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

			Shell32.Shell shell = new Shell32.ShellClass();
			Shell32.Folder folder = shell.NameSpace(pathOnly);
			Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
			if (folderItem != null) {

				Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
				return link.Path;
			}
			return ""; // not found
		}
		internal static void SaveShortcut(string targetfullPath, string saveLocationFullPath) {
			try {
				WshShell shell = new WshShell();
				IWshShortcut link = (IWshShortcut)shell.CreateShortcut(saveLocationFullPath);
				link.TargetPath = targetfullPath;
				link.Description = "RapidFetch";
				link.Save();
			} catch (Exception e) { MessageBox.Show("Error saving link\n" + e); }
		}
		internal enum SpecialFolder {
			AllUsersDesktop,
			AllUsersStartMenu,
			AllUsersPrograms,
			AllUsersStartup,
			Desktop,
			Favorites,
			Fonts,
			MyDocuments,
			NetHood,
			PrintHood,
			Programs,
			Recent,
			SendTo,
			StartMenu,
			Startup,
			Templates
		}
		internal static string GetSpecialFolder(SpecialFolder sf) {
			string s="";
			try {
				WshShell shell = new WshShellClass();
				object ss=Enum.GetName(typeof(SpecialFolder),sf);
				s=shell.SpecialFolders.Item(ref ss).ToString();
			} catch (Exception e) { MessageBox.Show("SpecialFolder error" + e); }
			return s;
		}
		[DllImport("user32.dll")]
		static extern bool GetCursorPos(ref Point lpPoint);
		internal static Point GetCursorPos() {
			Point p = new Point();
			GetCursorPos(ref p);
			return p;
		}
	}
	internal class StringUtil {
		internal static string[] ToLower(string[] input) {
			if (input == null) return null;
			string[] temp = new string[input.Length];
			for (int i = 0; i < input.Length; i++) temp[i] = input[i].ToLower();
			return temp;
		}
		private static string[] empty = new string[] { };
		internal static string[] Empty {
			get { return empty; }
			set { empty = value; }
		}
	}

	internal delegate void DragDropOccured(string[] files);
	internal class FileDragDropHandler {
		internal event DragDropOccured FilesDropped;
		internal FileDragDropHandler(Control c) {
			c.AllowDrop = true;
			c.DragEnter += new DragEventHandler(c_DragEnter);
			c.DragDrop += new DragEventHandler(c_DragDrop);
		}
		void c_DragDrop(object sender, DragEventArgs e) {
			try {
				String[] a = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (a != null) {
					if (FilesDropped != null) FilesDropped(a);
				}
			} catch (Exception ex) {
				Console.WriteLine("Error in DragDropManager.OnDragDrop function: " + ex.Message);
			}
		}
		void c_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}
	}

	internal class SearchStrings : System.Collections.ObjectModel.ReadOnlyCollection<string> {
		internal SearchStrings(string text)
			: base(new List<string>()) {
			bool phraseMode = false;
			text = text.Replace("\"", " \" ");
			char[] chars = text.ToCharArray();
			List<StringBuilder> phrases = new List<StringBuilder>();
			StringBuilder words = new StringBuilder();//space delimited search words
			StringBuilder phrase = new StringBuilder();
			for (int i = 0; i < chars.Length; i++) {
				if (chars[i] != '\"') { //see a non quote char
					if (!phraseMode) { //most common case
						words.Append(chars[i]);
					} else {
						phrase.Append(chars[i]);
					}

				} else { //see a quote character
					if (!phraseMode) { //word -> phrase mode
						words = new StringBuilder(words.ToString().Trim());
						words.Append(" ");
					} else { //phrase -> word mode
						//the chars were going into phrase
						//so check if phrase has anything and stick it into phrases
						if (!String.IsNullOrEmpty(phrase.ToString())) {
							phrases.Add(phrase);
							phrase = new StringBuilder(); //reinit
						}
					}
					phraseMode = !phraseMode;
				}
			}
			if (!String.IsNullOrEmpty(phrase.ToString().Trim())) phrases.Add(phrase);
			List<string> search = new List<string>();
			string[] t = words.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			search.AddRange(t);
			for (int i = 0; i < phrases.Count; i++) {
				search.Add(phrases[i].ToString().Trim());
			}
			for (int i = 0; i < search.Count; i++) {
				base.Items.Add(search[i]);
			}
		}
		internal string[] ToArray() {
			string[] temp = new string[base.Count];
			for (int i = 0; i < base.Count; i++) {
				temp[i] = base[i];
			}
			return temp;
		}
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < base.Items.Count; i++) {
				sb.Append("{");
				sb.Append(base.Items[i]);
				sb.Append("}");
				sb.Append(",");
			}
			if (sb.Length > 0) sb.Length--;
			return sb.ToString();
		}
		public static implicit operator string(SearchStrings ss) {
			return ss.ToString();
		}
	}
}
