using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FolderListing
{
    class util
    {
        public static bool IsFolder(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            return attr.HasFlag(FileAttributes.Directory);
        }
        public static void DirSearch(string folder, List<string> result)
        {
            var dirs = Directory.GetDirectories(folder).ToList();
            result.AddRange(Directory.GetFiles(folder));
            foreach (string d in dirs)
            {
                var files = Directory.GetFiles(d);
                result.AddRange(files);
                DirSearch(d, result);
            }
            
        }
    }
}
