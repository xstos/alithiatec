using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AlithiaLib;
namespace FolderPortal {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			
			AlithiaLib.Shell.FileDragDropHandler fddh= new AlithiaLib.Shell.FileDragDropHandler(listBox1);
			fddh.FilesDropped += new Shell.FileDragDropHandler.DragDropOccured(fddh_FilesDropped);
			Properties.Settings.Default.Upgrade();
			LoadList();
			if (Properties.Settings.Default.Hidden) Tray();
		}

		void fddh_FilesDropped(string[] files) {
			for (int i = 0; i < files.Length; i++) {
				if (Directory.Exists(files[i])) {
					AddFolder(files[i]);
					continue;
				}
				string s=Path.GetDirectoryName(files[i]);
				if (Directory.Exists(s)) AddFolder(s);
			}
			SaveList();
			Properties.Settings.Default.Save();
		}
		void LoadList() {
			string[] split = Properties.Settings.Default.Folders.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < split.Length; i++) {
				AddFolder(split[i]);
			}
		}
		void SaveList() {
			Properties.Settings.Default.Folders = string.Join("\r\n", GetItems());
			Properties.Settings.Default.Save();
		}
		void AddFolder(string folder) {
			listBox1.Items.Add(folder);
			ToolStripItem t = contextMenuStrip1.Items.Add(folder);
			t.Click += new EventHandler(Folder_Click);
		}
		void RemoveFolder(string folder) {
			contextMenuStrip1.Items.RemoveByKey(folder);
		}
		void Folder_Click(object sender, EventArgs e) {
			ToolStripItem t = sender as ToolStripItem;
			try {
				System.Diagnostics.Process.Start(t.Text);
			} catch { }
		}
		
		string[] GetItems() {
			string[] items = new string[listBox1.Items.Count];
			for (int i = 0; i < listBox1.Items.Count; i++) {
				items[i] = listBox1.Items[i].ToString();
			}
			return items;
		}
		private void button2_Click(object sender, EventArgs e) {
			if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
			if (Directory.Exists(folderBrowserDialog1.SelectedPath)) {
				AddFolder(folderBrowserDialog1.SelectedPath);
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			for (int i = 0; i < listBox1.Items.Count; i++) {
				if (listBox1.GetSelected(i)) 
					RemoveFolder(listBox1.Items[i].ToString());
			}
			AlithiaLib.Forms.RemoveSelectedListboxItems(listBox1);
			SaveList();
		}
		protected override void OnKeyUp(KeyEventArgs e) {
			if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control) {
				for (int i = 0; i < listBox1.Items.Count; i++) {
					listBox1.SetSelected(i, true);
				}
			} else if (e.KeyCode == Keys.Delete) 
				button1_Click(null, null);
			base.OnKeyUp(e);
		}

		private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;
			if (Visible) Tray();
			else UnTray();
		}
		void Tray() {
			this.Hide();
			Properties.Settings.Default.Hidden = true;
			Properties.Settings.Default.Save();
		}
		void UnTray() {
			this.Show();
			Properties.Settings.Default.Hidden = false;
			Properties.Settings.Default.Save();
		}
		private void editListToolStripMenuItem_Click(object sender, EventArgs e) {
			UnTray();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Quit();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Tray();
		}

		void Quit() {
			SaveList();
			this.Dispose();
		}
		private void button3_Click_1(object sender, EventArgs e) {
			MessageBox.Show("FolderPortal v1.0 by AlithiaTec Consulting - www.alithiatec.com\n\nFolderPortal allows you to add an easy-to-access list of folders to the system tray.\n\nInstructions:\n1) Drag files/folders into the window or press the \"Add Folder\" button\n2) \"Hide\" the application to the system tray\n3) Right-click the little gear icon in the system tray to see the list of folders you added and then click one to open it.\n\nNote: FolderPortal automatically saves the list every time it is changed so your folders aren't lost when you quit!");
		}

		private void button5_Click(object sender, EventArgs e) {
			Tray();
		}

		private void button4_Click(object sender, EventArgs e) {
			Quit();
		}

		private void Form1_Load(object sender, EventArgs e) {
			try {
				this.Size = Properties.Settings.Default.Size;
			} catch { }
			this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			try {
				System.Diagnostics.Process.Start(linkLabel1.Tag.ToString());
			} catch { }
		}

		private void Form1_ResizeEnd(object sender, EventArgs e) {
			Properties.Settings.Default.Size = this.Size;
			Properties.Settings.Default.Save();
		}

		private void Form1_Move(object sender, EventArgs e) {
			
		}

		private void restoreDefaultsToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to restore the application to its state when first run?", "Restore Defaults?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				Properties.Settings.Default.Reset();
				Program.restart = true;
				this.Dispose();
			}
		}

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
			try {
				System.Diagnostics.Process.Start(listBox1.SelectedItem.ToString());
			} catch { }
		}
	}
}