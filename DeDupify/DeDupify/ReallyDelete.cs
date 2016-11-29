using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeDupify {
	public partial class ReallyDelete : Form {
		public ReallyDelete() {
			InitializeComponent();
		}
		public BindingList<System.IO.FileInfo> Files = new BindingList<System.IO.FileInfo>();
		private void ReallyDelete_Load(object sender, EventArgs e) {
			uiBtnNo.Focus();
			uiLBFiles.DataSource = Files;
		}

		private void uiBtnYes_Click(object sender, EventArgs e) {
			
		}
	}
}