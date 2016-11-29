using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using System.IO;



namespace RapidFetch {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

	internal enum IconSize : uint {
		Large = 0x0,  //32x32
		Small = 0x1 //16x16        
	}

	//the function that will extract the icons from a file
	internal sealed class IconHandler {
		const uint SHGFI_ICON = 0x100;
		const uint SHGFI_USEFILEATTRIBUTES = 0x10;
		const uint SHGFI_TYPENAME = 0x400;
		const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
		const uint FILE_ATTRIBUTE_NORMAL = 0x80;
		[Flags]
		internal enum Attr : uint {
			FILE_ATTRIBUTE_DIRECTORY = 0x10,
			FILE_ATTRIBUTE_NORMAL = 0x80
		}
		[DllImport("Shell32", CharSet = CharSet.Auto)]
		internal extern static int ExtractIconEx(
			[MarshalAs(UnmanagedType.LPTStr)] 
            string lpszFile,       //size of the icon
			int nIconIndex,        //index of the icon 
			//(in case we have more 
			//then 1 icon in the file
			IntPtr[] phIconLarge,  //32x32 icon
			IntPtr[] phIconSmall,  //16x16 icon
			int nIcons);           //how many to get

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		//we need this function to release the unmanaged resource,
		//the unmanaged resource will be 
		//copies to a managed one and it will be returned.
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		extern static bool DestroyIcon(IntPtr handle);

		//will return an array of icons 
		internal static Icon[] IconsFromFile(string Filename, IconSize Size) {
			int IconCount = ExtractIconEx(Filename, -1, null, null, 0); //checks how many icons.
			IntPtr[] IconPtr = new IntPtr[IconCount];
			Icon TempIcon;

			//extracts the icons by the size that was selected.
			if (Size == IconSize.Small) ExtractIconEx(Filename, 0, null, IconPtr, IconCount);
			else ExtractIconEx(Filename, 0, IconPtr, null, IconCount);

			Icon[] IconList = new Icon[IconCount];

			//gets the icons in a list.
			for (int i = 0; i < IconCount; i++) {
				TempIcon = (Icon)Icon.FromHandle(IconPtr[i]);
				IconList[i] = GetManagedIcon(ref TempIcon);
			}

			return IconList;
		}

		//extract one selected by index icon from a file.
		internal static Icon IconFromFile(string Filename, IconSize Size, int Index) {
			int IconCount = ExtractIconEx(Filename, -1, null, null, 0); //checks how many icons.
			if (IconCount <= 0 || Index >= IconCount) return null; // no icons were found.

			Icon TempIcon;
			IntPtr[] IconPtr = new IntPtr[1];

			//extracts the icon that we want in the selected size.
			if (Size == IconSize.Small) ExtractIconEx(Filename, Index, null, IconPtr, 1);
			else ExtractIconEx(Filename, Index, IconPtr, null, 1);

			TempIcon = Icon.FromHandle(IconPtr[0]);

			return GetManagedIcon(ref TempIcon);
		}
		internal static Icon IconFromExtension(string Extension, IconSize Size, out string TypeName, Attr FileOrFolder) {
			try {
				Icon TempIcon;

				//add '.' if nessesry
				//if (Extension[0] != '.') Extension = '.' + Extension;

				//temp struct for getting file shell info
				SHFILEINFO TempFileInfo = new SHFILEINFO();

				SHGetFileInfo(Extension, (uint)FileOrFolder, ref TempFileInfo, (uint)Marshal.SizeOf(TempFileInfo), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | (uint)Size | SHGFI_TYPENAME);
				TypeName = TempFileInfo.szTypeName;
				TempIcon = (Icon)Icon.FromHandle(TempFileInfo.hIcon);
				return GetManagedIcon(ref TempIcon);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("error" + " while trying to get icon for " + Extension + " :" + e.Message);
				TypeName = "";
				return null;
			}
		}
		internal static Icon IconFromFileName(string fullPath, IconSize Size) {
			//try {
			Icon TempIcon;

			//add '.' if nessesry
			//if (Extension[0] != '.') Extension = '.' + Extension;

			//temp struct for getting file shell info
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
			//return null;
			//} catch (Exception e) {
			//	System.Diagnostics.Debug.WriteLine("error" + " while trying to get icon for " + fullPath + " :" + e.Message);
			//	return null;
			//}
		}
		internal static string TypeNameFromExtension(string ext, Attr FileOrFolder) {
			if (ext[0] != '.') ext = '.' + ext;
			SHFILEINFO TempFileInfo = new SHFILEINFO();
			SHGetFileInfo(ext, (uint)FileOrFolder, ref TempFileInfo, (uint)Marshal.SizeOf(TempFileInfo), SHGFI_USEFILEATTRIBUTES | SHGFI_TYPENAME);
			return TempFileInfo.szTypeName;
		}
		internal static Icon IconFromResource(string ResourceName) {
			Assembly TempAssembly = Assembly.GetCallingAssembly();

			return new Icon(TempAssembly.GetManifestResourceStream(ResourceName));
		}

		internal static void SaveIconFromImage(Image SourceImage, string IconFilename, IconSize DestenationIconSize) {
			Size NewIconSize = DestenationIconSize == IconSize.Large ? new Size(32, 32) : new Size(16, 16);

			Bitmap RawImage = new Bitmap(SourceImage, NewIconSize);
			Icon TempIcon = Icon.FromHandle(RawImage.GetHicon());
			FileStream NewIconStream = new FileStream(IconFilename, FileMode.Create);

			TempIcon.Save(NewIconStream);

			NewIconStream.Close();
		}

		internal static void SaveIcon(Icon SourceIcon, string IconFilename) {
			FileStream NewIconStream = new FileStream(IconFilename, FileMode.Create);

			SourceIcon.Save(NewIconStream);

			NewIconStream.Close();
		}

		internal static Icon GetManagedIcon(ref Icon UnmanagedIcon) {
			Icon ManagedIcon = (Icon)UnmanagedIcon.Clone();

			DestroyIcon(UnmanagedIcon.Handle);

			return ManagedIcon;
		}
	}
}
