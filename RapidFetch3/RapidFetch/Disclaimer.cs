using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RapidFetch {
	internal partial class Disclaimer : Form {
		internal Disclaimer() {
			InitializeComponent();
		}
		
		private void accept_Click(object sender, EventArgs e) {
			
		}

		private void decline_Click(object sender, EventArgs e) {
			
		}
		private void Disclaimer_FormClosing(object sender, FormClosingEventArgs e) {
		}

		private void Disclaimer_Load(object sender, EventArgs e) {
			this.textBox1.Text = Properties.Resources.Eula;
		}
	}
}