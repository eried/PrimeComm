namespace PrimeComm
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.automaticUpdater = new wyDay.Controls.AutomaticUpdater();
            this.labelStatusSubtitle = new System.Windows.Forms.Label();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.buttonReceive = new System.Windows.Forms.Button();
            this.buttonCaptureScreen = new System.Windows.Forms.Button();
            this.openFilesDialogProgram = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogProgram = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorkerSend = new System.ComponentModel.BackgroundWorker();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFromTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectivityKitUserFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.sendToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToEmulatorKitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelReceiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sendClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.captureScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primeSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primeRPLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogProgram = new System.Windows.Forms.OpenFileDialog();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotificationIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerServer = new System.ComponentModel.BackgroundWorker();
            this.toolTipHints = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripSend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual = new System.Windows.Forms.ToolStripMenuItem();
            this.sendClipboardToolStripMenuItemContextual = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItemopenToolStripMenuItemContextual = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItemContextual = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSend = new wyDay.Controls.SplitButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.automaticUpdater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.contextMenuStripNotificationIcon.SuspendLayout();
            this.contextMenuStripSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.automaticUpdater);
            this.groupBox1.Controls.Add(this.labelStatusSubtitle);
            this.groupBox1.Controls.Add(this.pictureBoxStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // automaticUpdater
            // 
            this.automaticUpdater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.automaticUpdater.ContainerForm = this;
            this.automaticUpdater.DaysBetweenChecks = 7;
            this.automaticUpdater.GUID = "8085933a-22bb-4780-a3e8-0b8af6316817";
            this.automaticUpdater.Location = new System.Drawing.Point(316, 19);
            this.automaticUpdater.Name = "automaticUpdater";
            this.automaticUpdater.Size = new System.Drawing.Size(16, 16);
            this.automaticUpdater.TabIndex = 1;
            this.automaticUpdater.Visible = false;
            this.automaticUpdater.wyUpdateCommandline = null;
            // 
            // labelStatusSubtitle
            // 
            this.labelStatusSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatusSubtitle.Location = new System.Drawing.Point(85, 19);
            this.labelStatusSubtitle.Name = "labelStatusSubtitle";
            this.labelStatusSubtitle.Size = new System.Drawing.Size(250, 71);
            this.labelStatusSubtitle.TabIndex = 0;
            this.labelStatusSubtitle.Text = "Unknown";
            this.labelStatusSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxStatus.Image = global::PrimeComm.Properties.Resources.disconnected;
            this.pictureBoxStatus.Location = new System.Drawing.Point(3, 19);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(76, 71);
            this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxStatus.TabIndex = 0;
            this.pictureBoxStatus.TabStop = false;
            // 
            // buttonReceive
            // 
            this.buttonReceive.Location = new System.Drawing.Point(104, 137);
            this.buttonReceive.Name = "buttonReceive";
            this.buttonReceive.Size = new System.Drawing.Size(67, 25);
            this.buttonReceive.TabIndex = 2;
            this.buttonReceive.Text = "&Receive";
            this.buttonReceive.UseVisualStyleBackColor = true;
            this.buttonReceive.Click += new System.EventHandler(this.buttonStopReceive_Click);
            // 
            // buttonCaptureScreen
            // 
            this.buttonCaptureScreen.Location = new System.Drawing.Point(243, 137);
            this.buttonCaptureScreen.Name = "buttonCaptureScreen";
            this.buttonCaptureScreen.Size = new System.Drawing.Size(107, 25);
            this.buttonCaptureScreen.TabIndex = 3;
            this.buttonCaptureScreen.Text = "&Screen capture";
            this.buttonCaptureScreen.UseVisualStyleBackColor = true;
            this.buttonCaptureScreen.Visible = false;
            this.buttonCaptureScreen.Click += new System.EventHandler(this.captureScreenToolStripMenuItem_Click);
            // 
            // openFilesDialogProgram
            // 
            this.openFilesDialogProgram.Multiselect = true;
            this.openFilesDialogProgram.Title = "Select one or more files to send";
            // 
            // saveFileDialogProgram
            // 
            this.saveFileDialogProgram.Title = "Save file";
            // 
            // backgroundWorkerSend
            // 
            this.backgroundWorkerSend.WorkerReportsProgress = true;
            this.backgroundWorkerSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSend_DoWork);
            this.backgroundWorkerSend.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSend_ProgressChanged);
            this.backgroundWorkerSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSend_RunWorkerCompleted);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(362, 24);
            this.menuStripMain.TabIndex = 4;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProgramToolStripMenuItem,
            this.newFromTemplateToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.browseToolStripMenuItem1,
            this.toolStripMenuItem8,
            this.sendToToolStripMenuItem,
            this.saveFromClipboardToolStripMenuItem,
            this.convertFileToolStripMenuItem,
            this.toolStripMenuItem5,
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // newProgramToolStripMenuItem
            // 
            this.newProgramToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.editor_new;
            this.newProgramToolStripMenuItem.Name = "newProgramToolStripMenuItem";
            this.newProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProgramToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.newProgramToolStripMenuItem.Text = "&New program...";
            this.newProgramToolStripMenuItem.Click += new System.EventHandler(this.newProgramToolStripMenuItem_Click);
            // 
            // newFromTemplateToolStripMenuItem
            // 
            this.newFromTemplateToolStripMenuItem.Name = "newFromTemplateToolStripMenuItem";
            this.newFromTemplateToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.newFromTemplateToolStripMenuItem.Text = "New blank program...";
            this.newFromTemplateToolStripMenuItem.Click += new System.EventHandler(this.newFromTemplateToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.editor_open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.recent;
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.recentToolStripMenuItem.Text = "&Recent";
            this.recentToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.recentToolStripMenuItem_DropDownItemClicked);
            // 
            // browseToolStripMenuItem1
            // 
            this.browseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem,
            this.connectivityKitUserFolderToolStripMenuItem});
            this.browseToolStripMenuItem1.Name = "browseToolStripMenuItem1";
            this.browseToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.browseToolStripMenuItem1.Text = "&Browse";
            // 
            // exploreVirtualHPPrimeWorkingFolderToolStripMenuItem
            // 
            this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem.Name = "exploreVirtualHPPrimeWorkingFolderToolStripMenuItem";
            this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem.Text = "&Virtual HP Prime working folder";
            this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem.Click += new System.EventHandler(this.exploreVirtualHPPrimeWorkingFolderToolStripMenuItem_Click);
            // 
            // connectivityKitUserFolderToolStripMenuItem
            // 
            this.connectivityKitUserFolderToolStripMenuItem.Name = "connectivityKitUserFolderToolStripMenuItem";
            this.connectivityKitUserFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.connectivityKitUserFolderToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.connectivityKitUserFolderToolStripMenuItem.Text = "&Connectivity Kit Working folder";
            this.connectivityKitUserFolderToolStripMenuItem.Click += new System.EventHandler(this.connectivityKitUserFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(196, 6);
            // 
            // sendToToolStripMenuItem
            // 
            this.sendToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToEmulatorKitToolStripMenuItem,
            this.sendToCustomToolStripMenuItem});
            this.sendToToolStripMenuItem.Name = "sendToToolStripMenuItem";
            this.sendToToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.sendToToolStripMenuItem.Text = "Send files to";
            // 
            // sendToEmulatorKitToolStripMenuItem
            // 
            this.sendToEmulatorKitToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.editor_send_to_virtual;
            this.sendToEmulatorKitToolStripMenuItem.Name = "sendToEmulatorKitToolStripMenuItem";
            this.sendToEmulatorKitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.sendToEmulatorKitToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.sendToEmulatorKitToolStripMenuItem.Text = "&Virtual HP Prime working folder...";
            this.sendToEmulatorKitToolStripMenuItem.Click += new System.EventHandler(this.sendToEmulatorKitToolStripMenuItem_Click);
            // 
            // sendToCustomToolStripMenuItem
            // 
            this.sendToCustomToolStripMenuItem.Name = "sendToCustomToolStripMenuItem";
            this.sendToCustomToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.sendToCustomToolStripMenuItem.Text = "&Browse destination...";
            this.sendToCustomToolStripMenuItem.Click += new System.EventHandler(this.sendToCustomToolStripMenuItem_Click_1);
            // 
            // saveFromClipboardToolStripMenuItem
            // 
            this.saveFromClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emulatorToolStripMenuItem,
            this.browseToolStripMenuItem});
            this.saveFromClipboardToolStripMenuItem.Name = "saveFromClipboardToolStripMenuItem";
            this.saveFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveFromClipboardToolStripMenuItem.Text = "Send clipboard to";
            // 
            // emulatorToolStripMenuItem
            // 
            this.emulatorToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.editor_send_to_virtual;
            this.emulatorToolStripMenuItem.Name = "emulatorToolStripMenuItem";
            this.emulatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.emulatorToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.emulatorToolStripMenuItem.Text = "&Virtual HP Prime working folder";
            this.emulatorToolStripMenuItem.Click += new System.EventHandler(this.emulatorToolStripMenuItem_Click);
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.browseToolStripMenuItem.Text = "&Browse destination...";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // convertFileToolStripMenuItem
            // 
            this.convertFileToolStripMenuItem.Name = "convertFileToolStripMenuItem";
            this.convertFileToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.convertFileToolStripMenuItem.Text = "&Convert file...";
            this.convertFileToolStripMenuItem.Click += new System.EventHandler(this.convertFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(196, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.settings;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(196, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiveToolStripMenuItem,
            this.cancelReceiveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sendClipboardToolStripMenuItem,
            this.sendFilesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.captureScreenToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "&Device";
            // 
            // receiveToolStripMenuItem
            // 
            this.receiveToolStripMenuItem.Name = "receiveToolStripMenuItem";
            this.receiveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.receiveToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.receiveToolStripMenuItem.Text = "&Receive file";
            this.receiveToolStripMenuItem.Click += new System.EventHandler(this.receiveToolStripMenuItem_Click);
            // 
            // cancelReceiveToolStripMenuItem
            // 
            this.cancelReceiveToolStripMenuItem.Name = "cancelReceiveToolStripMenuItem";
            this.cancelReceiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F8)));
            this.cancelReceiveToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.cancelReceiveToolStripMenuItem.Text = "&Cancel receive";
            this.cancelReceiveToolStripMenuItem.Click += new System.EventHandler(this.cancelReceiveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // sendClipboardToolStripMenuItem
            // 
            this.sendClipboardToolStripMenuItem.Name = "sendClipboardToolStripMenuItem";
            this.sendClipboardToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sendClipboardToolStripMenuItem.Text = "Send clipboard";
            this.sendClipboardToolStripMenuItem.Click += new System.EventHandler(this.sendClipboardToolStripMenuItem_Click);
            // 
            // sendFilesToolStripMenuItem
            // 
            this.sendFilesToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.editor_send_to_device;
            this.sendFilesToolStripMenuItem.Name = "sendFilesToolStripMenuItem";
            this.sendFilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.sendFilesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sendFilesToolStripMenuItem.Text = "Send files...";
            this.sendFilesToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenSend_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // captureScreenToolStripMenuItem
            // 
            this.captureScreenToolStripMenuItem.Name = "captureScreenToolStripMenuItem";
            this.captureScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.captureScreenToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.captureScreenToolStripMenuItem.Text = "&Screen capture";
            this.captureScreenToolStripMenuItem.Visible = false;
            this.captureScreenToolStripMenuItem.Click += new System.EventHandler(this.captureScreenToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primeSkinToolStripMenuItem,
            this.primeRPLToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // primeSkinToolStripMenuItem
            // 
            this.primeSkinToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.primeskin;
            this.primeSkinToolStripMenuItem.Name = "primeSkinToolStripMenuItem";
            this.primeSkinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.primeSkinToolStripMenuItem.Text = "PrimeSkin";
            this.primeSkinToolStripMenuItem.Click += new System.EventHandler(this.primeSkinToolStripMenuItem_Click);
            // 
            // primeRPLToolStripMenuItem
            // 
            this.primeRPLToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.primerpl;
            this.primeRPLToolStripMenuItem.Name = "primeRPLToolStripMenuItem";
            this.primeRPLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.primeRPLToolStripMenuItem.Text = "PrimeRPL";
            this.primeRPLToolStripMenuItem.Visible = false;
            this.primeRPLToolStripMenuItem.Click += new System.EventHandler(this.primeRPLToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandReferenceToolStripMenuItem,
            this.homepageToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // commandReferenceToolStripMenuItem
            // 
            this.commandReferenceToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.help;
            this.commandReferenceToolStripMenuItem.Name = "commandReferenceToolStripMenuItem";
            this.commandReferenceToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.commandReferenceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.commandReferenceToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.commandReferenceToolStripMenuItem.Text = "&Command reference";
            this.commandReferenceToolStripMenuItem.Click += new System.EventHandler(this.commandReferenceToolStripMenuItem_Click);
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.homepageToolStripMenuItem.Text = "&Homepage";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(199, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.info;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotificationIcon;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseUp);
            // 
            // contextMenuStripNotificationIcon
            // 
            this.contextMenuStripNotificationIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripNotificationIcon.Name = "contextMenuStripNotificationIcon";
            this.contextMenuStripNotificationIcon.Size = new System.Drawing.Size(114, 48);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "&Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // backgroundWorkerServer
            // 
            this.backgroundWorkerServer.WorkerReportsProgress = true;
            this.backgroundWorkerServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerServer_DoWork);
            this.backgroundWorkerServer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerServer_ProgressChanged);
            // 
            // contextMenuStripSend
            // 
            this.contextMenuStripSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual,
            this.sendClipboardToolStripMenuItemContextual,
            this.sendFileToolStripSeparator,
            this.newToolStripMenuItemopenToolStripMenuItemContextual,
            this.openToolStripMenuItemContextual});
            this.contextMenuStripSend.Name = "contextMenuStrip1";
            this.contextMenuStripSend.Size = new System.Drawing.Size(154, 98);
            // 
            // sendFileToolStripMenuItemopenToolStripMenuItemContextual
            // 
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual.Image = global::PrimeComm.Properties.Resources.editor_send_to_device;
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual.Name = "sendFileToolStripMenuItemopenToolStripMenuItemContextual";
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual.Size = new System.Drawing.Size(153, 22);
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual.Text = "&Send files...";
            this.sendFileToolStripMenuItemopenToolStripMenuItemContextual.Click += new System.EventHandler(this.buttonOpenSend_Click);
            // 
            // sendClipboardToolStripMenuItemContextual
            // 
            this.sendClipboardToolStripMenuItemContextual.Name = "sendClipboardToolStripMenuItemContextual";
            this.sendClipboardToolStripMenuItemContextual.Size = new System.Drawing.Size(153, 22);
            this.sendClipboardToolStripMenuItemContextual.Text = "Send clipboard";
            this.sendClipboardToolStripMenuItemContextual.Click += new System.EventHandler(this.sendClipboardToolStripMenuItem_Click);
            // 
            // sendFileToolStripSeparator
            // 
            this.sendFileToolStripSeparator.Name = "sendFileToolStripSeparator";
            this.sendFileToolStripSeparator.Size = new System.Drawing.Size(150, 6);
            // 
            // newToolStripMenuItemopenToolStripMenuItemContextual
            // 
            this.newToolStripMenuItemopenToolStripMenuItemContextual.Image = global::PrimeComm.Properties.Resources.editor_new;
            this.newToolStripMenuItemopenToolStripMenuItemContextual.Name = "newToolStripMenuItemopenToolStripMenuItemContextual";
            this.newToolStripMenuItemopenToolStripMenuItemContextual.Size = new System.Drawing.Size(153, 22);
            this.newToolStripMenuItemopenToolStripMenuItemContextual.Text = "&New...";
            this.newToolStripMenuItemopenToolStripMenuItemContextual.Click += new System.EventHandler(this.newProgramToolStripMenuItem_Click);
            // 
            // openToolStripMenuItemContextual
            // 
            this.openToolStripMenuItemContextual.Image = global::PrimeComm.Properties.Resources.editor_open;
            this.openToolStripMenuItemContextual.Name = "openToolStripMenuItemContextual";
            this.openToolStripMenuItemContextual.Size = new System.Drawing.Size(153, 22);
            this.openToolStripMenuItemContextual.Text = "&Open...";
            this.openToolStripMenuItemContextual.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.AllowDrop = true;
            this.buttonSend.AutoSize = true;
            this.buttonSend.ContextMenuStrip = this.contextMenuStripSend;
            this.buttonSend.Image = global::PrimeComm.Properties.Resources.editor_send_to_device;
            this.buttonSend.Location = new System.Drawing.Point(12, 137);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(86, 25);
            this.buttonSend.SplitMenuStrip = this.contextMenuStripSend;
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "&Send...";
            this.buttonSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonOpenSend_Click);
            this.buttonSend.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.buttonSend.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 174);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonCaptureScreen);
            this.Controls.Add(this.buttonReceive);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.automaticUpdater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.contextMenuStripNotificationIcon.ResumeLayout(false);
            this.contextMenuStripSend.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.Label labelStatusSubtitle;
        private System.Windows.Forms.Button buttonReceive;
        private System.Windows.Forms.Button buttonCaptureScreen;
        private System.Windows.Forms.OpenFileDialog openFilesDialogProgram;
        internal System.Windows.Forms.SaveFileDialog saveFileDialogProgram;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSend;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelReceiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem captureScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        internal System.Windows.Forms.OpenFileDialog openFileDialogProgram;
        private System.Windows.Forms.ToolStripMenuItem sendToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToEmulatorKitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToCustomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem newProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exploreVirtualHPPrimeWorkingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectivityKitUserFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFromTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.ComponentModel.BackgroundWorker backgroundWorkerServer;
        private System.Windows.Forms.ToolTip toolTipHints;
        private wyDay.Controls.AutomaticUpdater automaticUpdater;
        private wyDay.Controls.SplitButton buttonSend;
        private System.Windows.Forms.ToolStripMenuItem primeSkinToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSend;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItemopenToolStripMenuItemContextual;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItemContextual;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItemopenToolStripMenuItemContextual;
        private System.Windows.Forms.ToolStripSeparator sendFileToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem sendClipboardToolStripMenuItemContextual;
        private System.Windows.Forms.ToolStripMenuItem primeRPLToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotificationIcon;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}

