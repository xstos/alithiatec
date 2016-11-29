using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RapidFetch {
	public partial class LinkLabelWithHotTracking : LinkLabel {
		public LinkLabelWithHotTracking() : base() {
			InitializeComponent();
		}

		void LinkLabelWithHotTracking_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			if (!string.IsNullOrEmpty((string)this.Tag)) {
				try {
					System.Diagnostics.Process.Start(this.Tag.ToString());
				} catch { }
			}
		}
		private Color hc = Color.SteelBlue;
		public Color LinkHoverColor {
			get { return hc; }
			set { hc = value; }
		}
		Color prevColor;
		private void LinkLabelWithHotTracking_MouseEnter(object sender, EventArgs e) {
			prevColor = LinkColor;
			LinkColor = hc;
		}

		private void LinkLabelWithHotTracking_MouseLeave(object sender, EventArgs e) {
			LinkColor = prevColor;
		}

	}
}
