using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RapidFetch {
	public partial class uiImagePreviewForm : Form {
		public uiImagePreviewForm() {
			InitializeComponent();
		}

		private void uiOpacityPb_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int x = e.X, w = uiOpacityPb.ContentRectangle.Width;
				double frac;
				if (x > w) x = w;
				if (x < 0) x = 0;
				frac = ((double)x / (double)w);
				uiOpacityPb.Value = (int)(frac*100);
				this.Opacity = (35 + 65-frac * 65) / 100;
			}
		}

		private void uiOpacityPb_MouseDown(object sender, MouseEventArgs e) {
			
		}

		private void uiImagePreviewForm_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			this.Hide();
			uiMainForm f = Owner as uiMainForm;
			f.uiTSBtnImagePreview.Checked = false;
		}
		
	}
}