namespace RapidFetch {
	partial class uiMainForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.uiCMSTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uiTSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTVGroups = new System.Windows.Forms.TreeView();
            this.uiCMSGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uiCMSNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.uiCMSAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.uiCMSRename = new System.Windows.Forms.ToolStripMenuItem();
            this.uiCMSDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.uiCMSRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.uiCMSExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.uiFolderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.uiBtnViewCache = new System.Windows.Forms.Button();
            this.uiInfoStatusStrip = new System.Windows.Forms.StatusStrip();
            this.uiTSLblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiTSLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.iconWorker = new System.ComponentModel.BackgroundWorker();
            this.resultWorker = new System.ComponentModel.BackgroundWorker();
            this.uiSplitGroupsResults = new System.Windows.Forms.SplitContainer();
            this.uiGroupsTSContainer = new System.Windows.Forms.ToolStripContainer();
            this.uiTSSearch = new System.Windows.Forms.ToolStrip();
            this.uiTSLblSearchFor = new System.Windows.Forms.ToolStripLabel();
            this.uiTSTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.uiTSGroups = new System.Windows.Forms.ToolStrip();
            this.uiTSLblFolderGroups = new System.Windows.Forms.ToolStripLabel();
            this.uiTSLblNewGrp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnAddFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnRename = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSDDAddSysFolder = new System.Windows.Forms.ToolStripDropDownButton();
            this.uiTSMIAddAsGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIStartMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIDesktop = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIMyDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIMyPictures = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIMyMusic = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.uiSearchTSContainer = new System.Windows.Forms.ToolStripContainer();
            this.uiDGVResults = new System.Windows.Forms.DataGridView();
            this.uiToolStripResults = new System.Windows.Forms.ToolStrip();
            this.uiTSLblSelection = new System.Windows.Forms.ToolStripLabel();
            this.uiTSBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnExplore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnCopyText = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnImagePreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSLblSelect = new System.Windows.Forms.ToolStripLabel();
            this.uiTSBtnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnSelectNone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSLblColumns = new System.Windows.Forms.ToolStripLabel();
            this.uiTSBtnResizeCols = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.uiCMSResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uiTSMIExploreResult = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIOpenFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSMISelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMISelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMICopyText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSMICopyFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMICutFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTSMIDeleteFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSMIResizeColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.uiSplitInfoOptions = new System.Windows.Forms.SplitContainer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.uiTabInfoPane = new System.Windows.Forms.TabControl();
            this.uiInfoPaneTabPage1 = new System.Windows.Forms.TabPage();
            this.uiLblInfoPane = new System.Windows.Forms.Label();
            this.uiTabAdvancedOptions = new System.Windows.Forms.TabControl();
            this.uiAdvOptTabPage1 = new System.Windows.Forms.TabPage();
            this.uiFlpAdvancedOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.uiGrpIndexer = new System.Windows.Forms.GroupBox();
            this.uiGrpSearchResults = new System.Windows.Forms.GroupBox();
            this.uiChkEntireRows = new System.Windows.Forms.CheckBox();
            this.uiGrpIntegration = new System.Windows.Forms.GroupBox();
            this.uiBtnUnIntegrate = new System.Windows.Forms.Button();
            this.uiBtnIntegrate = new System.Windows.Forms.Button();
            this.uiGrpFolderGroups = new System.Windows.Forms.GroupBox();
            this.uiBtnDemoGroups = new System.Windows.Forms.Button();
            this.uiGrpShortcuts = new System.Windows.Forms.GroupBox();
            this.uiOptJustMe = new System.Windows.Forms.RadioButton();
            this.uiOptAllUsers = new System.Windows.Forms.RadioButton();
            this.uiBtnStartMenu = new System.Windows.Forms.Button();
            this.uiBtnDesktop = new System.Windows.Forms.Button();
            this.uiBtnQuickLaunch = new System.Windows.Forms.Button();
            this.uiBtnResetToDefaults = new System.Windows.Forms.Button();
            this.uiMainTSContainer = new System.Windows.Forms.ToolStripContainer();
            this.uiSplitLeftRight = new System.Windows.Forms.SplitContainer();
            this.uiTSMainMenu = new System.Windows.Forms.ToolStrip();
            this.uiTSLblMainMenu = new System.Windows.Forms.ToolStripLabel();
            this.uiTSBtnAdvancedOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnInfoPane = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnHideToTray = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSStatus = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.uiTSBtnCheckForUpdates = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiCMSTray.SuspendLayout();
            this.uiCMSGroup.SuspendLayout();
            this.uiInfoStatusStrip.SuspendLayout();
            this.uiSplitGroupsResults.Panel1.SuspendLayout();
            this.uiSplitGroupsResults.Panel2.SuspendLayout();
            this.uiSplitGroupsResults.SuspendLayout();
            this.uiGroupsTSContainer.BottomToolStripPanel.SuspendLayout();
            this.uiGroupsTSContainer.ContentPanel.SuspendLayout();
            this.uiGroupsTSContainer.TopToolStripPanel.SuspendLayout();
            this.uiGroupsTSContainer.SuspendLayout();
            this.uiTSSearch.SuspendLayout();
            this.uiTSGroups.SuspendLayout();
            this.uiSearchTSContainer.ContentPanel.SuspendLayout();
            this.uiSearchTSContainer.TopToolStripPanel.SuspendLayout();
            this.uiSearchTSContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDGVResults)).BeginInit();
            this.uiToolStripResults.SuspendLayout();
            this.uiCMSResults.SuspendLayout();
            this.uiSplitInfoOptions.Panel1.SuspendLayout();
            this.uiSplitInfoOptions.Panel2.SuspendLayout();
            this.uiSplitInfoOptions.SuspendLayout();
            this.uiTabInfoPane.SuspendLayout();
            this.uiInfoPaneTabPage1.SuspendLayout();
            this.uiTabAdvancedOptions.SuspendLayout();
            this.uiAdvOptTabPage1.SuspendLayout();
            this.uiFlpAdvancedOptions.SuspendLayout();
            this.uiGrpIndexer.SuspendLayout();
            this.uiGrpSearchResults.SuspendLayout();
            this.uiGrpIntegration.SuspendLayout();
            this.uiGrpFolderGroups.SuspendLayout();
            this.uiGrpShortcuts.SuspendLayout();
            this.uiMainTSContainer.ContentPanel.SuspendLayout();
            this.uiMainTSContainer.TopToolStripPanel.SuspendLayout();
            this.uiMainTSContainer.SuspendLayout();
            this.uiSplitLeftRight.Panel1.SuspendLayout();
            this.uiSplitLeftRight.Panel2.SuspendLayout();
            this.uiSplitLeftRight.SuspendLayout();
            this.uiTSMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiNotifyIcon
            // 
            this.uiNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.uiNotifyIcon.BalloonTipText = "RapidFetch has been put in the system tray for your convenience. To completely ex" +
    "it, right click this icon. Click here to un-hide the application.";
            this.uiNotifyIcon.ContextMenuStrip = this.uiCMSTray;
            this.uiNotifyIcon.Text = "RapidFetch";
            this.uiNotifyIcon.Visible = true;
            this.uiNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiNotifyIcon_MouseClick);
            // 
            // uiCMSTray
            // 
            this.uiCMSTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSMIExit});
            this.uiCMSTray.Name = "contextMenuStrip1";
            this.uiCMSTray.Size = new System.Drawing.Size(93, 26);
            // 
            // uiTSMIExit
            // 
            this.uiTSMIExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uiTSMIExit.Name = "uiTSMIExit";
            this.uiTSMIExit.Size = new System.Drawing.Size(92, 22);
            this.uiTSMIExit.Text = "Exit";
            this.uiTSMIExit.Click += new System.EventHandler(this.uiTSMIExit_Click);
            // 
            // uiTVGroups
            // 
            this.uiTVGroups.ContextMenuStrip = this.uiCMSGroup;
            this.uiTVGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTVGroups.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.uiTVGroups.HideSelection = false;
            this.uiTVGroups.HotTracking = true;
            this.uiTVGroups.LabelEdit = true;
            this.uiTVGroups.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.uiTVGroups.Location = new System.Drawing.Point(0, 0);
            this.uiTVGroups.Margin = new System.Windows.Forms.Padding(0);
            this.uiTVGroups.Name = "uiTVGroups";
            this.uiTVGroups.Size = new System.Drawing.Size(649, 212);
            this.uiTVGroups.TabIndex = 0;
            this.uiTVGroups.Tag = "tree";
            this.uiTVGroups.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.uiTVGroups_AfterLabelEdit);
            this.uiTVGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.uiTVGroups_AfterSelect);
            this.uiTVGroups.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiGroupTv_NodeMouseClick);
            this.uiTVGroups.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiTVGroups_NodeMouseDoubleClick);
            this.uiTVGroups.DragOver += new System.Windows.Forms.DragEventHandler(this.uiTVGroups_DragOver);
            this.uiTVGroups.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiTVGroups_KeyUp);
            this.uiTVGroups.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiTVGroups_MouseMove);
            // 
            // uiCMSGroup
            // 
            this.uiCMSGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiCMSNewGroup,
            this.uiCMSAddFolder,
            this.uiCMSRename,
            this.uiCMSDelete,
            this.uiCMSRefresh,
            this.uiCMSExplore});
            this.uiCMSGroup.Name = "ActionGroupMenu";
            this.uiCMSGroup.Size = new System.Drawing.Size(135, 136);
            // 
            // uiCMSNewGroup
            // 
            this.uiCMSNewGroup.Image = global::RapidFetch.Properties.Resources.Control_TreeView;
            this.uiCMSNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiCMSNewGroup.Name = "uiCMSNewGroup";
            this.uiCMSNewGroup.Size = new System.Drawing.Size(134, 22);
            this.uiCMSNewGroup.Text = "New Group";
            this.uiCMSNewGroup.Click += new System.EventHandler(this.uiTSLblNewGrp_Click);
            // 
            // uiCMSAddFolder
            // 
            this.uiCMSAddFolder.Image = global::RapidFetch.Properties.Resources.openfolderHS;
            this.uiCMSAddFolder.Name = "uiCMSAddFolder";
            this.uiCMSAddFolder.Size = new System.Drawing.Size(134, 22);
            this.uiCMSAddFolder.Text = "Add Folder";
            this.uiCMSAddFolder.Click += new System.EventHandler(this.uiTSBtnAddFolder_Click);
            // 
            // uiCMSRename
            // 
            this.uiCMSRename.Image = global::RapidFetch.Properties.Resources.RenameFolderHS;
            this.uiCMSRename.Name = "uiCMSRename";
            this.uiCMSRename.Size = new System.Drawing.Size(134, 22);
            this.uiCMSRename.Text = "Rename";
            this.uiCMSRename.Click += new System.EventHandler(this.uiTSBtnRename_Click);
            // 
            // uiCMSDelete
            // 
            this.uiCMSDelete.Image = global::RapidFetch.Properties.Resources.Critical2;
            this.uiCMSDelete.Name = "uiCMSDelete";
            this.uiCMSDelete.Size = new System.Drawing.Size(134, 22);
            this.uiCMSDelete.Text = "Delete";
            this.uiCMSDelete.Click += new System.EventHandler(this.uiTSBtnRemove_Click);
            // 
            // uiCMSRefresh
            // 
            this.uiCMSRefresh.Image = global::RapidFetch.Properties.Resources.RefreshDocView;
            this.uiCMSRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiCMSRefresh.Name = "uiCMSRefresh";
            this.uiCMSRefresh.Size = new System.Drawing.Size(134, 22);
            this.uiCMSRefresh.Text = "Refresh";
            this.uiCMSRefresh.Click += new System.EventHandler(this.uiTSBtnRefresh_Click);
            // 
            // uiCMSExplore
            // 
            this.uiCMSExplore.Image = global::RapidFetch.Properties.Resources.mycomputer;
            this.uiCMSExplore.Name = "uiCMSExplore";
            this.uiCMSExplore.Size = new System.Drawing.Size(134, 22);
            this.uiCMSExplore.Text = "Explore";
            this.uiCMSExplore.Click += new System.EventHandler(this.uiExploreCmsItem_Click);
            // 
            // uiBtnViewCache
            // 
            this.uiBtnViewCache.AutoSize = true;
            this.uiBtnViewCache.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnViewCache.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnViewCache.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnViewCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnViewCache.Location = new System.Drawing.Point(6, 17);
            this.uiBtnViewCache.Margin = new System.Windows.Forms.Padding(0);
            this.uiBtnViewCache.Name = "uiBtnViewCache";
            this.uiBtnViewCache.Size = new System.Drawing.Size(123, 25);
            this.uiBtnViewCache.TabIndex = 0;
            this.uiBtnViewCache.TabStop = false;
            this.uiBtnViewCache.Tag = "cache";
            this.uiBtnViewCache.Text = "View Cache SnapShot";
            this.uiBtnViewCache.Click += new System.EventHandler(this.uiBtnViewCache_Click);
            // 
            // uiInfoStatusStrip
            // 
            this.uiInfoStatusStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiInfoStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSLblInfo,
            this.uiTSLblStatus});
            this.uiInfoStatusStrip.Location = new System.Drawing.Point(3, 721);
            this.uiInfoStatusStrip.Name = "uiInfoStatusStrip";
            this.uiInfoStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.uiInfoStatusStrip.Size = new System.Drawing.Size(1061, 24);
            this.uiInfoStatusStrip.TabIndex = 25;
            this.uiInfoStatusStrip.Tag = "main";
            this.uiInfoStatusStrip.Text = "statusStrip1";
            this.uiInfoStatusStrip.MouseEnter += new System.EventHandler(this.var_MouseEnter);
            // 
            // uiTSLblInfo
            // 
            this.uiTSLblInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiTSLblInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.uiTSLblInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.uiTSLblInfo.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.uiTSLblInfo.Name = "uiTSLblInfo";
            this.uiTSLblInfo.Padding = new System.Windows.Forms.Padding(2);
            this.uiTSLblInfo.Size = new System.Drawing.Size(54, 22);
            this.uiTSLblInfo.Text = "             ";
            // 
            // uiTSLblStatus
            // 
            this.uiTSLblStatus.AutoToolTip = true;
            this.uiTSLblStatus.BackColor = System.Drawing.Color.Red;
            this.uiTSLblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.uiTSLblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.uiTSLblStatus.ForeColor = System.Drawing.Color.White;
            this.uiTSLblStatus.Margin = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.uiTSLblStatus.Name = "uiTSLblStatus";
            this.uiTSLblStatus.Padding = new System.Windows.Forms.Padding(2);
            this.uiTSLblStatus.Size = new System.Drawing.Size(60, 21);
            this.uiTSLblStatus.Text = "               ";
            this.uiTSLblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconWorker
            // 
            this.iconWorker.WorkerSupportsCancellation = true;
            this.iconWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.iconWorker_DoWork);
            this.iconWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.iconWorker_RunWorkerCompleted);
            // 
            // resultWorker
            // 
            this.resultWorker.WorkerSupportsCancellation = true;
            // 
            // uiSplitGroupsResults
            // 
            this.uiSplitGroupsResults.Location = new System.Drawing.Point(9, 8);
            this.uiSplitGroupsResults.Name = "uiSplitGroupsResults";
            this.uiSplitGroupsResults.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uiSplitGroupsResults.Panel1
            // 
            this.uiSplitGroupsResults.Panel1.Controls.Add(this.uiGroupsTSContainer);
            // 
            // uiSplitGroupsResults.Panel2
            // 
            this.uiSplitGroupsResults.Panel2.Controls.Add(this.uiSearchTSContainer);
            this.uiSplitGroupsResults.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.uiSplitGroupsResults.Size = new System.Drawing.Size(779, 628);
            this.uiSplitGroupsResults.SplitterDistance = 272;
            this.uiSplitGroupsResults.SplitterWidth = 5;
            this.uiSplitGroupsResults.TabIndex = 0;
            this.uiSplitGroupsResults.TabStop = false;
            // 
            // uiGroupsTSContainer
            // 
            // 
            // uiGroupsTSContainer.BottomToolStripPanel
            // 
            this.uiGroupsTSContainer.BottomToolStripPanel.Controls.Add(this.uiTSSearch);
            // 
            // uiGroupsTSContainer.ContentPanel
            // 
            this.uiGroupsTSContainer.ContentPanel.Controls.Add(this.uiTVGroups);
            this.uiGroupsTSContainer.ContentPanel.Size = new System.Drawing.Size(649, 212);
            this.uiGroupsTSContainer.Location = new System.Drawing.Point(65, 7);
            this.uiGroupsTSContainer.Name = "uiGroupsTSContainer";
            this.uiGroupsTSContainer.Size = new System.Drawing.Size(649, 262);
            this.uiGroupsTSContainer.TabIndex = 0;
            this.uiGroupsTSContainer.Text = "toolStripContainer2";
            // 
            // uiGroupsTSContainer.TopToolStripPanel
            // 
            this.uiGroupsTSContainer.TopToolStripPanel.Controls.Add(this.uiTSGroups);
            // 
            // uiTSSearch
            // 
            this.uiTSSearch.Dock = System.Windows.Forms.DockStyle.None;
            this.uiTSSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.uiTSSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSLblSearchFor,
            this.uiTSTxtSearch});
            this.uiTSSearch.Location = new System.Drawing.Point(0, 0);
            this.uiTSSearch.Name = "uiTSSearch";
            this.uiTSSearch.Size = new System.Drawing.Size(649, 25);
            this.uiTSSearch.Stretch = true;
            this.uiTSSearch.TabIndex = 0;
            this.uiTSSearch.Text = "toolStrip4";
            this.uiTSSearch.Resize += new System.EventHandler(this.uiTSSearch_Resize);
            // 
            // uiTSLblSearchFor
            // 
            this.uiTSLblSearchFor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTSLblSearchFor.Image = global::RapidFetch.Properties.Resources.search;
            this.uiTSLblSearchFor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSLblSearchFor.Name = "uiTSLblSearchFor";
            this.uiTSLblSearchFor.Size = new System.Drawing.Size(86, 22);
            this.uiTSLblSearchFor.Text = "Search For:";
            // 
            // uiTSTxtSearch
            // 
            this.uiTSTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiTSTxtSearch.MaxLength = 1024;
            this.uiTSTxtSearch.Name = "uiTSTxtSearch";
            this.uiTSTxtSearch.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.uiTSTxtSearch.Size = new System.Drawing.Size(200, 25);
            this.uiTSTxtSearch.Tag = "search";
            this.uiTSTxtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiTSTxtSearch_KeyUp);
            this.uiTSTxtSearch.TextChanged += new System.EventHandler(this.uiTSTxtSearch_TextChanged);
            // 
            // uiTSGroups
            // 
            this.uiTSGroups.Dock = System.Windows.Forms.DockStyle.None;
            this.uiTSGroups.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.uiTSGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSLblFolderGroups,
            this.uiTSLblNewGrp,
            this.toolStripSeparator9,
            this.uiTSBtnAddFolder,
            this.toolStripSeparator10,
            this.uiTSBtnRename,
            this.toolStripSeparator11,
            this.uiTSBtnRemove,
            this.toolStripSeparator12,
            this.uiTSBtnRefresh,
            this.toolStripSeparator13,
            this.uiTSDDAddSysFolder,
            this.toolStripSeparator25});
            this.uiTSGroups.Location = new System.Drawing.Point(0, 0);
            this.uiTSGroups.Name = "uiTSGroups";
            this.uiTSGroups.Size = new System.Drawing.Size(649, 25);
            this.uiTSGroups.Stretch = true;
            this.uiTSGroups.TabIndex = 0;
            this.uiTSGroups.Tag = "main";
            this.uiTSGroups.MouseEnter += new System.EventHandler(this.var_MouseEnter);
            // 
            // uiTSLblFolderGroups
            // 
            this.uiTSLblFolderGroups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTSLblFolderGroups.Name = "uiTSLblFolderGroups";
            this.uiTSLblFolderGroups.Size = new System.Drawing.Size(88, 22);
            this.uiTSLblFolderGroups.Text = "Folder Groups:";
            // 
            // uiTSLblNewGrp
            // 
            this.uiTSLblNewGrp.Image = global::RapidFetch.Properties.Resources.Control_TreeView;
            this.uiTSLblNewGrp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSLblNewGrp.Name = "uiTSLblNewGrp";
            this.uiTSLblNewGrp.Size = new System.Drawing.Size(87, 22);
            this.uiTSLblNewGrp.Text = "New Group";
            this.uiTSLblNewGrp.Click += new System.EventHandler(this.uiTSLblNewGrp_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnAddFolder
            // 
            this.uiTSBtnAddFolder.Image = global::RapidFetch.Properties.Resources.openfolderHS;
            this.uiTSBtnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnAddFolder.Name = "uiTSBtnAddFolder";
            this.uiTSBtnAddFolder.Size = new System.Drawing.Size(85, 22);
            this.uiTSBtnAddFolder.Tag = "+";
            this.uiTSBtnAddFolder.Text = "Add Folder";
            this.uiTSBtnAddFolder.Click += new System.EventHandler(this.uiTSBtnAddFolder_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnRename
            // 
            this.uiTSBtnRename.Image = global::RapidFetch.Properties.Resources.RenameFolderHS;
            this.uiTSBtnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnRename.Name = "uiTSBtnRename";
            this.uiTSBtnRename.Size = new System.Drawing.Size(70, 22);
            this.uiTSBtnRename.Tag = "ren";
            this.uiTSBtnRename.Text = "Rename";
            this.uiTSBtnRename.Click += new System.EventHandler(this.uiTSBtnRename_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnRemove
            // 
            this.uiTSBtnRemove.Image = global::RapidFetch.Properties.Resources.Critical2;
            this.uiTSBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnRemove.Name = "uiTSBtnRemove";
            this.uiTSBtnRemove.Size = new System.Drawing.Size(70, 22);
            this.uiTSBtnRemove.Tag = "-";
            this.uiTSBtnRemove.Text = "Remove";
            this.uiTSBtnRemove.Click += new System.EventHandler(this.uiTSBtnRemove_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnRefresh
            // 
            this.uiTSBtnRefresh.Image = global::RapidFetch.Properties.Resources.RefreshDocView;
            this.uiTSBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnRefresh.Name = "uiTSBtnRefresh";
            this.uiTSBtnRefresh.Size = new System.Drawing.Size(66, 22);
            this.uiTSBtnRefresh.Tag = "ref";
            this.uiTSBtnRefresh.Text = "Refresh";
            this.uiTSBtnRefresh.Click += new System.EventHandler(this.uiTSBtnRefresh_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSDDAddSysFolder
            // 
            this.uiTSDDAddSysFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSMIAddAsGroup});
            this.uiTSDDAddSysFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSDDAddSysFolder.Name = "uiTSDDAddSysFolder";
            this.uiTSDDAddSysFolder.Size = new System.Drawing.Size(119, 22);
            this.uiTSDDAddSysFolder.Tag = "+sys";
            this.uiTSDDAddSysFolder.Text = "Add System Folder";
            // 
            // uiTSMIAddAsGroup
            // 
            this.uiTSMIAddAsGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSMIStartMenu,
            this.uiTSMIDesktop,
            this.uiTSMIMyDocuments,
            this.uiTSMIMyPictures,
            this.uiTSMIMyMusic,
            this.uiTSMIFavorites,
            this.uiTSMIHistory});
            this.uiTSMIAddAsGroup.Name = "uiTSMIAddAsGroup";
            this.uiTSMIAddAsGroup.Size = new System.Drawing.Size(146, 22);
            this.uiTSMIAddAsGroup.Text = "Add as Group";
            // 
            // uiTSMIStartMenu
            // 
            this.uiTSMIStartMenu.Name = "uiTSMIStartMenu";
            this.uiTSMIStartMenu.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIStartMenu.Text = "Start Menu";
            this.uiTSMIStartMenu.Click += new System.EventHandler(this.uiTSMIStartMenu_Click);
            // 
            // uiTSMIDesktop
            // 
            this.uiTSMIDesktop.Name = "uiTSMIDesktop";
            this.uiTSMIDesktop.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIDesktop.Text = "Desktop";
            this.uiTSMIDesktop.Click += new System.EventHandler(this.uiTSMIDesktop_Click);
            // 
            // uiTSMIMyDocuments
            // 
            this.uiTSMIMyDocuments.Name = "uiTSMIMyDocuments";
            this.uiTSMIMyDocuments.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIMyDocuments.Text = "My Documents";
            this.uiTSMIMyDocuments.Click += new System.EventHandler(this.uiTSMIMyDocuments_Click);
            // 
            // uiTSMIMyPictures
            // 
            this.uiTSMIMyPictures.Name = "uiTSMIMyPictures";
            this.uiTSMIMyPictures.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIMyPictures.Text = "My Pictures";
            this.uiTSMIMyPictures.Click += new System.EventHandler(this.uiTSMIMyPictures_Click);
            // 
            // uiTSMIMyMusic
            // 
            this.uiTSMIMyMusic.Name = "uiTSMIMyMusic";
            this.uiTSMIMyMusic.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIMyMusic.Text = "My Music";
            this.uiTSMIMyMusic.Click += new System.EventHandler(this.uiTSMIMyMusic_Click);
            // 
            // uiTSMIFavorites
            // 
            this.uiTSMIFavorites.Name = "uiTSMIFavorites";
            this.uiTSMIFavorites.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIFavorites.Text = "Favorites";
            this.uiTSMIFavorites.Click += new System.EventHandler(this.uiTSMIFavorites_Click);
            // 
            // uiTSMIHistory
            // 
            this.uiTSMIHistory.Name = "uiTSMIHistory";
            this.uiTSMIHistory.Size = new System.Drawing.Size(155, 22);
            this.uiTSMIHistory.Text = "History";
            this.uiTSMIHistory.Click += new System.EventHandler(this.uiTSMIHistory_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(6, 25);
            // 
            // uiSearchTSContainer
            // 
            // 
            // uiSearchTSContainer.ContentPanel
            // 
            this.uiSearchTSContainer.ContentPanel.Controls.Add(this.uiDGVResults);
            this.uiSearchTSContainer.ContentPanel.Size = new System.Drawing.Size(723, 261);
            this.uiSearchTSContainer.Location = new System.Drawing.Point(26, 26);
            this.uiSearchTSContainer.Name = "uiSearchTSContainer";
            this.uiSearchTSContainer.Size = new System.Drawing.Size(723, 286);
            this.uiSearchTSContainer.TabIndex = 0;
            this.uiSearchTSContainer.Text = "toolStripContainer3";
            // 
            // uiSearchTSContainer.TopToolStripPanel
            // 
            this.uiSearchTSContainer.TopToolStripPanel.Controls.Add(this.uiToolStripResults);
            // 
            // uiDGVResults
            // 
            this.uiDGVResults.AllowUserToAddRows = false;
            this.uiDGVResults.AllowUserToDeleteRows = false;
            this.uiDGVResults.AllowUserToOrderColumns = true;
            this.uiDGVResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.uiDGVResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.uiDGVResults.BackgroundColor = System.Drawing.Color.White;
            this.uiDGVResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDGVResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.uiDGVResults.ColumnHeadersHeight = 20;
            this.uiDGVResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDGVResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDGVResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.uiDGVResults.Location = new System.Drawing.Point(0, 0);
            this.uiDGVResults.Margin = new System.Windows.Forms.Padding(0);
            this.uiDGVResults.Name = "uiDGVResults";
            this.uiDGVResults.ReadOnly = true;
            this.uiDGVResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.uiDGVResults.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.uiDGVResults.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.uiDGVResults.RowTemplate.Height = 16;
            this.uiDGVResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDGVResults.Size = new System.Drawing.Size(723, 261);
            this.uiDGVResults.TabIndex = 0;
            this.uiDGVResults.Tag = "data";
            this.uiDGVResults.VirtualMode = true;
            this.uiDGVResults.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.uiDGVResults_CellMouseDoubleClick);
            this.uiDGVResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.uiDGVResults_CellMouseDown);
            this.uiDGVResults.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.uiDGVResults_CellValueNeeded);
            this.uiDGVResults.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.uiDGVResults_ColumnHeaderMouseClick);
            this.uiDGVResults.Scroll += new System.Windows.Forms.ScrollEventHandler(this.uiDGVResults_Scroll);
            this.uiDGVResults.SelectionChanged += new System.EventHandler(this.uiDGVResults_SelectionChanged);
            this.uiDGVResults.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.uiDGVResults_QueryContinueDrag);
            this.uiDGVResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiDGVResults_KeyDown);
            this.uiDGVResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiDGVResults_MouseClick);
            this.uiDGVResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiDGVResults_MouseDown);
            this.uiDGVResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiDGVResults_MouseMove);
            this.uiDGVResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiDGVResults_MouseUp);
            this.uiDGVResults.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.uiDGVResults_PreviewKeyDown);
            // 
            // uiToolStripResults
            // 
            this.uiToolStripResults.Dock = System.Windows.Forms.DockStyle.None;
            this.uiToolStripResults.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.uiToolStripResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSLblSelection,
            this.uiTSBtnOpen,
            this.toolStripSeparator8,
            this.uiTSBtnExplore,
            this.toolStripSeparator14,
            this.uiTSBtnCut,
            this.toolStripSeparator15,
            this.uiTSBtnCopy,
            this.toolStripSeparator16,
            this.uiTSBtnCopyText,
            this.toolStripSeparator19,
            this.uiTSBtnImagePreview,
            this.toolStripSeparator24,
            this.uiTSLblSelect,
            this.uiTSBtnSelectAll,
            this.toolStripSeparator17,
            this.uiTSBtnSelectNone,
            this.toolStripSeparator18,
            this.uiTSLblColumns,
            this.uiTSBtnResizeCols,
            this.toolStripSeparator20});
            this.uiToolStripResults.Location = new System.Drawing.Point(0, 0);
            this.uiToolStripResults.Name = "uiToolStripResults";
            this.uiToolStripResults.Size = new System.Drawing.Size(723, 25);
            this.uiToolStripResults.Stretch = true;
            this.uiToolStripResults.TabIndex = 1;
            // 
            // uiTSLblSelection
            // 
            this.uiTSLblSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTSLblSelection.Name = "uiTSLblSelection";
            this.uiTSLblSelection.Size = new System.Drawing.Size(62, 22);
            this.uiTSLblSelection.Text = "Selection:";
            // 
            // uiTSBtnOpen
            // 
            this.uiTSBtnOpen.Image = global::RapidFetch.Properties.Resources.Open;
            this.uiTSBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnOpen.Name = "uiTSBtnOpen";
            this.uiTSBtnOpen.Size = new System.Drawing.Size(56, 22);
            this.uiTSBtnOpen.Tag = "open";
            this.uiTSBtnOpen.Text = "Open";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnExplore
            // 
            this.uiTSBtnExplore.Image = global::RapidFetch.Properties.Resources.mycomputer;
            this.uiTSBtnExplore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnExplore.Name = "uiTSBtnExplore";
            this.uiTSBtnExplore.Size = new System.Drawing.Size(65, 22);
            this.uiTSBtnExplore.Tag = "explore";
            this.uiTSBtnExplore.Text = "Explore";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnCut
            // 
            this.uiTSBtnCut.Image = global::RapidFetch.Properties.Resources.CutHS;
            this.uiTSBtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnCut.Name = "uiTSBtnCut";
            this.uiTSBtnCut.Size = new System.Drawing.Size(46, 22);
            this.uiTSBtnCut.Tag = "cut";
            this.uiTSBtnCut.Text = "Cut";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnCopy
            // 
            this.uiTSBtnCopy.Image = global::RapidFetch.Properties.Resources.CopyHS;
            this.uiTSBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnCopy.Name = "uiTSBtnCopy";
            this.uiTSBtnCopy.Size = new System.Drawing.Size(55, 22);
            this.uiTSBtnCopy.Tag = "copy";
            this.uiTSBtnCopy.Text = "Copy";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnCopyText
            // 
            this.uiTSBtnCopyText.Image = global::RapidFetch.Properties.Resources.Textbox;
            this.uiTSBtnCopyText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnCopyText.Name = "uiTSBtnCopyText";
            this.uiTSBtnCopyText.Size = new System.Drawing.Size(80, 22);
            this.uiTSBtnCopyText.Tag = "copytxt";
            this.uiTSBtnCopyText.Text = "Copy Text";
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnImagePreview
            // 
            this.uiTSBtnImagePreview.CheckOnClick = true;
            this.uiTSBtnImagePreview.Image = global::RapidFetch.Properties.Resources.VSProject_imagefile;
            this.uiTSBtnImagePreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnImagePreview.Name = "uiTSBtnImagePreview";
            this.uiTSBtnImagePreview.Size = new System.Drawing.Size(104, 22);
            this.uiTSBtnImagePreview.Tag = "preview";
            this.uiTSBtnImagePreview.Text = "Image Preview";
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSLblSelect
            // 
            this.uiTSLblSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTSLblSelect.Name = "uiTSLblSelect";
            this.uiTSLblSelect.Size = new System.Drawing.Size(45, 22);
            this.uiTSLblSelect.Text = "Select:";
            // 
            // uiTSBtnSelectAll
            // 
            this.uiTSBtnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnSelectAll.Name = "uiTSBtnSelectAll";
            this.uiTSBtnSelectAll.Size = new System.Drawing.Size(25, 22);
            this.uiTSBtnSelectAll.Tag = "all";
            this.uiTSBtnSelectAll.Text = "All";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnSelectNone
            // 
            this.uiTSBtnSelectNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnSelectNone.Name = "uiTSBtnSelectNone";
            this.uiTSBtnSelectNone.Size = new System.Drawing.Size(40, 22);
            this.uiTSBtnSelectNone.Tag = "none";
            this.uiTSBtnSelectNone.Text = "None";
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSLblColumns
            // 
            this.uiTSLblColumns.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTSLblColumns.Name = "uiTSLblColumns";
            this.uiTSLblColumns.Size = new System.Drawing.Size(58, 22);
            this.uiTSLblColumns.Text = "Columns:";
            // 
            // uiTSBtnResizeCols
            // 
            this.uiTSBtnResizeCols.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnResizeCols.Name = "uiTSBtnResizeCols";
            this.uiTSBtnResizeCols.Size = new System.Drawing.Size(73, 22);
            this.uiTSBtnResizeCols.Tag = "fit";
            this.uiTSBtnResizeCols.Text = "Resize to Fit";
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // uiCMSResults
            // 
            this.uiCMSResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSMIExploreResult,
            this.uiTSMIOpenFiles,
            this.toolStripSeparator2,
            this.uiTSMISelectAll,
            this.uiTSMISelectNone,
            this.uiTSMICopyText,
            this.toolStripSeparator1,
            this.uiTSMICopyFiles,
            this.uiTSMICutFiles,
            this.uiTSMIDeleteFiles,
            this.toolStripSeparator3,
            this.uiTSMIResizeColumns});
            this.uiCMSResults.Name = "contextMenuStrip2";
            this.uiCMSResults.Size = new System.Drawing.Size(244, 220);
            // 
            // uiTSMIExploreResult
            // 
            this.uiTSMIExploreResult.Image = global::RapidFetch.Properties.Resources.mycomputer;
            this.uiTSMIExploreResult.Name = "uiTSMIExploreResult";
            this.uiTSMIExploreResult.Size = new System.Drawing.Size(243, 22);
            this.uiTSMIExploreResult.Text = "Explore";
            this.uiTSMIExploreResult.Click += new System.EventHandler(this.uiTSBtnExplore_Click);
            // 
            // uiTSMIOpenFiles
            // 
            this.uiTSMIOpenFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiTSMIOpenFiles.Image = global::RapidFetch.Properties.Resources.Open;
            this.uiTSMIOpenFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSMIOpenFiles.Name = "uiTSMIOpenFiles";
            this.uiTSMIOpenFiles.Size = new System.Drawing.Size(243, 22);
            this.uiTSMIOpenFiles.Text = "Open File(s)";
            this.uiTSMIOpenFiles.Click += new System.EventHandler(this.uiTSMIOpenFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
            // 
            // uiTSMISelectAll
            // 
            this.uiTSMISelectAll.Name = "uiTSMISelectAll";
            this.uiTSMISelectAll.Size = new System.Drawing.Size(243, 22);
            this.uiTSMISelectAll.Text = "Select All";
            this.uiTSMISelectAll.Click += new System.EventHandler(this.uiTSMISelectAll_Click);
            // 
            // uiTSMISelectNone
            // 
            this.uiTSMISelectNone.Name = "uiTSMISelectNone";
            this.uiTSMISelectNone.Size = new System.Drawing.Size(243, 22);
            this.uiTSMISelectNone.Text = "Select None";
            this.uiTSMISelectNone.Click += new System.EventHandler(this.uiTSMISelectNone_Click);
            // 
            // uiTSMICopyText
            // 
            this.uiTSMICopyText.Image = global::RapidFetch.Properties.Resources.Textbox;
            this.uiTSMICopyText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSMICopyText.Name = "uiTSMICopyText";
            this.uiTSMICopyText.Size = new System.Drawing.Size(243, 22);
            this.uiTSMICopyText.Text = "Copy Selected Text to Clipboard";
            this.uiTSMICopyText.Click += new System.EventHandler(this.uiTSMICopyText_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // uiTSMICopyFiles
            // 
            this.uiTSMICopyFiles.Image = global::RapidFetch.Properties.Resources.CopyHS;
            this.uiTSMICopyFiles.Name = "uiTSMICopyFiles";
            this.uiTSMICopyFiles.Size = new System.Drawing.Size(243, 22);
            this.uiTSMICopyFiles.Text = "Copy File(s)";
            this.uiTSMICopyFiles.Click += new System.EventHandler(this.uiTSMICopyFiles_Click);
            // 
            // uiTSMICutFiles
            // 
            this.uiTSMICutFiles.Image = global::RapidFetch.Properties.Resources.CutHS;
            this.uiTSMICutFiles.Name = "uiTSMICutFiles";
            this.uiTSMICutFiles.Size = new System.Drawing.Size(243, 22);
            this.uiTSMICutFiles.Text = "Cut File(s)";
            this.uiTSMICutFiles.Click += new System.EventHandler(this.uiTSMICutFiles_Click);
            // 
            // uiTSMIDeleteFiles
            // 
            this.uiTSMIDeleteFiles.Name = "uiTSMIDeleteFiles";
            this.uiTSMIDeleteFiles.Size = new System.Drawing.Size(243, 22);
            this.uiTSMIDeleteFiles.Text = "Delete File(s)";
            this.uiTSMIDeleteFiles.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(240, 6);
            // 
            // uiTSMIResizeColumns
            // 
            this.uiTSMIResizeColumns.Name = "uiTSMIResizeColumns";
            this.uiTSMIResizeColumns.Size = new System.Drawing.Size(243, 22);
            this.uiTSMIResizeColumns.Text = "Resize Columns";
            this.uiTSMIResizeColumns.Click += new System.EventHandler(this.uiTSMIResizeColumns_Click);
            // 
            // uiSplitInfoOptions
            // 
            this.uiSplitInfoOptions.Location = new System.Drawing.Point(4, 8);
            this.uiSplitInfoOptions.Name = "uiSplitInfoOptions";
            this.uiSplitInfoOptions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uiSplitInfoOptions.Panel1
            // 
            this.uiSplitInfoOptions.Panel1.Controls.Add(this.linkLabel1);
            this.uiSplitInfoOptions.Panel1.Controls.Add(this.uiTabInfoPane);
            // 
            // uiSplitInfoOptions.Panel2
            // 
            this.uiSplitInfoOptions.Panel2.Controls.Add(this.uiTabAdvancedOptions);
            this.uiSplitInfoOptions.Size = new System.Drawing.Size(212, 616);
            this.uiSplitInfoOptions.SplitterDistance = 202;
            this.uiSplitInfoOptions.TabIndex = 26;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(181, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(28, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Hide";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // uiTabInfoPane
            // 
            this.uiTabInfoPane.Controls.Add(this.uiInfoPaneTabPage1);
            this.uiTabInfoPane.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTabInfoPane.Location = new System.Drawing.Point(13, 19);
            this.uiTabInfoPane.Name = "uiTabInfoPane";
            this.uiTabInfoPane.SelectedIndex = 0;
            this.uiTabInfoPane.Size = new System.Drawing.Size(161, 160);
            this.uiTabInfoPane.TabIndex = 0;
            // 
            // uiInfoPaneTabPage1
            // 
            this.uiInfoPaneTabPage1.AutoScroll = true;
            this.uiInfoPaneTabPage1.Controls.Add(this.uiLblInfoPane);
            this.uiInfoPaneTabPage1.Location = new System.Drawing.Point(4, 22);
            this.uiInfoPaneTabPage1.Name = "uiInfoPaneTabPage1";
            this.uiInfoPaneTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.uiInfoPaneTabPage1.Size = new System.Drawing.Size(153, 134);
            this.uiInfoPaneTabPage1.TabIndex = 1;
            this.uiInfoPaneTabPage1.Text = "Help Pane";
            this.uiInfoPaneTabPage1.UseVisualStyleBackColor = true;
            // 
            // uiLblInfoPane
            // 
            this.uiLblInfoPane.AutoEllipsis = true;
            this.uiLblInfoPane.BackColor = System.Drawing.Color.Transparent;
            this.uiLblInfoPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLblInfoPane.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLblInfoPane.Location = new System.Drawing.Point(3, 3);
            this.uiLblInfoPane.Name = "uiLblInfoPane";
            this.uiLblInfoPane.Size = new System.Drawing.Size(147, 128);
            this.uiLblInfoPane.TabIndex = 0;
            this.uiLblInfoPane.Tag = "main";
            // 
            // uiTabAdvancedOptions
            // 
            this.uiTabAdvancedOptions.Controls.Add(this.uiAdvOptTabPage1);
            this.uiTabAdvancedOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTabAdvancedOptions.Location = new System.Drawing.Point(3, 3);
            this.uiTabAdvancedOptions.Name = "uiTabAdvancedOptions";
            this.uiTabAdvancedOptions.SelectedIndex = 0;
            this.uiTabAdvancedOptions.Size = new System.Drawing.Size(171, 451);
            this.uiTabAdvancedOptions.TabIndex = 0;
            // 
            // uiAdvOptTabPage1
            // 
            this.uiAdvOptTabPage1.Controls.Add(this.uiFlpAdvancedOptions);
            this.uiAdvOptTabPage1.Location = new System.Drawing.Point(4, 22);
            this.uiAdvOptTabPage1.Name = "uiAdvOptTabPage1";
            this.uiAdvOptTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.uiAdvOptTabPage1.Size = new System.Drawing.Size(163, 425);
            this.uiAdvOptTabPage1.TabIndex = 0;
            this.uiAdvOptTabPage1.Text = "Options";
            this.uiAdvOptTabPage1.UseVisualStyleBackColor = true;
            // 
            // uiFlpAdvancedOptions
            // 
            this.uiFlpAdvancedOptions.AutoScroll = true;
            this.uiFlpAdvancedOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiFlpAdvancedOptions.Controls.Add(this.uiGrpIndexer);
            this.uiFlpAdvancedOptions.Controls.Add(this.uiGrpSearchResults);
            this.uiFlpAdvancedOptions.Controls.Add(this.uiGrpIntegration);
            this.uiFlpAdvancedOptions.Controls.Add(this.uiGrpFolderGroups);
            this.uiFlpAdvancedOptions.Controls.Add(this.uiGrpShortcuts);
            this.uiFlpAdvancedOptions.Controls.Add(this.uiBtnResetToDefaults);
            this.uiFlpAdvancedOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFlpAdvancedOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uiFlpAdvancedOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFlpAdvancedOptions.Location = new System.Drawing.Point(3, 3);
            this.uiFlpAdvancedOptions.Name = "uiFlpAdvancedOptions";
            this.uiFlpAdvancedOptions.Size = new System.Drawing.Size(157, 419);
            this.uiFlpAdvancedOptions.TabIndex = 8;
            // 
            // uiGrpIndexer
            // 
            this.uiGrpIndexer.BackColor = System.Drawing.Color.Transparent;
            this.uiGrpIndexer.Controls.Add(this.uiBtnViewCache);
            this.uiGrpIndexer.Location = new System.Drawing.Point(3, 3);
            this.uiGrpIndexer.Name = "uiGrpIndexer";
            this.uiGrpIndexer.Size = new System.Drawing.Size(139, 47);
            this.uiGrpIndexer.TabIndex = 4;
            this.uiGrpIndexer.TabStop = false;
            this.uiGrpIndexer.Text = "Indexer";
            // 
            // uiGrpSearchResults
            // 
            this.uiGrpSearchResults.BackColor = System.Drawing.Color.Transparent;
            this.uiGrpSearchResults.Controls.Add(this.uiChkEntireRows);
            this.uiGrpSearchResults.Location = new System.Drawing.Point(3, 56);
            this.uiGrpSearchResults.Name = "uiGrpSearchResults";
            this.uiGrpSearchResults.Size = new System.Drawing.Size(139, 38);
            this.uiGrpSearchResults.TabIndex = 3;
            this.uiGrpSearchResults.TabStop = false;
            this.uiGrpSearchResults.Text = "Search Results";
            // 
            // uiChkEntireRows
            // 
            this.uiChkEntireRows.AutoSize = true;
            this.uiChkEntireRows.BackColor = System.Drawing.Color.Transparent;
            this.uiChkEntireRows.Checked = true;
            this.uiChkEntireRows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiChkEntireRows.Location = new System.Drawing.Point(6, 17);
            this.uiChkEntireRows.Name = "uiChkEntireRows";
            this.uiChkEntireRows.Size = new System.Drawing.Size(112, 17);
            this.uiChkEntireRows.TabIndex = 1;
            this.uiChkEntireRows.Tag = "row";
            this.uiChkEntireRows.Text = "Select entire rows";
            this.uiChkEntireRows.UseVisualStyleBackColor = false;
            this.uiChkEntireRows.CheckedChanged += new System.EventHandler(this.uiChkEntireRows_CheckedChanged);
            // 
            // uiGrpIntegration
            // 
            this.uiGrpIntegration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiGrpIntegration.BackColor = System.Drawing.Color.Transparent;
            this.uiGrpIntegration.Controls.Add(this.uiBtnUnIntegrate);
            this.uiGrpIntegration.Controls.Add(this.uiBtnIntegrate);
            this.uiGrpIntegration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiGrpIntegration.Location = new System.Drawing.Point(3, 100);
            this.uiGrpIntegration.Name = "uiGrpIntegration";
            this.uiGrpIntegration.Size = new System.Drawing.Size(139, 72);
            this.uiGrpIntegration.TabIndex = 6;
            this.uiGrpIntegration.TabStop = false;
            this.uiGrpIntegration.Text = "Integration";
            // 
            // uiBtnUnIntegrate
            // 
            this.uiBtnUnIntegrate.AutoSize = true;
            this.uiBtnUnIntegrate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnUnIntegrate.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnUnIntegrate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnUnIntegrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnUnIntegrate.Location = new System.Drawing.Point(4, 45);
            this.uiBtnUnIntegrate.Name = "uiBtnUnIntegrate";
            this.uiBtnUnIntegrate.Size = new System.Drawing.Size(115, 25);
            this.uiBtnUnIntegrate.TabIndex = 1;
            this.uiBtnUnIntegrate.Tag = "shell";
            this.uiBtnUnIntegrate.Text = "Remove Integration";
            this.uiBtnUnIntegrate.UseVisualStyleBackColor = true;
            this.uiBtnUnIntegrate.Click += new System.EventHandler(this.uiBtnUnIntegrate_Click);
            // 
            // uiBtnIntegrate
            // 
            this.uiBtnIntegrate.AutoSize = true;
            this.uiBtnIntegrate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnIntegrate.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnIntegrate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnIntegrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnIntegrate.Location = new System.Drawing.Point(4, 18);
            this.uiBtnIntegrate.Name = "uiBtnIntegrate";
            this.uiBtnIntegrate.Size = new System.Drawing.Size(131, 25);
            this.uiBtnIntegrate.TabIndex = 0;
            this.uiBtnIntegrate.Tag = "shell";
            this.uiBtnIntegrate.Text = "Integrate with Explorer";
            this.uiBtnIntegrate.UseVisualStyleBackColor = true;
            this.uiBtnIntegrate.Click += new System.EventHandler(this.uiBtnIntegrate_Click);
            // 
            // uiGrpFolderGroups
            // 
            this.uiGrpFolderGroups.BackColor = System.Drawing.Color.Transparent;
            this.uiGrpFolderGroups.Controls.Add(this.uiBtnDemoGroups);
            this.uiGrpFolderGroups.Location = new System.Drawing.Point(3, 178);
            this.uiGrpFolderGroups.Name = "uiGrpFolderGroups";
            this.uiGrpFolderGroups.Size = new System.Drawing.Size(139, 44);
            this.uiGrpFolderGroups.TabIndex = 7;
            this.uiGrpFolderGroups.TabStop = false;
            this.uiGrpFolderGroups.Text = "Folder Groups";
            // 
            // uiBtnDemoGroups
            // 
            this.uiBtnDemoGroups.AutoSize = true;
            this.uiBtnDemoGroups.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnDemoGroups.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnDemoGroups.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnDemoGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnDemoGroups.Location = new System.Drawing.Point(4, 17);
            this.uiBtnDemoGroups.Margin = new System.Windows.Forms.Padding(0);
            this.uiBtnDemoGroups.Name = "uiBtnDemoGroups";
            this.uiBtnDemoGroups.Size = new System.Drawing.Size(123, 25);
            this.uiBtnDemoGroups.TabIndex = 1;
            this.uiBtnDemoGroups.TabStop = false;
            this.uiBtnDemoGroups.Tag = "demo";
            this.uiBtnDemoGroups.Text = "Re-Add Demo Folders";
            this.uiBtnDemoGroups.Click += new System.EventHandler(this.uiBtnDemoGroups_Click);
            // 
            // uiGrpShortcuts
            // 
            this.uiGrpShortcuts.Controls.Add(this.uiOptJustMe);
            this.uiGrpShortcuts.Controls.Add(this.uiOptAllUsers);
            this.uiGrpShortcuts.Controls.Add(this.uiBtnStartMenu);
            this.uiGrpShortcuts.Controls.Add(this.uiBtnDesktop);
            this.uiGrpShortcuts.Controls.Add(this.uiBtnQuickLaunch);
            this.uiGrpShortcuts.Location = new System.Drawing.Point(3, 228);
            this.uiGrpShortcuts.Name = "uiGrpShortcuts";
            this.uiGrpShortcuts.Size = new System.Drawing.Size(139, 135);
            this.uiGrpShortcuts.TabIndex = 4;
            this.uiGrpShortcuts.TabStop = false;
            this.uiGrpShortcuts.Text = "Create Shortcuts";
            // 
            // uiOptJustMe
            // 
            this.uiOptJustMe.AutoSize = true;
            this.uiOptJustMe.Location = new System.Drawing.Point(6, 39);
            this.uiOptJustMe.Name = "uiOptJustMe";
            this.uiOptJustMe.Size = new System.Drawing.Size(62, 17);
            this.uiOptJustMe.TabIndex = 5;
            this.uiOptJustMe.Tag = "justme";
            this.uiOptJustMe.Text = "Just Me";
            // 
            // uiOptAllUsers
            // 
            this.uiOptAllUsers.AutoSize = true;
            this.uiOptAllUsers.Checked = true;
            this.uiOptAllUsers.Location = new System.Drawing.Point(6, 20);
            this.uiOptAllUsers.Name = "uiOptAllUsers";
            this.uiOptAllUsers.Size = new System.Drawing.Size(66, 17);
            this.uiOptAllUsers.TabIndex = 4;
            this.uiOptAllUsers.TabStop = true;
            this.uiOptAllUsers.Tag = "allusers";
            this.uiOptAllUsers.Text = "All Users";
            // 
            // uiBtnStartMenu
            // 
            this.uiBtnStartMenu.AutoSize = true;
            this.uiBtnStartMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnStartMenu.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnStartMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnStartMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnStartMenu.Location = new System.Drawing.Point(6, 59);
            this.uiBtnStartMenu.Name = "uiBtnStartMenu";
            this.uiBtnStartMenu.Size = new System.Drawing.Size(72, 25);
            this.uiBtnStartMenu.TabIndex = 1;
            this.uiBtnStartMenu.Tag = "startmenu";
            this.uiBtnStartMenu.Text = "Start Menu";
            this.uiBtnStartMenu.Click += new System.EventHandler(this.uiBtnStartMenu_Click);
            // 
            // uiBtnDesktop
            // 
            this.uiBtnDesktop.AutoSize = true;
            this.uiBtnDesktop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnDesktop.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnDesktop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnDesktop.Location = new System.Drawing.Point(6, 107);
            this.uiBtnDesktop.Name = "uiBtnDesktop";
            this.uiBtnDesktop.Size = new System.Drawing.Size(58, 25);
            this.uiBtnDesktop.TabIndex = 3;
            this.uiBtnDesktop.Tag = "desktop";
            this.uiBtnDesktop.Text = "Desktop";
            this.uiBtnDesktop.Click += new System.EventHandler(this.uiBtnDesktop_Click);
            // 
            // uiBtnQuickLaunch
            // 
            this.uiBtnQuickLaunch.AutoSize = true;
            this.uiBtnQuickLaunch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiBtnQuickLaunch.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnQuickLaunch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnQuickLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnQuickLaunch.Location = new System.Drawing.Point(6, 84);
            this.uiBtnQuickLaunch.Name = "uiBtnQuickLaunch";
            this.uiBtnQuickLaunch.Size = new System.Drawing.Size(79, 25);
            this.uiBtnQuickLaunch.TabIndex = 2;
            this.uiBtnQuickLaunch.Tag = "quicklaunch";
            this.uiBtnQuickLaunch.Text = "QuickLaunch";
            this.uiBtnQuickLaunch.Click += new System.EventHandler(this.uiBtnQuickLaunch_Click);
            // 
            // uiBtnResetToDefaults
            // 
            this.uiBtnResetToDefaults.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.uiBtnResetToDefaults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.uiBtnResetToDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiBtnResetToDefaults.Location = new System.Drawing.Point(3, 369);
            this.uiBtnResetToDefaults.Name = "uiBtnResetToDefaults";
            this.uiBtnResetToDefaults.Size = new System.Drawing.Size(109, 43);
            this.uiBtnResetToDefaults.TabIndex = 8;
            this.uiBtnResetToDefaults.Text = "Reset Settings to Default";
            this.uiBtnResetToDefaults.UseVisualStyleBackColor = true;
            // 
            // uiMainTSContainer
            // 
            // 
            // uiMainTSContainer.ContentPanel
            // 
            this.uiMainTSContainer.ContentPanel.Controls.Add(this.uiSplitLeftRight);
            this.uiMainTSContainer.ContentPanel.Size = new System.Drawing.Size(1061, 693);
            this.uiMainTSContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMainTSContainer.Location = new System.Drawing.Point(3, 3);
            this.uiMainTSContainer.Name = "uiMainTSContainer";
            this.uiMainTSContainer.Size = new System.Drawing.Size(1061, 718);
            this.uiMainTSContainer.TabIndex = 27;
            this.uiMainTSContainer.Text = "toolStripContainer1";
            // 
            // uiMainTSContainer.TopToolStripPanel
            // 
            this.uiMainTSContainer.TopToolStripPanel.Controls.Add(this.uiTSMainMenu);
            // 
            // uiSplitLeftRight
            // 
            this.uiSplitLeftRight.Location = new System.Drawing.Point(3, 3);
            this.uiSplitLeftRight.Name = "uiSplitLeftRight";
            // 
            // uiSplitLeftRight.Panel1
            // 
            this.uiSplitLeftRight.Panel1.Controls.Add(this.uiSplitGroupsResults);
            // 
            // uiSplitLeftRight.Panel2
            // 
            this.uiSplitLeftRight.Panel2.Controls.Add(this.uiSplitInfoOptions);
            this.uiSplitLeftRight.Size = new System.Drawing.Size(1052, 656);
            this.uiSplitLeftRight.SplitterDistance = 821;
            this.uiSplitLeftRight.TabIndex = 30;
            // 
            // uiTSMainMenu
            // 
            this.uiTSMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiTSMainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.uiTSMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.uiTSMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTSLblMainMenu,
            this.uiTSBtnAdvancedOptions,
            this.toolStripSeparator4,
            this.uiTSBtnAbout,
            this.toolStripSeparator5,
            this.uiTSBtnInfoPane,
            this.toolStripSeparator7,
            this.uiTSBtnHideToTray,
            this.toolStripSeparator23,
            this.uiTSBtnExit,
            this.toolStripSeparator6,
            this.uiTSBtnHelp,
            this.toolStripSeparator21,
            this.uiTSStatus,
            this.toolStripSeparator22,
            this.uiTSBtnCheckForUpdates});
            this.uiTSMainMenu.Location = new System.Drawing.Point(0, 0);
            this.uiTSMainMenu.Name = "uiTSMainMenu";
            this.uiTSMainMenu.Size = new System.Drawing.Size(1061, 25);
            this.uiTSMainMenu.Stretch = true;
            this.uiTSMainMenu.TabIndex = 0;
            this.uiTSMainMenu.Tag = "main";
            this.uiTSMainMenu.MouseEnter += new System.EventHandler(this.var_MouseEnter);
            // 
            // uiTSLblMainMenu
            // 
            this.uiTSLblMainMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTSLblMainMenu.Name = "uiTSLblMainMenu";
            this.uiTSLblMainMenu.Size = new System.Drawing.Size(71, 22);
            this.uiTSLblMainMenu.Text = "Main Menu:";
            // 
            // uiTSBtnAdvancedOptions
            // 
            this.uiTSBtnAdvancedOptions.CheckOnClick = true;
            this.uiTSBtnAdvancedOptions.Image = global::RapidFetch.Properties.Resources.OptionsHS;
            this.uiTSBtnAdvancedOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.uiTSBtnAdvancedOptions.ImageTransparentColor = System.Drawing.Color.Black;
            this.uiTSBtnAdvancedOptions.Name = "uiTSBtnAdvancedOptions";
            this.uiTSBtnAdvancedOptions.Size = new System.Drawing.Size(69, 22);
            this.uiTSBtnAdvancedOptions.Text = "Options";
            this.uiTSBtnAdvancedOptions.CheckedChanged += new System.EventHandler(this.uiTSBtnAdvancedOptions_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // uiTSBtnAbout
            // 
            this.uiTSBtnAbout.Image = global::RapidFetch.Properties.Resources.Information;
            this.uiTSBtnAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.uiTSBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnAbout.Name = "uiTSBtnAbout";
            this.uiTSBtnAbout.Size = new System.Drawing.Size(59, 22);
            this.uiTSBtnAbout.Text = "About";
            this.uiTSBtnAbout.Visible = false;
            this.uiTSBtnAbout.Click += new System.EventHandler(this.uiTSBtnAbout_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnInfoPane
            // 
            this.uiTSBtnInfoPane.Checked = true;
            this.uiTSBtnInfoPane.CheckOnClick = true;
            this.uiTSBtnInfoPane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiTSBtnInfoPane.ForeColor = System.Drawing.SystemColors.InfoText;
            this.uiTSBtnInfoPane.Image = global::RapidFetch.Properties.Resources.Information;
            this.uiTSBtnInfoPane.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.uiTSBtnInfoPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnInfoPane.Name = "uiTSBtnInfoPane";
            this.uiTSBtnInfoPane.Size = new System.Drawing.Size(80, 22);
            this.uiTSBtnInfoPane.Text = "Help Pane";
            this.uiTSBtnInfoPane.CheckedChanged += new System.EventHandler(this.uiTSBtnInfoPane_CheckedChanged);
            this.uiTSBtnInfoPane.Click += new System.EventHandler(this.uiTSBtnInfoPane_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnHideToTray
            // 
            this.uiTSBtnHideToTray.Image = global::RapidFetch.Properties.Resources.Expand_large;
            this.uiTSBtnHideToTray.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.uiTSBtnHideToTray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnHideToTray.Name = "uiTSBtnHideToTray";
            this.uiTSBtnHideToTray.Size = new System.Drawing.Size(89, 22);
            this.uiTSBtnHideToTray.Tag = "hide";
            this.uiTSBtnHideToTray.Text = "Hide to Tray";
            this.uiTSBtnHideToTray.Click += new System.EventHandler(this.uiTSBtnHideToTray_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnExit
            // 
            this.uiTSBtnExit.Image = global::RapidFetch.Properties.Resources.xp_X;
            this.uiTSBtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.uiTSBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnExit.Name = "uiTSBtnExit";
            this.uiTSBtnExit.Size = new System.Drawing.Size(105, 22);
            this.uiTSBtnExit.Text = "Exit RapidFetch";
            this.uiTSBtnExit.Click += new System.EventHandler(this.uiTSBtnExit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // uiTSBtnHelp
            // 
            this.uiTSBtnHelp.Image = global::RapidFetch.Properties.Resources.Help;
            this.uiTSBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnHelp.Name = "uiTSBtnHelp";
            this.uiTSBtnHelp.Size = new System.Drawing.Size(52, 22);
            this.uiTSBtnHelp.Text = "Help";
            this.uiTSBtnHelp.Visible = false;
            this.uiTSBtnHelp.Click += new System.EventHandler(this.uiTSBtnHelp_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator21.Visible = false;
            // 
            // uiTSStatus
            // 
            this.uiTSStatus.Name = "uiTSStatus";
            this.uiTSStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator22.Visible = false;
            // 
            // uiTSBtnCheckForUpdates
            // 
            this.uiTSBtnCheckForUpdates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTSBtnCheckForUpdates.Name = "uiTSBtnCheckForUpdates";
            this.uiTSBtnCheckForUpdates.Size = new System.Drawing.Size(108, 22);
            this.uiTSBtnCheckForUpdates.Text = "Check for Updates";
            this.uiTSBtnCheckForUpdates.Visible = false;
            this.uiTSBtnCheckForUpdates.Click += new System.EventHandler(this.uiTSBtnCheckForUpdates_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiToolTip1
            // 
            this.uiToolTip1.IsBalloon = true;
            // 
            // uiMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 748);
            this.Controls.Add(this.uiMainTSContainer);
            this.Controls.Add(this.uiInfoStatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.Name = "uiMainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.uiMainForm_FormClosing);
            this.Load += new System.EventHandler(this.uiMainForm_Load);
            this.MouseLeave += new System.EventHandler(this.uiMainForm_MouseLeave);
            this.uiCMSTray.ResumeLayout(false);
            this.uiCMSGroup.ResumeLayout(false);
            this.uiInfoStatusStrip.ResumeLayout(false);
            this.uiInfoStatusStrip.PerformLayout();
            this.uiSplitGroupsResults.Panel1.ResumeLayout(false);
            this.uiSplitGroupsResults.Panel2.ResumeLayout(false);
            this.uiSplitGroupsResults.ResumeLayout(false);
            this.uiGroupsTSContainer.BottomToolStripPanel.ResumeLayout(false);
            this.uiGroupsTSContainer.BottomToolStripPanel.PerformLayout();
            this.uiGroupsTSContainer.ContentPanel.ResumeLayout(false);
            this.uiGroupsTSContainer.TopToolStripPanel.ResumeLayout(false);
            this.uiGroupsTSContainer.TopToolStripPanel.PerformLayout();
            this.uiGroupsTSContainer.ResumeLayout(false);
            this.uiGroupsTSContainer.PerformLayout();
            this.uiTSSearch.ResumeLayout(false);
            this.uiTSSearch.PerformLayout();
            this.uiTSGroups.ResumeLayout(false);
            this.uiTSGroups.PerformLayout();
            this.uiSearchTSContainer.ContentPanel.ResumeLayout(false);
            this.uiSearchTSContainer.TopToolStripPanel.ResumeLayout(false);
            this.uiSearchTSContainer.TopToolStripPanel.PerformLayout();
            this.uiSearchTSContainer.ResumeLayout(false);
            this.uiSearchTSContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDGVResults)).EndInit();
            this.uiToolStripResults.ResumeLayout(false);
            this.uiToolStripResults.PerformLayout();
            this.uiCMSResults.ResumeLayout(false);
            this.uiSplitInfoOptions.Panel1.ResumeLayout(false);
            this.uiSplitInfoOptions.Panel1.PerformLayout();
            this.uiSplitInfoOptions.Panel2.ResumeLayout(false);
            this.uiSplitInfoOptions.ResumeLayout(false);
            this.uiTabInfoPane.ResumeLayout(false);
            this.uiInfoPaneTabPage1.ResumeLayout(false);
            this.uiTabAdvancedOptions.ResumeLayout(false);
            this.uiAdvOptTabPage1.ResumeLayout(false);
            this.uiFlpAdvancedOptions.ResumeLayout(false);
            this.uiGrpIndexer.ResumeLayout(false);
            this.uiGrpIndexer.PerformLayout();
            this.uiGrpSearchResults.ResumeLayout(false);
            this.uiGrpSearchResults.PerformLayout();
            this.uiGrpIntegration.ResumeLayout(false);
            this.uiGrpIntegration.PerformLayout();
            this.uiGrpFolderGroups.ResumeLayout(false);
            this.uiGrpFolderGroups.PerformLayout();
            this.uiGrpShortcuts.ResumeLayout(false);
            this.uiGrpShortcuts.PerformLayout();
            this.uiMainTSContainer.ContentPanel.ResumeLayout(false);
            this.uiMainTSContainer.TopToolStripPanel.ResumeLayout(false);
            this.uiMainTSContainer.TopToolStripPanel.PerformLayout();
            this.uiMainTSContainer.ResumeLayout(false);
            this.uiMainTSContainer.PerformLayout();
            this.uiSplitLeftRight.Panel1.ResumeLayout(false);
            this.uiSplitLeftRight.Panel2.ResumeLayout(false);
            this.uiSplitLeftRight.ResumeLayout(false);
            this.uiTSMainMenu.ResumeLayout(false);
            this.uiTSMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon uiNotifyIcon;
		private System.Windows.Forms.ContextMenuStrip uiCMSTray;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIExit;
		private System.Windows.Forms.TreeView uiTVGroups;
		private System.Windows.Forms.FolderBrowserDialog uiFolderBrowserDlg;
		private System.ComponentModel.BackgroundWorker bw;
		private System.Windows.Forms.Button uiBtnViewCache;
		private System.Windows.Forms.StatusStrip uiInfoStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel uiTSLblStatus;
		private System.ComponentModel.BackgroundWorker iconWorker;
		private System.ComponentModel.BackgroundWorker resultWorker;
		private System.Windows.Forms.SplitContainer uiSplitGroupsResults;
		private System.Windows.Forms.DataGridView uiDGVResults;
		private System.Windows.Forms.ContextMenuStrip uiCMSResults;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIExploreResult;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIOpenFiles;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem uiTSMICopyText;
		private System.Windows.Forms.ToolStripMenuItem uiTSMICopyFiles;
		private System.Windows.Forms.ToolStripMenuItem uiTSMICutFiles;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem uiTSMISelectAll;
		private System.Windows.Forms.ToolStripMenuItem uiTSMISelectNone;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIDeleteFiles;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIResizeColumns;
		private System.Windows.Forms.ToolStripStatusLabel uiTSLblInfo;
		private System.Windows.Forms.SplitContainer uiSplitInfoOptions;
		private System.Windows.Forms.ToolStripContainer uiMainTSContainer;
		private System.Windows.Forms.ToolStrip uiTSMainMenu;
		private System.Windows.Forms.ToolStripButton uiTSBtnAdvancedOptions;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton uiTSBtnAbout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton uiTSBtnHideToTray;
		private System.Windows.Forms.ToolStripButton uiTSBtnExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.CheckBox uiChkEntireRows;
		private System.Windows.Forms.GroupBox uiGrpSearchResults;
		private System.Windows.Forms.GroupBox uiGrpIndexer;
		private System.Windows.Forms.GroupBox uiGrpIntegration;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton uiTSBtnHelp;
		private System.Windows.Forms.GroupBox uiGrpFolderGroups;
		private System.Windows.Forms.Button uiBtnDemoGroups;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button uiBtnDesktop;
		private System.Windows.Forms.Button uiBtnQuickLaunch;
		private System.Windows.Forms.Button uiBtnStartMenu;
		private System.Windows.Forms.GroupBox uiGrpShortcuts;
		private System.Windows.Forms.RadioButton uiOptAllUsers;
		private System.Windows.Forms.FlowLayoutPanel uiFlpAdvancedOptions;
		private System.Windows.Forms.RadioButton uiOptJustMe;
		private System.Windows.Forms.ToolStripContainer uiGroupsTSContainer;
		private System.Windows.Forms.ToolStrip uiTSGroups;
		private System.Windows.Forms.ToolStripLabel uiTSLblFolderGroups;
		private System.Windows.Forms.ToolStripButton uiTSLblNewGrp;
		private System.Windows.Forms.ToolStripButton uiTSBtnAddFolder;
		private System.Windows.Forms.ToolStripContainer uiSearchTSContainer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripButton uiTSBtnRename;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripButton uiTSBtnRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripButton uiTSBtnRefresh;
		private System.Windows.Forms.ToolStripDropDownButton uiTSDDAddSysFolder;
		private System.Windows.Forms.ToolStrip uiTSSearch;
		private System.Windows.Forms.ToolStripLabel uiTSLblSearchFor;
		private System.Windows.Forms.ToolStripTextBox uiTSTxtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.SplitContainer uiSplitLeftRight;
		private System.Windows.Forms.ToolTip uiToolTip1;
		private System.Windows.Forms.ToolStripButton uiTSBtnInfoPane;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
		private System.Windows.Forms.ContextMenuStrip uiCMSGroup;
		private System.Windows.Forms.ToolStripMenuItem uiCMSNewGroup;
		private System.Windows.Forms.ToolStripMenuItem uiCMSAddFolder;
		private System.Windows.Forms.ToolStripMenuItem uiCMSDelete;
		private System.Windows.Forms.ToolStripMenuItem uiCMSRefresh;
		private System.Windows.Forms.TabControl uiTabInfoPane;
		private System.Windows.Forms.TabPage uiInfoPaneTabPage1;
		private System.Windows.Forms.TabControl uiTabAdvancedOptions;
		private System.Windows.Forms.TabPage uiAdvOptTabPage1;
		private System.Windows.Forms.Label uiLblInfoPane;
		private System.Windows.Forms.ToolStripMenuItem uiCMSExplore;
		private System.Windows.Forms.ToolStripMenuItem uiCMSRename;
		private System.Windows.Forms.Button uiBtnUnIntegrate;
		private System.Windows.Forms.Button uiBtnIntegrate;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIAddAsGroup;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIStartMenu;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIDesktop;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIMyDocuments;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIMyPictures;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIMyMusic;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIFavorites;
		private System.Windows.Forms.ToolStripMenuItem uiTSMIHistory;
        private System.Windows.Forms.ToolStripLabel uiTSLblMainMenu;
		private System.Windows.Forms.ToolStripLabel uiTSStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton uiTSBtnCheckForUpdates;
        private System.Windows.Forms.Button uiBtnResetToDefaults;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStrip uiToolStripResults;
        private System.Windows.Forms.ToolStripLabel uiTSLblSelection;
        private System.Windows.Forms.ToolStripButton uiTSBtnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton uiTSBtnExplore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton uiTSBtnCut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton uiTSBtnCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton uiTSBtnCopyText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        internal System.Windows.Forms.ToolStripButton uiTSBtnImagePreview;
        private System.Windows.Forms.ToolStripLabel uiTSLblSelect;
        private System.Windows.Forms.ToolStripButton uiTSBtnSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton uiTSBtnSelectNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripLabel uiTSLblColumns;
        private System.Windows.Forms.ToolStripButton uiTSBtnResizeCols;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
	}
}

