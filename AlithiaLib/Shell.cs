using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
namespace AlithiaLib {
	public class Shell {

		public class FileDragDropHandler {
			public delegate void DragDropOccured(string[] files);
			public event DragDropOccured FilesDropped;
			public FileDragDropHandler(Control c) {
				c.AllowDrop = true;
				c.DragEnter += new DragEventHandler(c_DragEnter);
				c.DragDrop += new DragEventHandler(c_DragDrop);
			}
			void c_DragDrop(object sender, DragEventArgs e) {
				try {
					string[] a = (string[])e.Data.GetData(DataFormats.FileDrop);
					if (a != null) {
						if (FilesDropped != null) FilesDropped(a);
					}
				} catch {
					throw;
				}
			}
			void c_DragEnter(object sender, DragEventArgs e) {
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
					e.Effect = DragDropEffects.Copy;
				else e.Effect = DragDropEffects.None;
			}
		}
		public static void ShellExecute(string fullPath) {
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.EnableRaisingEvents = false;
			proc.StartInfo.UseShellExecute = true;
			proc.StartInfo.FileName = fullPath; ;
			try { proc.Start(); } catch (Exception ex) { Errors.OnException(ex); }
		}
		public static void CutToClipboard(string[] fullPaths) {
			try {
				IDataObject data = new DataObject(DataFormats.FileDrop, fullPaths);
				MemoryStream memo = new MemoryStream(4);
				byte[] bytes = new byte[] { 2, 0, 0, 0 };
				memo.Write(bytes, 0, bytes.Length);
				data.SetData("Preferred DropEffect", memo);
				//Place our objects on the clipboard
				Clipboard.SetDataObject(data, true);
			} catch (Exception ex) { Errors.OnException(ex); }
		}
		public static void CutToClipboard(string fullPath) {
			CutToClipboard(new string[] { fullPath });
		}
		public static void CopyToClipboard(string[] fullPaths) {
			try {
				IDataObject data = new DataObject(DataFormats.FileDrop, fullPaths);
				MemoryStream memo = new MemoryStream(4);
				byte[] bytes = new byte[] { 5, 0, 0, 0 };
				memo.Write(bytes, 0, bytes.Length);
				data.SetData("Preferred DropEffect", memo);
				//Place our objects on the clipboard
				Clipboard.SetDataObject(data, true);
			} catch (Exception ex) { Errors.OnException(ex); }
		}
		public static void CopyToClipboard(string fullPath) {
			CopyToClipboard(new string[] { fullPath });
		}
		public enum IconSize : uint {
			Large = 0x0,  //32x32
			Small = 0x1 //16x16        
		}
		struct SHFILEINFO {
			internal IntPtr hIcon;
			internal IntPtr iIcon;
			internal uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			internal string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			internal string szTypeName;
		};
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		extern static bool DestroyIcon(IntPtr handle);
		[DllImport("shell32.dll")]
		static extern IntPtr SHGetFileInfo(
			string pszPath,                //path
			uint dwFileAttributes,        //attributes
			ref SHFILEINFO psfi,        //struct pointer
			uint cbSizeFileInfo,        //size
			uint uFlags);    //flags
		const uint SHGFI_ICON = 0x100;
		const uint SHGFI_USEFILEATTRIBUTES = 0x10;
		const uint SHGFI_TYPENAME = 0x400;
		const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
		const uint FILE_ATTRIBUTE_NORMAL = 0x80;
		public static Icon IconFromFileName(string fullPath, IconSize Size) {
			Icon TempIcon;
			SHFILEINFO TempFileInfo = new SHFILEINFO();
			FileInfo fi = new FileInfo(fullPath);
			if ((fi.Attributes & FileAttributes.Directory) == fi.Attributes)
				SHGetFileInfo(fullPath, (uint)FILE_ATTRIBUTE_DIRECTORY, ref TempFileInfo, (uint)Marshal.SizeOf(TempFileInfo), SHGFI_ICON | (uint)Size);
			else
				SHGetFileInfo(fullPath, (uint)FILE_ATTRIBUTE_NORMAL, ref TempFileInfo, (uint)Marshal.SizeOf(TempFileInfo), SHGFI_ICON | (uint)Size);
			if (TempFileInfo.hIcon != IntPtr.Zero) {
				TempIcon = (Icon)Icon.FromHandle(TempFileInfo.hIcon);
				return GetManagedIcon(ref TempIcon);
			} else {
				return null;
			}
		}
		internal static Icon GetManagedIcon(ref Icon UnmanagedIcon) {
			Icon ManagedIcon = (Icon)UnmanagedIcon.Clone();

			DestroyIcon(UnmanagedIcon.Handle);

			return ManagedIcon;
		}
	}
}
