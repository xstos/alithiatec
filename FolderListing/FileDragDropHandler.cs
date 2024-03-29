﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FolderListing
{
    public class FileDragDropHandler
    {
        public delegate void DragDropOccured(string[] files);
        public event DragDropOccured FilesDropped;
        public FileDragDropHandler(Control c)
        {
            c.AllowDrop = true;
            c.DragEnter += new DragEventHandler(c_DragEnter);
            c.DragDrop += new DragEventHandler(c_DragDrop);
        }
        void c_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] a = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (a != null)
                {
                    if (FilesDropped != null) FilesDropped(a);
                }
            }
            catch
            {
                throw;
            }
        }
        void c_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }
    }
}
