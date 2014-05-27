namespace PrimeSkin
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
            this.panelSkin = new System.Windows.Forms.Panel();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.propertyGridComponent = new System.Windows.Forms.PropertyGrid();
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabelRegionAdd = new System.Windows.Forms.LinkLabel();
            this.linkLabelRegionRemove = new System.Windows.Forms.LinkLabel();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxViewScreen = new System.Windows.Forms.CheckBox();
            this.checkBoxViewKeys = new System.Windows.Forms.CheckBox();
            this.checkBoxViewAll = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxViewRegions = new System.Windows.Forms.CheckBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSave = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBorderFind = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBorderReset = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.addANewRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTheLastRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxProperties.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSkin
            // 
            this.panelSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSkin.AutoScroll = true;
            this.panelSkin.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.panelSkin.BackColor = System.Drawing.Color.White;
            this.panelSkin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSkin.Location = new System.Drawing.Point(254, 27);
            this.panelSkin.Name = "panelSkin";
            this.panelSkin.Size = new System.Drawing.Size(458, 622);
            this.panelSkin.TabIndex = 4;
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxProperties.Controls.Add(this.propertyGridComponent);
            this.groupBoxProperties.Controls.Add(this.comboBoxSelection);
            this.groupBoxProperties.Location = new System.Drawing.Point(12, 115);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(234, 534);
            this.groupBoxProperties.TabIndex = 3;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "&Properties";
            // 
            // propertyGridComponent
            // 
            this.propertyGridComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridComponent.Location = new System.Drawing.Point(9, 46);
            this.propertyGridComponent.Name = "propertyGridComponent";
            this.propertyGridComponent.Size = new System.Drawing.Size(216, 478);
            this.propertyGridComponent.TabIndex = 1;
            this.propertyGridComponent.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridComponent_PropertyValueChanged);
            // 
            // comboBoxSelection
            // 
            this.comboBoxSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelection.FormattingEnabled = true;
            this.comboBoxSelection.Location = new System.Drawing.Point(9, 19);
            this.comboBoxSelection.Name = "comboBoxSelection";
            this.comboBoxSelection.Size = new System.Drawing.Size(216, 21);
            this.comboBoxSelection.TabIndex = 0;
            this.comboBoxSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelection_SelectedIndexChanged);
            // 
            // linkLabelRegionAdd
            // 
            this.linkLabelRegionAdd.AutoSize = true;
            this.linkLabelRegionAdd.Location = new System.Drawing.Point(17, 17);
            this.linkLabelRegionAdd.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.linkLabelRegionAdd.Name = "linkLabelRegionAdd";
            this.linkLabelRegionAdd.Size = new System.Drawing.Size(26, 13);
            this.linkLabelRegionAdd.TabIndex = 1;
            this.linkLabelRegionAdd.TabStop = true;
            this.linkLabelRegionAdd.Text = "Add";
            this.toolTipInfo.SetToolTip(this.linkLabelRegionAdd, "Adds a new region");
            this.linkLabelRegionAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegionAdd_LinkClicked);
            // 
            // linkLabelRegionRemove
            // 
            this.linkLabelRegionRemove.AutoSize = true;
            this.linkLabelRegionRemove.Location = new System.Drawing.Point(49, 17);
            this.linkLabelRegionRemove.Name = "linkLabelRegionRemove";
            this.linkLabelRegionRemove.Size = new System.Drawing.Size(47, 13);
            this.linkLabelRegionRemove.TabIndex = 2;
            this.linkLabelRegionRemove.TabStop = true;
            this.linkLabelRegionRemove.Text = "Remove";
            this.toolTipInfo.SetToolTip(this.linkLabelRegionRemove, "Removes the last region");
            this.linkLabelRegionRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegionRemove_LinkClicked);
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxView.Location = new System.Drawing.Point(12, 27);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(234, 82);
            this.groupBoxView.TabIndex = 2;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "View";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewScreen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewKeys, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(216, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxViewScreen
            // 
            this.checkBoxViewScreen.AutoSize = true;
            this.checkBoxViewScreen.Location = new System.Drawing.Point(0, 20);
            this.checkBoxViewScreen.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxViewScreen.Name = "checkBoxViewScreen";
            this.checkBoxViewScreen.Size = new System.Drawing.Size(60, 17);
            this.checkBoxViewScreen.TabIndex = 2;
            this.checkBoxViewScreen.Text = "S&creen";
            this.checkBoxViewScreen.UseVisualStyleBackColor = true;
            this.checkBoxViewScreen.CheckedChanged += new System.EventHandler(this.checkBoxView_CheckedChanged);
            // 
            // checkBoxViewKeys
            // 
            this.checkBoxViewKeys.AutoSize = true;
            this.checkBoxViewKeys.Location = new System.Drawing.Point(108, 0);
            this.checkBoxViewKeys.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxViewKeys.Name = "checkBoxViewKeys";
            this.checkBoxViewKeys.Size = new System.Drawing.Size(49, 17);
            this.checkBoxViewKeys.TabIndex = 1;
            this.checkBoxViewKeys.Text = "&Keys";
            this.checkBoxViewKeys.UseVisualStyleBackColor = true;
            this.checkBoxViewKeys.CheckedChanged += new System.EventHandler(this.checkBoxView_CheckedChanged);
            // 
            // checkBoxViewAll
            // 
            this.checkBoxViewAll.AutoSize = true;
            this.checkBoxViewAll.Location = new System.Drawing.Point(0, 0);
            this.checkBoxViewAll.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxViewAll.Name = "checkBoxViewAll";
            this.checkBoxViewAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxViewAll.TabIndex = 0;
            this.checkBoxViewAll.Text = "&All";
            this.checkBoxViewAll.UseVisualStyleBackColor = true;
            this.checkBoxViewAll.CheckedChanged += new System.EventHandler(this.checkBoxViewAll_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBoxViewRegions);
            this.flowLayoutPanel1.Controls.Add(this.linkLabelRegionAdd);
            this.flowLayoutPanel1.Controls.Add(this.linkLabelRegionRemove);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(108, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(108, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // checkBoxViewRegions
            // 
            this.checkBoxViewRegions.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.checkBoxViewRegions, true);
            this.checkBoxViewRegions.Location = new System.Drawing.Point(0, 0);
            this.checkBoxViewRegions.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxViewRegions.Name = "checkBoxViewRegions";
            this.checkBoxViewRegions.Size = new System.Drawing.Size(65, 17);
            this.checkBoxViewRegions.TabIndex = 0;
            this.checkBoxViewRegions.Text = "R&egions";
            this.checkBoxViewRegions.UseVisualStyleBackColor = true;
            this.checkBoxViewRegions.CheckedChanged += new System.EventHandler(this.checkBoxView_CheckedChanged);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(724, 24);
            this.menuStripMain.TabIndex = 5;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLoad,
            this.toolStripMenuItem6,
            this.buttonSave,
            this.buttonSaveAs,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoad.Image")));
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.buttonLoad.Size = new System.Drawing.Size(155, 22);
            this.buttonLoad.Text = "&Open...";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 6);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.buttonSave.Size = new System.Drawing.Size(155, 22);
            this.buttonSave.Text = "&Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(155, 22);
            this.buttonSaveAs.Text = "Save &as...";
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "&Quit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem5,
            this.buttonBackground,
            this.toolStripMenuItem2,
            this.buttonBorderFind,
            this.buttonBorderReset});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(263, 6);
            // 
            // buttonBackground
            // 
            this.buttonBackground.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackground.Image")));
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(266, 22);
            this.buttonBackground.Text = "&Change skin image...";
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(263, 6);
            // 
            // buttonBorderFind
            // 
            this.buttonBorderFind.Name = "buttonBorderFind";
            this.buttonBorderFind.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.buttonBorderFind.Size = new System.Drawing.Size(266, 22);
            this.buttonBorderFind.Text = "&Rebuild skin border from image";
            this.buttonBorderFind.Click += new System.EventHandler(this.buttonBorderFind_Click);
            // 
            // buttonBorderReset
            // 
            this.buttonBorderReset.Name = "buttonBorderReset";
            this.buttonBorderReset.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.buttonBorderReset.Size = new System.Drawing.Size(266, 22);
            this.buttonBorderReset.Text = "Reset &border";
            this.buttonBorderReset.Click += new System.EventHandler(this.buttonBorderReset_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allComponentsToolStripMenuItem,
            this.hideAllToolStripMenuItem,
            this.toolStripMenuItem4,
            this.keysToolStripMenuItem,
            this.screenToolStripMenuItem,
            this.regionsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.addANewRegionToolStripMenuItem,
            this.removeTheLastRegionToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // allComponentsToolStripMenuItem
            // 
            this.allComponentsToolStripMenuItem.Name = "allComponentsToolStripMenuItem";
            this.allComponentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.allComponentsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.allComponentsToolStripMenuItem.Text = "&Show all";
            this.allComponentsToolStripMenuItem.Click += new System.EventHandler(this.allComponentsToolStripMenuItem_Click);
            // 
            // hideAllToolStripMenuItem
            // 
            this.hideAllToolStripMenuItem.Name = "hideAllToolStripMenuItem";
            this.hideAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.hideAllToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.hideAllToolStripMenuItem.Text = "&Hide all";
            this.hideAllToolStripMenuItem.Click += new System.EventHandler(this.hideAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(205, 6);
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.keysToolStripMenuItem.Text = "Keys";
            this.keysToolStripMenuItem.Click += new System.EventHandler(this.keysToolStripMenuItem_Click);
            // 
            // screenToolStripMenuItem
            // 
            this.screenToolStripMenuItem.Name = "screenToolStripMenuItem";
            this.screenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.screenToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.screenToolStripMenuItem.Text = "Screen";
            this.screenToolStripMenuItem.Click += new System.EventHandler(this.screenToolStripMenuItem_Click);
            // 
            // regionsToolStripMenuItem
            // 
            this.regionsToolStripMenuItem.Name = "regionsToolStripMenuItem";
            this.regionsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.regionsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.regionsToolStripMenuItem.Text = "Regions";
            this.regionsToolStripMenuItem.Click += new System.EventHandler(this.regionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
            // 
            // addANewRegionToolStripMenuItem
            // 
            this.addANewRegionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addANewRegionToolStripMenuItem.Image")));
            this.addANewRegionToolStripMenuItem.Name = "addANewRegionToolStripMenuItem";
            this.addANewRegionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.addANewRegionToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.addANewRegionToolStripMenuItem.Text = "&Add a new region";
            this.addANewRegionToolStripMenuItem.Click += new System.EventHandler(this.addANewRegionToolStripMenuItem_Click);
            // 
            // removeTheLastRegionToolStripMenuItem
            // 
            this.removeTheLastRegionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeTheLastRegionToolStripMenuItem.Image")));
            this.removeTheLastRegionToolStripMenuItem.Name = "removeTheLastRegionToolStripMenuItem";
            this.removeTheLastRegionToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.removeTheLastRegionToolStripMenuItem.Text = "&Remove the last region...";
            this.removeTheLastRegionToolStripMenuItem.Click += new System.EventHandler(this.removeTheLastRegionToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 661);
            this.Controls.Add(this.groupBoxView);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.panelSkin);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(580, 480);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxView.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSkin;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.PropertyGrid propertyGridComponent;
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxViewRegions;
        private System.Windows.Forms.CheckBox checkBoxViewScreen;
        private System.Windows.Forms.CheckBox checkBoxViewKeys;
        private System.Windows.Forms.CheckBox checkBoxViewAll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabelRegionAdd;
        private System.Windows.Forms.LinkLabel linkLabelRegionRemove;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonLoad;
        private System.Windows.Forms.ToolStripMenuItem buttonSave;
        private System.Windows.Forms.ToolStripMenuItem buttonSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem addANewRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTheLastRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonBackground;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem buttonBorderFind;
        private System.Windows.Forms.ToolStripMenuItem buttonBorderReset;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    }
}

