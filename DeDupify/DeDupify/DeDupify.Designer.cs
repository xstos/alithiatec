namespace DeDupify {
	partial class DeDupify {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeDupify));
			this.uiLblDropFolders = new System.Windows.Forms.Label();
			this.uiLblWhatThisDoes = new System.Windows.Forms.Label();
			this.uiLbFolders = new System.Windows.Forms.ListBox();
			this.uiBtnAddFolder = new System.Windows.Forms.Button();
			this.uiFBD = new System.Windows.Forms.FolderBrowserDialog();
			this.uiChkAddSubFolders = new System.Windows.Forms.CheckBox();
			this.uiBtnDelSelected = new System.Windows.Forms.Button();
			this.uiSplitBottom = new System.Windows.Forms.SplitContainer();
			this.uiSplitTop = new System.Windows.Forms.SplitContainer();
			this.uiFLP1 = new System.Windows.Forms.FlowLayoutPanel();
			this.uiBtnClearFolders = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.uiCMSResults = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.uiCMSCut = new System.Windows.Forms.ToolStripMenuItem();
			this.uiCMSCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.uiCMSDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.uiFLP3 = new System.Windows.Forms.FlowLayoutPanel();
			this.uiBtnCut = new System.Windows.Forms.Button();
			this.uiBtnCopy = new System.Windows.Forms.Button();
			this.uiBtnDelete = new System.Windows.Forms.Button();
			this.uiBtnResize = new System.Windows.Forms.Button();
			this.uiBtnSaveResults = new System.Windows.Forms.Button();
			this.uiBtnLoadResults = new System.Windows.Forms.Button();
			this.uiBtnRefresh = new System.Windows.Forms.Button();
			this.uiLblStep3 = new System.Windows.Forms.Label();
			this.uiLLMain = new System.Windows.Forms.LinkLabel();
			this.uiLLFeedback = new System.Windows.Forms.LinkLabel();
			this.uiStatusStrip = new System.Windows.Forms.StatusStrip();
			this.uiLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.uiFLP2 = new System.Windows.Forms.FlowLayoutPanel();
			this.uiLblStep2 = new System.Windows.Forms.Label();
			this.uiBtnCheckNow = new System.Windows.Forms.Button();
			this.uiBtnCancel = new System.Windows.Forms.Button();
			this.bw = new System.ComponentModel.BackgroundWorker();
			this.uiCMSFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.uiCMSAddFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.uiCMSDeleteSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.uiCMSClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.uiDlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.uiDlgSave = new System.Windows.Forms.SaveFileDialog();
			this.uiBtnCheck4Updates = new System.Windows.Forms.Button();
			this.uiSplitBottom.Panel1.SuspendLayout();
			this.uiSplitBottom.Panel2.SuspendLayout();
			this.uiSplitBottom.SuspendLayout();
			this.uiSplitTop.Panel1.SuspendLayout();
			this.uiSplitTop.SuspendLayout();
			this.uiFLP1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.uiCMSResults.SuspendLayout();
			this.uiFLP3.SuspendLayout();
			this.uiStatusStrip.SuspendLayout();
			this.uiFLP2.SuspendLayout();
			this.uiCMSFolders.SuspendLayout();
			this.SuspendLayout();
			// 
			// uiLblDropFolders
			// 
			this.uiLblDropFolders.AutoSize = true;
			this.uiLblDropFolders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uiLblDropFolders.Location = new System.Drawing.Point(1, 24);
			this.uiLblDropFolders.Margin = new System.Windows.Forms.Padding(0);
			this.uiLblDropFolders.Name = "uiLblDropFolders";
			this.uiLblDropFolders.Padding = new System.Windows.Forms.Padding(0, 5, 0, 1);
			this.uiLblDropFolders.Size = new System.Drawing.Size(451, 19);
			this.uiLblDropFolders.TabIndex = 0;
			this.uiLblDropFolders.Text = "1) Drag and drop folders into here from windows explorer or click \"Add Folder\".";
			// 
			// uiLblWhatThisDoes
			// 
			this.uiLblWhatThisDoes.AutoSize = true;
			this.uiLblWhatThisDoes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uiLblWhatThisDoes.Location = new System.Drawing.Point(1, 1);
			this.uiLblWhatThisDoes.Margin = new System.Windows.Forms.Padding(0);
			this.uiLblWhatThisDoes.Name = "uiLblWhatThisDoes";
			this.uiLblWhatThisDoes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.uiLblWhatThisDoes.Size = new System.Drawing.Size(297, 16);
			this.uiLblWhatThisDoes.TabIndex = 1;
			this.uiLblWhatThisDoes.Text = "This program finds duplicate files on your hard disk:";
			// 
			// uiLbFolders
			// 
			this.uiLbFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiLbFolders.FormattingEnabled = true;
			this.uiLbFolders.Location = new System.Drawing.Point(1, 49);
			this.uiLbFolders.MultiColumn = true;
			this.uiLbFolders.Name = "uiLbFolders";
			this.uiLbFolders.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.uiLbFolders.Size = new System.Drawing.Size(864, 82);
			this.uiLbFolders.TabIndex = 2;
			// 
			// uiBtnAddFolder
			// 
			this.uiBtnAddFolder.AutoSize = true;
			this.uiBtnAddFolder.Location = new System.Drawing.Point(452, 24);
			this.uiBtnAddFolder.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnAddFolder.Name = "uiBtnAddFolder";
			this.uiBtnAddFolder.Size = new System.Drawing.Size(81, 23);
			this.uiBtnAddFolder.TabIndex = 3;
			this.uiBtnAddFolder.Text = "Add Folder...";
			this.uiBtnAddFolder.UseVisualStyleBackColor = true;
			this.uiBtnAddFolder.Click += new System.EventHandler(this.uiBtnAddFolder_Click);
			// 
			// uiChkAddSubFolders
			// 
			this.uiChkAddSubFolders.AutoSize = true;
			this.uiChkAddSubFolders.Checked = true;
			this.uiChkAddSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
			this.uiChkAddSubFolders.Location = new System.Drawing.Point(209, 0);
			this.uiChkAddSubFolders.Margin = new System.Windows.Forms.Padding(0);
			this.uiChkAddSubFolders.Name = "uiChkAddSubFolders";
			this.uiChkAddSubFolders.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.uiChkAddSubFolders.Size = new System.Drawing.Size(113, 22);
			this.uiChkAddSubFolders.TabIndex = 4;
			this.uiChkAddSubFolders.Text = "Check Sub-folders";
			this.uiChkAddSubFolders.UseVisualStyleBackColor = true;
			// 
			// uiBtnDelSelected
			// 
			this.uiBtnDelSelected.AutoSize = true;
			this.uiBtnDelSelected.Location = new System.Drawing.Point(533, 24);
			this.uiBtnDelSelected.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnDelSelected.Name = "uiBtnDelSelected";
			this.uiBtnDelSelected.Size = new System.Drawing.Size(93, 23);
			this.uiBtnDelSelected.TabIndex = 5;
			this.uiBtnDelSelected.Text = "Delete Selected";
			this.uiBtnDelSelected.UseVisualStyleBackColor = true;
			this.uiBtnDelSelected.Click += new System.EventHandler(this.uiBtnDelSelected_Click);
			// 
			// uiSplitBottom
			// 
			this.uiSplitBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiSplitBottom.Location = new System.Drawing.Point(0, 0);
			this.uiSplitBottom.Name = "uiSplitBottom";
			this.uiSplitBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// uiSplitBottom.Panel1
			// 
			this.uiSplitBottom.Panel1.Controls.Add(this.uiSplitTop);
			// 
			// uiSplitBottom.Panel2
			// 
			this.uiSplitBottom.Panel2.Controls.Add(this.dataGridView1);
			this.uiSplitBottom.Panel2.Controls.Add(this.uiFLP3);
			this.uiSplitBottom.Panel2.Controls.Add(this.uiStatusStrip);
			this.uiSplitBottom.Panel2.Controls.Add(this.uiFLP2);
			this.uiSplitBottom.Size = new System.Drawing.Size(866, 815);
			this.uiSplitBottom.SplitterDistance = 136;
			this.uiSplitBottom.TabIndex = 6;
			// 
			// uiSplitTop
			// 
			this.uiSplitTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiSplitTop.Location = new System.Drawing.Point(0, 0);
			this.uiSplitTop.Name = "uiSplitTop";
			// 
			// uiSplitTop.Panel1
			// 
			this.uiSplitTop.Panel1.Controls.Add(this.uiLbFolders);
			this.uiSplitTop.Panel1.Controls.Add(this.uiFLP1);
			this.uiSplitTop.Panel1.Padding = new System.Windows.Forms.Padding(1);
			this.uiSplitTop.Panel2Collapsed = true;
			this.uiSplitTop.Size = new System.Drawing.Size(866, 136);
			this.uiSplitTop.SplitterDistance = 455;
			this.uiSplitTop.TabIndex = 9;
			// 
			// uiFLP1
			// 
			this.uiFLP1.AutoSize = true;
			this.uiFLP1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.uiFLP1.Controls.Add(this.uiLblWhatThisDoes);
			this.uiFLP1.Controls.Add(this.uiBtnCheck4Updates);
			this.uiFLP1.Controls.Add(this.uiLblDropFolders);
			this.uiFLP1.Controls.Add(this.uiBtnAddFolder);
			this.uiFLP1.Controls.Add(this.uiBtnDelSelected);
			this.uiFLP1.Controls.Add(this.uiBtnClearFolders);
			this.uiFLP1.Dock = System.Windows.Forms.DockStyle.Top;
			this.uiFLP1.Location = new System.Drawing.Point(1, 1);
			this.uiFLP1.Name = "uiFLP1";
			this.uiFLP1.Padding = new System.Windows.Forms.Padding(1);
			this.uiFLP1.Size = new System.Drawing.Size(864, 48);
			this.uiFLP1.TabIndex = 8;
			// 
			// uiBtnClearFolders
			// 
			this.uiBtnClearFolders.AutoSize = true;
			this.uiBtnClearFolders.Location = new System.Drawing.Point(626, 24);
			this.uiBtnClearFolders.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnClearFolders.Name = "uiBtnClearFolders";
			this.uiBtnClearFolders.Size = new System.Drawing.Size(75, 23);
			this.uiBtnClearFolders.TabIndex = 6;
			this.uiBtnClearFolders.Text = "Clear All";
			this.uiBtnClearFolders.UseVisualStyleBackColor = true;
			this.uiBtnClearFolders.Click += new System.EventHandler(this.uiBtnClearFolders_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.uiCMSResults;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 23);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 18;
			this.dataGridView1.RowTemplate.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(866, 563);
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// uiCMSResults
			// 
			this.uiCMSResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiCMSCut,
            this.uiCMSCopy,
            this.uiCMSDelete});
			this.uiCMSResults.Name = "uiCMSResults";
			this.uiCMSResults.Size = new System.Drawing.Size(117, 70);
			// 
			// uiCMSCut
			// 
			this.uiCMSCut.Name = "uiCMSCut";
			this.uiCMSCut.Size = new System.Drawing.Size(116, 22);
			this.uiCMSCut.Text = "Cut";
			this.uiCMSCut.Click += new System.EventHandler(this.uiCMSCut_Click);
			// 
			// uiCMSCopy
			// 
			this.uiCMSCopy.Name = "uiCMSCopy";
			this.uiCMSCopy.Size = new System.Drawing.Size(116, 22);
			this.uiCMSCopy.Text = "Copy";
			this.uiCMSCopy.Click += new System.EventHandler(this.uiCMSCopy_Click);
			// 
			// uiCMSDelete
			// 
			this.uiCMSDelete.Name = "uiCMSDelete";
			this.uiCMSDelete.Size = new System.Drawing.Size(116, 22);
			this.uiCMSDelete.Text = "Delete";
			this.uiCMSDelete.Click += new System.EventHandler(this.uiCMSDelete_Click);
			// 
			// uiFLP3
			// 
			this.uiFLP3.AutoSize = true;
			this.uiFLP3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.uiFLP3.Controls.Add(this.uiBtnCut);
			this.uiFLP3.Controls.Add(this.uiBtnCopy);
			this.uiFLP3.Controls.Add(this.uiBtnDelete);
			this.uiFLP3.Controls.Add(this.uiBtnResize);
			this.uiFLP3.Controls.Add(this.uiBtnSaveResults);
			this.uiFLP3.Controls.Add(this.uiBtnLoadResults);
			this.uiFLP3.Controls.Add(this.uiBtnRefresh);
			this.uiFLP3.Controls.Add(this.uiLblStep3);
			this.uiFLP3.Controls.Add(this.uiLLMain);
			this.uiFLP3.Controls.Add(this.uiLLFeedback);
			this.uiFLP3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.uiFLP3.Location = new System.Drawing.Point(0, 586);
			this.uiFLP3.Name = "uiFLP3";
			this.uiFLP3.Size = new System.Drawing.Size(866, 67);
			this.uiFLP3.TabIndex = 11;
			// 
			// uiBtnCut
			// 
			this.uiBtnCut.Location = new System.Drawing.Point(0, 0);
			this.uiBtnCut.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnCut.Name = "uiBtnCut";
			this.uiBtnCut.Size = new System.Drawing.Size(75, 23);
			this.uiBtnCut.TabIndex = 13;
			this.uiBtnCut.Text = "Cut";
			this.uiBtnCut.UseVisualStyleBackColor = true;
			this.uiBtnCut.Click += new System.EventHandler(this.uiCMSCut_Click);
			// 
			// uiBtnCopy
			// 
			this.uiBtnCopy.Location = new System.Drawing.Point(75, 0);
			this.uiBtnCopy.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnCopy.Name = "uiBtnCopy";
			this.uiBtnCopy.Size = new System.Drawing.Size(75, 23);
			this.uiBtnCopy.TabIndex = 14;
			this.uiBtnCopy.Text = "Copy";
			this.uiBtnCopy.UseVisualStyleBackColor = true;
			this.uiBtnCopy.Click += new System.EventHandler(this.uiCMSCopy_Click);
			// 
			// uiBtnDelete
			// 
			this.uiBtnDelete.Location = new System.Drawing.Point(150, 0);
			this.uiBtnDelete.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnDelete.Name = "uiBtnDelete";
			this.uiBtnDelete.Size = new System.Drawing.Size(75, 23);
			this.uiBtnDelete.TabIndex = 15;
			this.uiBtnDelete.Text = "Delete";
			this.uiBtnDelete.UseVisualStyleBackColor = true;
			this.uiBtnDelete.Click += new System.EventHandler(this.uiCMSDelete_Click);
			// 
			// uiBtnResize
			// 
			this.uiBtnResize.AutoSize = true;
			this.uiBtnResize.Location = new System.Drawing.Point(225, 0);
			this.uiBtnResize.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnResize.Name = "uiBtnResize";
			this.uiBtnResize.Size = new System.Drawing.Size(119, 23);
			this.uiBtnResize.TabIndex = 9;
			this.uiBtnResize.Text = "Resize Columns to Fit";
			this.uiBtnResize.UseVisualStyleBackColor = true;
			this.uiBtnResize.Click += new System.EventHandler(this.uiBtnResize_Click);
			// 
			// uiBtnSaveResults
			// 
			this.uiBtnSaveResults.AutoSize = true;
			this.uiBtnSaveResults.Location = new System.Drawing.Point(344, 0);
			this.uiBtnSaveResults.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnSaveResults.Name = "uiBtnSaveResults";
			this.uiBtnSaveResults.Size = new System.Drawing.Size(80, 23);
			this.uiBtnSaveResults.TabIndex = 11;
			this.uiBtnSaveResults.Text = "Save Results";
			this.uiBtnSaveResults.UseVisualStyleBackColor = true;
			this.uiBtnSaveResults.Click += new System.EventHandler(this.uiBtnSaveResults_Click);
			// 
			// uiBtnLoadResults
			// 
			this.uiBtnLoadResults.AutoSize = true;
			this.uiBtnLoadResults.Location = new System.Drawing.Point(424, 0);
			this.uiBtnLoadResults.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnLoadResults.Name = "uiBtnLoadResults";
			this.uiBtnLoadResults.Size = new System.Drawing.Size(79, 23);
			this.uiBtnLoadResults.TabIndex = 12;
			this.uiBtnLoadResults.Text = "Load Results";
			this.uiBtnLoadResults.UseVisualStyleBackColor = true;
			this.uiBtnLoadResults.Click += new System.EventHandler(this.uiBtnLoadResults_Click);
			// 
			// uiBtnRefresh
			// 
			this.uiBtnRefresh.AutoSize = true;
			this.uiBtnRefresh.Location = new System.Drawing.Point(503, 0);
			this.uiBtnRefresh.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnRefresh.Name = "uiBtnRefresh";
			this.uiBtnRefresh.Size = new System.Drawing.Size(84, 23);
			this.uiBtnRefresh.TabIndex = 16;
			this.uiBtnRefresh.Text = "Refresh Table";
			this.uiBtnRefresh.UseVisualStyleBackColor = true;
			this.uiBtnRefresh.Click += new System.EventHandler(this.uiBtnRefresh_Click);
			// 
			// uiLblStep3
			// 
			this.uiLblStep3.AutoSize = true;
			this.uiLblStep3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uiLblStep3.Location = new System.Drawing.Point(0, 23);
			this.uiLblStep3.Margin = new System.Windows.Forms.Padding(0);
			this.uiLblStep3.Name = "uiLblStep3";
			this.uiLblStep3.Size = new System.Drawing.Size(862, 26);
			this.uiLblStep3.TabIndex = 11;
			this.uiLblStep3.Text = resources.GetString("uiLblStep3.Text");
			// 
			// uiLLMain
			// 
			this.uiLLMain.AutoSize = true;
			this.uiLLMain.Location = new System.Drawing.Point(3, 49);
			this.uiLLMain.Name = "uiLLMain";
			this.uiLLMain.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.uiLLMain.Size = new System.Drawing.Size(271, 18);
			this.uiLLMain.TabIndex = 7;
			this.uiLLMain.TabStop = true;
			this.uiLLMain.Text = "More useful utilities coming soon at www.alithiatec.com";
			this.uiLLMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// uiLLFeedback
			// 
			this.uiLLFeedback.AutoSize = true;
			this.uiLLFeedback.Location = new System.Drawing.Point(280, 49);
			this.uiLLFeedback.Name = "uiLLFeedback";
			this.uiLLFeedback.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.uiLLFeedback.Size = new System.Drawing.Size(88, 18);
			this.uiLLFeedback.TabIndex = 10;
			this.uiLLFeedback.TabStop = true;
			this.uiLLFeedback.Text = "Submit Feedback";
			this.uiLLFeedback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// uiStatusStrip
			// 
			this.uiStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiLblStatus});
			this.uiStatusStrip.Location = new System.Drawing.Point(0, 653);
			this.uiStatusStrip.Name = "uiStatusStrip";
			this.uiStatusStrip.Size = new System.Drawing.Size(866, 22);
			this.uiStatusStrip.TabIndex = 10;
			this.uiStatusStrip.Text = "statusStrip1";
			// 
			// uiLblStatus
			// 
			this.uiLblStatus.Name = "uiLblStatus";
			this.uiLblStatus.Size = new System.Drawing.Size(851, 17);
			this.uiLblStatus.Spring = true;
			this.uiLblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// uiFLP2
			// 
			this.uiFLP2.AutoSize = true;
			this.uiFLP2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.uiFLP2.Controls.Add(this.uiLblStep2);
			this.uiFLP2.Controls.Add(this.uiBtnCheckNow);
			this.uiFLP2.Controls.Add(this.uiBtnCancel);
			this.uiFLP2.Controls.Add(this.uiChkAddSubFolders);
			this.uiFLP2.Dock = System.Windows.Forms.DockStyle.Top;
			this.uiFLP2.Location = new System.Drawing.Point(0, 0);
			this.uiFLP2.Margin = new System.Windows.Forms.Padding(0);
			this.uiFLP2.Name = "uiFLP2";
			this.uiFLP2.Size = new System.Drawing.Size(866, 23);
			this.uiFLP2.TabIndex = 9;
			// 
			// uiLblStep2
			// 
			this.uiLblStep2.AutoSize = true;
			this.uiLblStep2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uiLblStep2.Location = new System.Drawing.Point(0, 0);
			this.uiLblStep2.Margin = new System.Windows.Forms.Padding(0);
			this.uiLblStep2.Name = "uiLblStep2";
			this.uiLblStep2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.uiLblStep2.Size = new System.Drawing.Size(56, 19);
			this.uiLblStep2.TabIndex = 10;
			this.uiLblStep2.Text = "2) Press:";
			// 
			// uiBtnCheckNow
			// 
			this.uiBtnCheckNow.AutoSize = true;
			this.uiBtnCheckNow.Location = new System.Drawing.Point(56, 0);
			this.uiBtnCheckNow.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnCheckNow.Name = "uiBtnCheckNow";
			this.uiBtnCheckNow.Size = new System.Drawing.Size(75, 23);
			this.uiBtnCheckNow.TabIndex = 5;
			this.uiBtnCheckNow.Text = "Scan Now";
			this.uiBtnCheckNow.UseVisualStyleBackColor = true;
			this.uiBtnCheckNow.Click += new System.EventHandler(this.uiBtnCheckNow_Click);
			// 
			// uiBtnCancel
			// 
			this.uiBtnCancel.AutoSize = true;
			this.uiBtnCancel.Enabled = false;
			this.uiBtnCancel.Location = new System.Drawing.Point(131, 0);
			this.uiBtnCancel.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnCancel.Name = "uiBtnCancel";
			this.uiBtnCancel.Size = new System.Drawing.Size(78, 23);
			this.uiBtnCancel.TabIndex = 8;
			this.uiBtnCancel.Text = "Cancel Scan";
			this.uiBtnCancel.UseVisualStyleBackColor = true;
			this.uiBtnCancel.Click += new System.EventHandler(this.uiBtnCancel_Click);
			// 
			// bw
			// 
			this.bw.WorkerReportsProgress = true;
			this.bw.WorkerSupportsCancellation = true;
			this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
			this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
			// 
			// uiCMSFolders
			// 
			this.uiCMSFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiCMSAddFolder,
            this.uiCMSDeleteSelected,
            this.uiCMSClearAll});
			this.uiCMSFolders.Name = "uiCMSFolders";
			this.uiCMSFolders.Size = new System.Drawing.Size(161, 70);
			// 
			// uiCMSAddFolder
			// 
			this.uiCMSAddFolder.Name = "uiCMSAddFolder";
			this.uiCMSAddFolder.Size = new System.Drawing.Size(160, 22);
			this.uiCMSAddFolder.Text = "Add Folder";
			this.uiCMSAddFolder.Click += new System.EventHandler(this.uiBtnAddFolder_Click);
			// 
			// uiCMSDeleteSelected
			// 
			this.uiCMSDeleteSelected.Name = "uiCMSDeleteSelected";
			this.uiCMSDeleteSelected.Size = new System.Drawing.Size(160, 22);
			this.uiCMSDeleteSelected.Text = "Delete Selected";
			this.uiCMSDeleteSelected.Click += new System.EventHandler(this.uiBtnDelSelected_Click);
			// 
			// uiCMSClearAll
			// 
			this.uiCMSClearAll.Name = "uiCMSClearAll";
			this.uiCMSClearAll.Size = new System.Drawing.Size(160, 22);
			this.uiCMSClearAll.Text = "Clear All";
			this.uiCMSClearAll.Click += new System.EventHandler(this.uiBtnClearFolders_Click);
			// 
			// uiDlgOpen
			// 
			this.uiDlgOpen.DefaultExt = "dedupe";
			this.uiDlgOpen.FileName = "results";
			this.uiDlgOpen.Filter = "DeDupify Result Sets|*.dedupe";
			this.uiDlgOpen.Title = "Open a result file";
			this.uiDlgOpen.FileOk += new System.ComponentModel.CancelEventHandler(this.uiDlgOpen_FileOk);
			// 
			// uiDlgSave
			// 
			this.uiDlgSave.DefaultExt = "dedupe";
			this.uiDlgSave.FileName = "results.dedupe";
			this.uiDlgSave.Filter = "DeDupify Result Sets|*.dedupe";
			this.uiDlgSave.Title = "Save results to file";
			this.uiDlgSave.FileOk += new System.ComponentModel.CancelEventHandler(this.uiDlgSave_FileOk);
			// 
			// uiBtnCheck4Updates
			// 
			this.uiBtnCheck4Updates.AutoSize = true;
			this.uiFLP1.SetFlowBreak(this.uiBtnCheck4Updates, true);
			this.uiBtnCheck4Updates.Location = new System.Drawing.Point(298, 1);
			this.uiBtnCheck4Updates.Margin = new System.Windows.Forms.Padding(0);
			this.uiBtnCheck4Updates.Name = "uiBtnCheck4Updates";
			this.uiBtnCheck4Updates.Size = new System.Drawing.Size(106, 23);
			this.uiBtnCheck4Updates.TabIndex = 7;
			this.uiBtnCheck4Updates.Text = "Check for Updates";
			this.uiBtnCheck4Updates.UseVisualStyleBackColor = true;
			this.uiBtnCheck4Updates.Click += new System.EventHandler(this.uiBtnCheck4Updates_Click);
			// 
			// DeDupify
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 815);
			this.Controls.Add(this.uiSplitBottom);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "DeDupify";
			this.Load += new System.EventHandler(this.DeDupify_Load);
			this.uiSplitBottom.Panel1.ResumeLayout(false);
			this.uiSplitBottom.Panel2.ResumeLayout(false);
			this.uiSplitBottom.Panel2.PerformLayout();
			this.uiSplitBottom.ResumeLayout(false);
			this.uiSplitTop.Panel1.ResumeLayout(false);
			this.uiSplitTop.Panel1.PerformLayout();
			this.uiSplitTop.ResumeLayout(false);
			this.uiFLP1.ResumeLayout(false);
			this.uiFLP1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.uiCMSResults.ResumeLayout(false);
			this.uiFLP3.ResumeLayout(false);
			this.uiFLP3.PerformLayout();
			this.uiStatusStrip.ResumeLayout(false);
			this.uiStatusStrip.PerformLayout();
			this.uiFLP2.ResumeLayout(false);
			this.uiFLP2.PerformLayout();
			this.uiCMSFolders.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label uiLblDropFolders;
		private System.Windows.Forms.Label uiLblWhatThisDoes;
		private System.Windows.Forms.ListBox uiLbFolders;
		private System.Windows.Forms.Button uiBtnAddFolder;
		private System.Windows.Forms.FolderBrowserDialog uiFBD;
		private System.Windows.Forms.CheckBox uiChkAddSubFolders;
		private System.Windows.Forms.Button uiBtnDelSelected;
		private System.Windows.Forms.SplitContainer uiSplitBottom;
		private System.Windows.Forms.Button uiBtnCheckNow;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button uiBtnClearFolders;
		private System.ComponentModel.BackgroundWorker bw;
		private System.Windows.Forms.FlowLayoutPanel uiFLP1;
		private System.Windows.Forms.FlowLayoutPanel uiFLP2;
		private System.Windows.Forms.Button uiBtnCancel;
		private System.Windows.Forms.StatusStrip uiStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel uiLblStatus;
		private System.Windows.Forms.Button uiBtnResize;
		private System.Windows.Forms.LinkLabel uiLLMain;
		private System.Windows.Forms.Label uiLblStep2;
		private System.Windows.Forms.FlowLayoutPanel uiFLP3;
		private System.Windows.Forms.ContextMenuStrip uiCMSResults;
		private System.Windows.Forms.ToolStripMenuItem uiCMSCut;
		private System.Windows.Forms.ToolStripMenuItem uiCMSDelete;
		private System.Windows.Forms.ToolStripMenuItem uiCMSCopy;
		private System.Windows.Forms.LinkLabel uiLLFeedback;
		private System.Windows.Forms.ContextMenuStrip uiCMSFolders;
		private System.Windows.Forms.ToolStripMenuItem uiCMSAddFolder;
		private System.Windows.Forms.ToolStripMenuItem uiCMSDeleteSelected;
		private System.Windows.Forms.ToolStripMenuItem uiCMSClearAll;
		private System.Windows.Forms.Button uiBtnSaveResults;
		private System.Windows.Forms.Button uiBtnLoadResults;
		private System.Windows.Forms.OpenFileDialog uiDlgOpen;
		private System.Windows.Forms.SplitContainer uiSplitTop;
		private System.Windows.Forms.SaveFileDialog uiDlgSave;
		private System.Windows.Forms.Label uiLblStep3;
		private System.Windows.Forms.Button uiBtnCut;
		private System.Windows.Forms.Button uiBtnCopy;
		private System.Windows.Forms.Button uiBtnDelete;
		private System.Windows.Forms.Button uiBtnRefresh;
		private System.Windows.Forms.Button uiBtnCheck4Updates;
	}
}

