namespace RapidFetch {
  partial class LinkLabelWithHotTracking {
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

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		this.SuspendLayout();
		// 
		// LinkLabelWithHotTracking
		// 
		this.BackColor = System.Drawing.Color.Transparent;
		this.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.MouseLeave += new System.EventHandler(this.LinkLabelWithHotTracking_MouseLeave);
		this.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelWithHotTracking_LinkClicked);
		this.MouseEnter += new System.EventHandler(this.LinkLabelWithHotTracking_MouseEnter);
		this.ResumeLayout(false);

	}

	#endregion
  }
}
