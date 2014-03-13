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
            this.groupBoxSkin = new System.Windows.Forms.GroupBox();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panelSkin = new System.Windows.Forms.Panel();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.propertyGridComponent = new System.Windows.Forms.PropertyGrid();
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.groupBoxLayout = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBorderReset = new System.Windows.Forms.Button();
            this.buttonBorderFind = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxViewAll = new System.Windows.Forms.CheckBox();
            this.checkBoxViewKeys = new System.Windows.Forms.CheckBox();
            this.checkBoxViewScreen = new System.Windows.Forms.CheckBox();
            this.checkBoxViewRegions = new System.Windows.Forms.CheckBox();
            this.groupBoxSkin.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            this.groupBoxLayout.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSkin
            // 
            this.groupBoxSkin.Controls.Add(this.buttonSaveAs);
            this.groupBoxSkin.Controls.Add(this.buttonSave);
            this.groupBoxSkin.Controls.Add(this.buttonLoad);
            this.groupBoxSkin.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSkin.Name = "groupBoxSkin";
            this.groupBoxSkin.Size = new System.Drawing.Size(255, 59);
            this.groupBoxSkin.TabIndex = 0;
            this.groupBoxSkin.TabStop = false;
            this.groupBoxSkin.Text = "Skin";
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(171, 19);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(75, 27);
            this.buttonSaveAs.TabIndex = 2;
            this.buttonSaveAs.Text = "&Save as...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(90, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 27);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "&Save";
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoad.Image")));
            this.buttonLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoad.Location = new System.Drawing.Point(9, 19);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 27);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "&Load...";
            this.buttonLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
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
            this.panelSkin.Location = new System.Drawing.Point(275, 12);
            this.panelSkin.Name = "panelSkin";
            this.panelSkin.Size = new System.Drawing.Size(437, 637);
            this.panelSkin.TabIndex = 3;
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxProperties.Controls.Add(this.propertyGridComponent);
            this.groupBoxProperties.Controls.Add(this.comboBoxSelection);
            this.groupBoxProperties.Location = new System.Drawing.Point(12, 295);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(255, 354);
            this.groupBoxProperties.TabIndex = 2;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
            // 
            // propertyGridComponent
            // 
            this.propertyGridComponent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGridComponent.Location = new System.Drawing.Point(9, 46);
            this.propertyGridComponent.Name = "propertyGridComponent";
            this.propertyGridComponent.Size = new System.Drawing.Size(237, 291);
            this.propertyGridComponent.TabIndex = 1;
            this.propertyGridComponent.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridComponent_PropertyValueChanged);
            // 
            // comboBoxSelection
            // 
            this.comboBoxSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelection.FormattingEnabled = true;
            this.comboBoxSelection.Location = new System.Drawing.Point(9, 19);
            this.comboBoxSelection.Name = "comboBoxSelection";
            this.comboBoxSelection.Size = new System.Drawing.Size(237, 21);
            this.comboBoxSelection.TabIndex = 0;
            this.comboBoxSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelection_SelectedIndexChanged);
            // 
            // groupBoxLayout
            // 
            this.groupBoxLayout.Controls.Add(this.button2);
            this.groupBoxLayout.Controls.Add(this.buttonBackground);
            this.groupBoxLayout.Controls.Add(this.label1);
            this.groupBoxLayout.Controls.Add(this.buttonBorderReset);
            this.groupBoxLayout.Controls.Add(this.buttonBorderFind);
            this.groupBoxLayout.Location = new System.Drawing.Point(12, 77);
            this.groupBoxLayout.Name = "groupBoxLayout";
            this.groupBoxLayout.Size = new System.Drawing.Size(255, 124);
            this.groupBoxLayout.TabIndex = 1;
            this.groupBoxLayout.TabStop = false;
            this.groupBoxLayout.Text = "Layout";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(73, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 27);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Apply a template layout...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // buttonBackground
            // 
            this.buttonBackground.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackground.Image")));
            this.buttonBackground.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBackground.Location = new System.Drawing.Point(9, 19);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(237, 27);
            this.buttonBackground.TabIndex = 0;
            this.buttonBackground.Text = "&Change background image...";
            this.buttonBackground.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Border used for chromeless mode:";
            // 
            // buttonBorderReset
            // 
            this.buttonBorderReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBorderReset.Enabled = false;
            this.buttonBorderReset.Location = new System.Drawing.Point(171, 83);
            this.buttonBorderReset.Name = "buttonBorderReset";
            this.buttonBorderReset.Size = new System.Drawing.Size(75, 27);
            this.buttonBorderReset.TabIndex = 3;
            this.buttonBorderReset.Text = "&Reset";
            this.toolTipInfo.SetToolTip(this.buttonBorderReset, "Resets the border to a rectangle");
            this.buttonBorderReset.UseVisualStyleBackColor = true;
            this.buttonBorderReset.Click += new System.EventHandler(this.buttonBorderReset_Click);
            // 
            // buttonBorderFind
            // 
            this.buttonBorderFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBorderFind.Enabled = false;
            this.buttonBorderFind.Location = new System.Drawing.Point(9, 83);
            this.buttonBorderFind.Name = "buttonBorderFind";
            this.buttonBorderFind.Size = new System.Drawing.Size(156, 27);
            this.buttonBorderFind.TabIndex = 3;
            this.buttonBorderFind.Text = "&Rebuild from background";
            this.toolTipInfo.SetToolTip(this.buttonBorderFind, "Creates a border using the top left pixel of the background image as reference");
            this.buttonBorderFind.UseVisualStyleBackColor = true;
            this.buttonBorderFind.Click += new System.EventHandler(this.buttonBorderFind_Click);
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxView.Location = new System.Drawing.Point(12, 207);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(255, 82);
            this.groupBoxView.TabIndex = 4;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "View";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewRegions, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewScreen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewKeys, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxViewAll, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(237, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxViewAll
            // 
            this.checkBoxViewAll.AutoSize = true;
            this.checkBoxViewAll.Location = new System.Drawing.Point(3, 3);
            this.checkBoxViewAll.Name = "checkBoxViewAll";
            this.checkBoxViewAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxViewAll.TabIndex = 0;
            this.checkBoxViewAll.Text = "All";
            this.checkBoxViewAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewKeys
            // 
            this.checkBoxViewKeys.AutoSize = true;
            this.checkBoxViewKeys.Location = new System.Drawing.Point(121, 3);
            this.checkBoxViewKeys.Name = "checkBoxViewKeys";
            this.checkBoxViewKeys.Size = new System.Drawing.Size(49, 17);
            this.checkBoxViewKeys.TabIndex = 1;
            this.checkBoxViewKeys.Text = "Keys";
            this.checkBoxViewKeys.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewScreen
            // 
            this.checkBoxViewScreen.AutoSize = true;
            this.checkBoxViewScreen.Location = new System.Drawing.Point(3, 31);
            this.checkBoxViewScreen.Name = "checkBoxViewScreen";
            this.checkBoxViewScreen.Size = new System.Drawing.Size(60, 17);
            this.checkBoxViewScreen.TabIndex = 2;
            this.checkBoxViewScreen.Text = "Screen";
            this.checkBoxViewScreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewRegions
            // 
            this.checkBoxViewRegions.AutoSize = true;
            this.checkBoxViewRegions.Location = new System.Drawing.Point(121, 31);
            this.checkBoxViewRegions.Name = "checkBoxViewRegions";
            this.checkBoxViewRegions.Size = new System.Drawing.Size(65, 17);
            this.checkBoxViewRegions.TabIndex = 3;
            this.checkBoxViewRegions.Text = "Regions";
            this.checkBoxViewRegions.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 661);
            this.Controls.Add(this.groupBoxView);
            this.Controls.Add(this.groupBoxLayout);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.panelSkin);
            this.Controls.Add(this.groupBoxSkin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 480);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBoxSkin.ResumeLayout(false);
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxLayout.ResumeLayout(false);
            this.groupBoxLayout.PerformLayout();
            this.groupBoxView.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSkin;
        private System.Windows.Forms.Panel panelSkin;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.PropertyGrid propertyGridComponent;
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.GroupBox groupBoxLayout;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBorderFind;
        private System.Windows.Forms.Button buttonBorderReset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxViewRegions;
        private System.Windows.Forms.CheckBox checkBoxViewScreen;
        private System.Windows.Forms.CheckBox checkBoxViewKeys;
        private System.Windows.Forms.CheckBox checkBoxViewAll;
    }
}

