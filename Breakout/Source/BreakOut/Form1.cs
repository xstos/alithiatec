using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BreakOut {
	public partial class Form1 : Form {
		
		public Form1() {
			InitializeComponent();
			SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
			this.ClientSize = new Size(840, 525);
            this.Shown += new EventHandler(Form1_Shown);
		}

        void Form1_Shown(object sender, EventArgs e)
        {
            Engine.Init();
            Engine.Instance.Initialize(this);
        }

		protected override void OnPaint(PaintEventArgs e) {
		    try
		    {
                Engine.Instance.Frame();
                this.Invalidate();
		    }
		    catch (Exception ee)
		    {
                Debugger.Break();
		    }
			
			
		}
		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);

			if ((int)(byte)e.KeyCode == (int)Keys.Escape)
				this.Close();
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e) {
			
		}
		
	}
}