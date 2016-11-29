using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RapidFetch {
	internal partial class Cache : Form {
		internal Cache() {
			InitializeComponent();
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			
			
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			e.Node.ExpandAll();
			listView1.Items.Clear();
			FolderData fd = (FolderData)e.Node.Tag;
			if (fd.Files != null) {
				for (int i = 0; i < fd.Files.Length; i++) {
					listView1.Items.Add(fd.Files[i].FileName);
				}
			}
		}

		private void Cache_Load(object sender, EventArgs e) {
			this.Icon = Properties.Resources.rf_icon_v2;
		}
	}
}