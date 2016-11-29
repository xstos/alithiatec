namespace RapidFetch {
	partial class uiImagePreviewForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiOpacityLbl = new System.Windows.Forms.ToolStripLabel();
            this.uiOpacityPb = new System.Windows.Forms.ToolStripProgressBar();
            this.uiPctLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(601, 373);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(601, 398);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiOpacityLbl,
            this.uiOpacityPb,
            this.uiPctLabel});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(232, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // uiOpacityLbl
            // 
            this.uiOpacityLbl.Name = "uiOpacityLbl";
            this.uiOpacityLbl.Size = new System.Drawing.Size(118, 22);
            this.uiOpacityLbl.Text = "Window Transparency:";
            // 
            // uiOpacityPb
            // 
            this.uiOpacityPb.Name = "uiOpacityPb";
            this.uiOpacityPb.Size = new System.Drawing.Size(100, 22);
            this.uiOpacityPb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.uiOpacityPb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiOpacityPb_MouseMove);
            this.uiOpacityPb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiOpacityPb_MouseMove);
            // 
            // uiPctLabel
            // 
            this.uiPctLabel.Name = "uiPctLabel";
            this.uiPctLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // uiImagePreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 398);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "uiImagePreviewForm";
            this.Text = "uiImagePreviewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.uiImagePreviewForm_FormClosing);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel uiOpacityLbl;
		private System.Windows.Forms.ToolStripProgressBar uiOpacityPb;
		private System.Windows.Forms.ToolStripLabel uiPctLabel;
		internal System.Windows.Forms.ToolStripContainer toolStripContainer1;
	}
}