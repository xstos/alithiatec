using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FolderListing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            FileDragDropHandler fddh = new FileDragDropHandler(dataGridView1);
            fddh.FilesDropped += fddh_FilesDropped;
            FileDragDropHandler fddhCopyTo = new FileDragDropHandler(toolStripTextBox1.TextBox);
            fddhCopyTo.FilesDropped +=FddhCopyToOnFilesDropped;
        }

        private void FddhCopyToOnFilesDropped(string[] files)
        {
            toolStripTextBox1.Text = files.FirstOrDefault() ?? @"c:\temp";
        }

        private List<FileInfo> dataSrc = new List<FileInfo>();
        private List<FileInfo> dataSrcFiltered = new List<FileInfo>();
        //class fullPath
        //{
        //    public fullPath(string fullPath)
        //    {
        //        FullPath = fullPath;
        //    }

        //    public string FullPath { get; set; }
        //    public override string ToString()
        //    {
        //        return FullPath;
        //    }
        //}
        void fddh_FilesDropped(string[] files)
        {
            var folders = files.Where(util.IsFolder).ToList();
            
            var result = new List<string>();
            foreach (var folder in folders)
            {
                util.DirSearch(folder, result);
            }

            var fileInfos = result.Select(fn => new FileInfo(fn)).ToList();
            dataSrc = fileInfos;
            dataGridView1.DataSource = dataSrc;
            
        }

        void copy()
        {
            dataGridView1.SelectAll();
            var clipboardContent = dataGridView1.GetClipboardContent();
            Clipboard.SetDataObject(clipboardContent);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            copy();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IDataObject objectSave = Clipboard.GetDataObject();
            copy();

            var tmp = Path.GetTempFileName() + ".csv";
            File.WriteAllText(tmp, Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
            // Restore the current state of the clipboard so the effect is seamless
            if (objectSave != null) // If we try to set the Clipboard to an object that is null, it will throw...
            {
                Clipboard.SetDataObject(objectSave);
            }
            Process.Start(tmp);
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            var on = textBoxFilterField.Text;
            var set = new HashSet<string>(textBoxFilter.Lines,StringComparer.OrdinalIgnoreCase);
            var type = typeof(FileInfo);
            var prop = type.GetProperty(on);
            var filtered = dataSrc.Where(fi => set.Contains(prop.GetValue(fi, null))).ToList();
            dataSrcFiltered = filtered;
            dataGridView1.DataSource = dataSrcFiltered;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            foreach (var fileInfo in dataSrc)
            {
                
            }
        }
    }
}
