using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace RapidFetch {
	public partial class About : Form {
		public About() {
			InitializeComponent();
		}

		private void About_Load(object sender, EventArgs e) {
			this.textBox1.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			MemoryStream ms=new MemoryStream();
			uiMainForm.stringToStream(ms,Properties.Resources.about);
			richTextBox1.LoadFile(ms, RichTextBoxStreamType.RichText);
			//panel1.MaximumSize = new Size(0, Properties.Resources.rapidfetch.Size.Height);
			About_Resize(null, null);
			this.Icon = Properties.Resources.rf_icon_v2;
			linkLabelWithHotTracking3.Select();
		}

		private void About_Resize(object sender, EventArgs e) {
			//panel1.Height = (int)(this.ClientSize.Height * 0.20);
		}

		private void panel3_Paint(object sender, PaintEventArgs e) {

		}

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void panel3_Paint_1(object sender, PaintEventArgs e) {

		}

		private void linkLabelWithHotTracking2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

		}

		private void panel2_Paint(object sender, PaintEventArgs e) {

		}

		private void textBox1_TextChanged(object sender, EventArgs e) {

		}
		

	}
}