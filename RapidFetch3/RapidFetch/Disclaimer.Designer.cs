namespace RapidFetch {
	partial class Disclaimer {
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
			this.accept = new System.Windows.Forms.Button();
			this.decline = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// accept
			// 
			this.accept.AutoSize = true;
			this.accept.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.accept.Location = new System.Drawing.Point(648, 3);
			this.accept.Name = "accept";
			this.accept.Size = new System.Drawing.Size(75, 23);
			this.accept.TabIndex = 0;
			this.accept.Text = "Accept";
			this.accept.Click += new System.EventHandler(this.accept_Click);
			// 
			// decline
			// 
			this.decline.AutoSize = true;
			this.decline.DialogResult = System.Windows.Forms.DialogResult.No;
			this.decline.Location = new System.Drawing.Point(729, 3);
			this.decline.Name = "decline";
			this.decline.Size = new System.Drawing.Size(75, 23);
			this.decline.TabIndex = 1;
			this.decline.Text = "Decline";
			this.decline.Click += new System.EventHandler(this.decline_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.decline);
			this.flowLayoutPanel1.Controls.Add(this.accept);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 550);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(807, 29);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(807, 550);
			this.textBox1.TabIndex = 3;
			// 
			// Disclaimer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 579);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Disclaimer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Disclaimer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Disclaimer_FormClosing);
			this.Load += new System.EventHandler(this.Disclaimer_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button accept;
		private System.Windows.Forms.Button decline;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TextBox textBox1;
	}
}