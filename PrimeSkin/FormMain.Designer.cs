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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGridComponent = new System.Windows.Forms.PropertyGrid();
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.groupBoxVisuals = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBoxSkin.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.groupBoxSkin.Size = new System.Drawing.Size(275, 59);
            this.groupBoxSkin.TabIndex = 0;
            this.groupBoxSkin.TabStop = false;
            this.groupBoxSkin.Text = "Skin";
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Enabled = false;
            this.buttonSaveAs.Location = new System.Drawing.Point(180, 21);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAs.TabIndex = 2;
            this.buttonSaveAs.Text = "&Save as...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(99, 21);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(18, 21);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "&Load";
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
            this.panelSkin.Location = new System.Drawing.Point(293, 12);
            this.panelSkin.Name = "panelSkin";
            this.panelSkin.Size = new System.Drawing.Size(438, 747);
            this.panelSkin.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.propertyGridComponent);
            this.groupBox1.Controls.Add(this.comboBoxSelection);
            this.groupBox1.Location = new System.Drawing.Point(12, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 519);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Components";
            // 
            // propertyGridComponent
            // 
            this.propertyGridComponent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGridComponent.Location = new System.Drawing.Point(18, 46);
            this.propertyGridComponent.Name = "propertyGridComponent";
            this.propertyGridComponent.Size = new System.Drawing.Size(237, 467);
            this.propertyGridComponent.TabIndex = 1;
            // 
            // comboBoxSelection
            // 
            this.comboBoxSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelection.FormattingEnabled = true;
            this.comboBoxSelection.Location = new System.Drawing.Point(18, 19);
            this.comboBoxSelection.Name = "comboBoxSelection";
            this.comboBoxSelection.Size = new System.Drawing.Size(237, 21);
            this.comboBoxSelection.TabIndex = 0;
            this.comboBoxSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelection_SelectedIndexChanged);
            // 
            // groupBoxVisuals
            // 
            this.groupBoxVisuals.Controls.Add(this.checkBox1);
            this.groupBoxVisuals.Controls.Add(this.buttonBackground);
            this.groupBoxVisuals.Controls.Add(this.label1);
            this.groupBoxVisuals.Controls.Add(this.button4);
            this.groupBoxVisuals.Enabled = false;
            this.groupBoxVisuals.Location = new System.Drawing.Point(12, 77);
            this.groupBoxVisuals.Name = "groupBoxVisuals";
            this.groupBoxVisuals.Size = new System.Drawing.Size(275, 157);
            this.groupBoxVisuals.TabIndex = 1;
            this.groupBoxVisuals.TabStop = false;
            this.groupBoxVisuals.Text = "Visuals";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(208, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Copy the background near the skin file";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(18, 19);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(237, 23);
            this.buttonBackground.TabIndex = 0;
            this.buttonBackground.Text = "&Change background...";
            this.buttonBackground.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Border used for chromeless mode:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 118);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(237, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "&Rebuild border from transparency";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 771);
            this.Controls.Add(this.groupBoxVisuals);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelSkin);
            this.Controls.Add(this.groupBoxSkin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 480);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBoxSkin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGridComponent;
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.GroupBox groupBoxVisuals;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
    }
}

