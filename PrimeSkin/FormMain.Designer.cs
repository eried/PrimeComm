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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBoxSkin = new System.Windows.Forms.GroupBox();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panelSkin = new System.Windows.Forms.Panel();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.propertyGridComponent = new System.Windows.Forms.PropertyGrid();
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.groupBoxVisuals = new System.Windows.Forms.GroupBox();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBorderReset = new System.Windows.Forms.Button();
            this.buttonBorderFind = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxSkin.SuspendLayout();
            this.groupBoxComponents.SuspendLayout();
            this.groupBoxVisuals.SuspendLayout();
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
            // groupBoxComponents
            // 
            this.groupBoxComponents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxComponents.Controls.Add(this.propertyGridComponent);
            this.groupBoxComponents.Controls.Add(this.comboBoxSelection);
            this.groupBoxComponents.Location = new System.Drawing.Point(12, 240);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(255, 409);
            this.groupBoxComponents.TabIndex = 2;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Properties";
            // 
            // propertyGridComponent
            // 
            this.propertyGridComponent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGridComponent.Location = new System.Drawing.Point(9, 46);
            this.propertyGridComponent.Name = "propertyGridComponent";
            this.propertyGridComponent.Size = new System.Drawing.Size(237, 346);
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
            // groupBoxVisuals
            // 
            this.groupBoxVisuals.Controls.Add(this.button2);
            this.groupBoxVisuals.Controls.Add(this.buttonBackground);
            this.groupBoxVisuals.Controls.Add(this.label1);
            this.groupBoxVisuals.Controls.Add(this.buttonBorderReset);
            this.groupBoxVisuals.Controls.Add(this.buttonBorderFind);
            this.groupBoxVisuals.Location = new System.Drawing.Point(12, 77);
            this.groupBoxVisuals.Name = "groupBoxVisuals";
            this.groupBoxVisuals.Size = new System.Drawing.Size(255, 157);
            this.groupBoxVisuals.TabIndex = 1;
            this.groupBoxVisuals.TabStop = false;
            this.groupBoxVisuals.Text = "Layout";
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
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Border used for chromeless mode:";
            // 
            // buttonBorderReset
            // 
            this.buttonBorderReset.Enabled = false;
            this.buttonBorderReset.Location = new System.Drawing.Point(171, 116);
            this.buttonBorderReset.Name = "buttonBorderReset";
            this.buttonBorderReset.Size = new System.Drawing.Size(75, 27);
            this.buttonBorderReset.TabIndex = 3;
            this.buttonBorderReset.Text = "&Reset";
            this.buttonBorderReset.UseVisualStyleBackColor = true;
            this.buttonBorderReset.Click += new System.EventHandler(this.buttonBorderReset_Click);
            // 
            // buttonBorderFind
            // 
            this.buttonBorderFind.Enabled = false;
            this.buttonBorderFind.Location = new System.Drawing.Point(9, 116);
            this.buttonBorderFind.Name = "buttonBorderFind";
            this.buttonBorderFind.Size = new System.Drawing.Size(156, 27);
            this.buttonBorderFind.TabIndex = 3;
            this.buttonBorderFind.Text = "&Rebuild from background";
            this.buttonBorderFind.UseVisualStyleBackColor = true;
            this.buttonBorderFind.Click += new System.EventHandler(this.buttonBorderFind_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(9, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 27);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Apply a template layout...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 661);
            this.Controls.Add(this.groupBoxVisuals);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.panelSkin);
            this.Controls.Add(this.groupBoxSkin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 480);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBoxSkin.ResumeLayout(false);
            this.groupBoxComponents.ResumeLayout(false);
            this.groupBoxVisuals.ResumeLayout(false);
            this.groupBoxVisuals.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSkin;
        private System.Windows.Forms.Panel panelSkin;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.PropertyGrid propertyGridComponent;
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.GroupBox groupBoxVisuals;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBorderFind;
        private System.Windows.Forms.Button buttonBorderReset;
        private System.Windows.Forms.Button button2;
    }
}

