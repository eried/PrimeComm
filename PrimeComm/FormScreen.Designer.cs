namespace PrimeComm
{
    partial class FormScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreen));
            this.pictureBoxScreen = new System.Windows.Forms.PictureBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.captureFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCaptureFrame = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCaptureStream = new System.Windows.Forms.Button();
            this.buttonFullscreen = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxScreen
            // 
            this.pictureBoxScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxScreen.BackColor = System.Drawing.Color.Black;
            this.pictureBoxScreen.ContextMenuStrip = this.contextMenuStripMain;
            this.pictureBoxScreen.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxScreen.Name = "pictureBoxScreen";
            this.pictureBoxScreen.Size = new System.Drawing.Size(303, 209);
            this.pictureBoxScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxScreen.TabIndex = 0;
            this.pictureBoxScreen.TabStop = false;
            this.pictureBoxScreen.DoubleClick += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureFrameToolStripMenuItem,
            this.captureStreamToolStripMenuItem,
            this.toolStripMenuItem1,
            this.fullscreenToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(175, 76);
            this.contextMenuStripMain.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripMain_Opening);
            // 
            // captureFrameToolStripMenuItem
            // 
            this.captureFrameToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.frame;
            this.captureFrameToolStripMenuItem.Name = "captureFrameToolStripMenuItem";
            this.captureFrameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.captureFrameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.captureFrameToolStripMenuItem.Text = "&Capture frame";
            // 
            // captureStreamToolStripMenuItem
            // 
            this.captureStreamToolStripMenuItem.Image = global::PrimeComm.Properties.Resources.stream;
            this.captureStreamToolStripMenuItem.Name = "captureStreamToolStripMenuItem";
            this.captureStreamToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.captureStreamToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.captureStreamToolStripMenuItem.Text = "&Capture stream";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.fullscreenToolStripMenuItem.Text = "Fullscreen";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // buttonCaptureFrame
            // 
            this.buttonCaptureFrame.Image = global::PrimeComm.Properties.Resources.frame;
            this.buttonCaptureFrame.Location = new System.Drawing.Point(93, 3);
            this.buttonCaptureFrame.Name = "buttonCaptureFrame";
            this.buttonCaptureFrame.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptureFrame.TabIndex = 2;
            this.buttonCaptureFrame.Text = "&Frame";
            this.buttonCaptureFrame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCaptureFrame.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(379, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonCaptureStream
            // 
            this.buttonCaptureStream.Image = global::PrimeComm.Properties.Resources.stream;
            this.buttonCaptureStream.Location = new System.Drawing.Point(174, 3);
            this.buttonCaptureStream.Name = "buttonCaptureStream";
            this.buttonCaptureStream.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptureStream.TabIndex = 3;
            this.buttonCaptureStream.Text = "&Stream";
            this.buttonCaptureStream.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCaptureStream.UseVisualStyleBackColor = true;
            // 
            // buttonFullscreen
            // 
            this.buttonFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFullscreen.Location = new System.Drawing.Point(298, 3);
            this.buttonFullscreen.Name = "buttonFullscreen";
            this.buttonFullscreen.Size = new System.Drawing.Size(75, 23);
            this.buttonFullscreen.TabIndex = 4;
            this.buttonFullscreen.Text = "F&ullscreen";
            this.buttonFullscreen.UseVisualStyleBackColor = true;
            this.buttonFullscreen.Click += new System.EventHandler(this.buttonFullscreen_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(12, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Save &to...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            // 
            // panelOptions
            // 
            this.panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptions.Controls.Add(this.buttonBrowse);
            this.panelOptions.Controls.Add(this.buttonCaptureFrame);
            this.panelOptions.Controls.Add(this.buttonCaptureStream);
            this.panelOptions.Controls.Add(this.buttonClose);
            this.panelOptions.Controls.Add(this.buttonFullscreen);
            this.panelOptions.Location = new System.Drawing.Point(0, 266);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(466, 30);
            this.panelOptions.TabIndex = 0;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 301);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(466, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelStatus.Text = "Ready";
            // 
            // FormScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 323);
            this.Controls.Add(this.pictureBoxScreen);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.panelOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 230);
            this.Name = "FormScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrimeScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxScreen;
        private System.Windows.Forms.Button buttonCaptureFrame;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCaptureStream;
        private System.Windows.Forms.Button buttonFullscreen;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem captureFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
    }
}