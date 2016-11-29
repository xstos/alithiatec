namespace DeDupify {
	partial class ReallyDelete {
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.uiBtnNo = new System.Windows.Forms.Button();
			this.uiBtnYes = new System.Windows.Forms.Button();
			this.uiLBFiles = new System.Windows.Forms.ListBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.uiBtnNo);
			this.flowLayoutPanel1.Controls.Add(this.uiBtnYes);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 262);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(590, 29);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// uiBtnNo
			// 
			this.uiBtnNo.AutoSize = true;
			this.uiBtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.uiBtnNo.Location = new System.Drawing.Point(512, 3);
			this.uiBtnNo.Name = "uiBtnNo";
			this.uiBtnNo.Size = new System.Drawing.Size(75, 23);
			this.uiBtnNo.TabIndex = 1;
			this.uiBtnNo.Text = "No";
			this.uiBtnNo.UseVisualStyleBackColor = true;
			// 
			// uiBtnYes
			// 
			this.uiBtnYes.AutoSize = true;
			this.uiBtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.uiBtnYes.Location = new System.Drawing.Point(431, 3);
			this.uiBtnYes.Name = "uiBtnYes";
			this.uiBtnYes.Size = new System.Drawing.Size(75, 23);
			this.uiBtnYes.TabIndex = 0;
			this.uiBtnYes.Text = "Yes";
			this.uiBtnYes.UseVisualStyleBackColor = true;
			this.uiBtnYes.Click += new System.EventHandler(this.uiBtnYes_Click);
			// 
			// uiLBFiles
			// 
			this.uiLBFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiLBFiles.FormattingEnabled = true;
			this.uiLBFiles.Location = new System.Drawing.Point(0, 0);
			this.uiLBFiles.MultiColumn = true;
			this.uiLBFiles.Name = "uiLBFiles";
			this.uiLBFiles.Size = new System.Drawing.Size(590, 251);
			this.uiLBFiles.TabIndex = 1;
			// 
			// ReallyDelete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 291);
			this.Controls.Add(this.uiLBFiles);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "ReallyDelete";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Really delete the following files?";
			this.Load += new System.EventHandler(this.ReallyDelete_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button uiBtnYes;
		private System.Windows.Forms.Button uiBtnNo;
		private System.Windows.Forms.ListBox uiLBFiles;
	}
}