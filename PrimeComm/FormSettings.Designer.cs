namespace PrimeComm
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxCompressSpaces = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableAdditionalProgramProcessing = new System.Windows.Forms.CheckBox();
            this.checkBoxRemoveComments = new System.Windows.Forms.CheckBox();
            this.checkBoxObfuscateVariables = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonIcon = new System.Windows.Forms.RadioButton();
            this.radioButtonDimgrob = new System.Windows.Forms.RadioButton();
            this.checkBoxImageMethodDimgrobOptimizeBlacks = new System.Windows.Forms.CheckBox();
            this.radioButtonPixel = new System.Windows.Forms.RadioButton();
            this.checkBoxImageMethodDimgrobOptimizeSimilar = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(324, 426);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(243, 426);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 426);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "&Defaults";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 408);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 54);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Startup";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::PrimeComm.Properties.Settings.Default.SkipConflictingProcessChecking;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "SkipConflictingProcessChecking", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(15, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(320, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Hide warning about conflicting processes when starting";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Program";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBoxCompressSpaces);
            this.groupBox2.Controls.Add(this.checkBoxEnableAdditionalProgramProcessing);
            this.groupBox2.Controls.Add(this.checkBoxRemoveComments);
            this.groupBox2.Controls.Add(this.checkBoxObfuscateVariables);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 172);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program code";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::PrimeComm.Properties.Settings.Default.IgnoreInternalName;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "IgnoreInternalName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(15, 22);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(205, 19);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Ignore the internal program name";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBoxCompressSpaces
            // 
            this.checkBoxCompressSpaces.AutoSize = true;
            this.checkBoxCompressSpaces.Checked = global::PrimeComm.Properties.Settings.Default.CompressSpaces;
            this.checkBoxCompressSpaces.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "CompressSpaces", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxCompressSpaces.Location = new System.Drawing.Point(35, 122);
            this.checkBoxCompressSpaces.Name = "checkBoxCompressSpaces";
            this.checkBoxCompressSpaces.Size = new System.Drawing.Size(118, 19);
            this.checkBoxCompressSpaces.TabIndex = 0;
            this.checkBoxCompressSpaces.Text = "Compress Spaces";
            this.checkBoxCompressSpaces.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableAdditionalProgramProcessing
            // 
            this.checkBoxEnableAdditionalProgramProcessing.AutoSize = true;
            this.checkBoxEnableAdditionalProgramProcessing.Checked = global::PrimeComm.Properties.Settings.Default.EnableAdditionalProgramProcessing;
            this.checkBoxEnableAdditionalProgramProcessing.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "EnableAdditionalProgramProcessing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxEnableAdditionalProgramProcessing.Location = new System.Drawing.Point(15, 47);
            this.checkBoxEnableAdditionalProgramProcessing.Name = "checkBoxEnableAdditionalProgramProcessing";
            this.checkBoxEnableAdditionalProgramProcessing.Size = new System.Drawing.Size(177, 19);
            this.checkBoxEnableAdditionalProgramProcessing.TabIndex = 0;
            this.checkBoxEnableAdditionalProgramProcessing.Text = "Enable additional processing";
            this.checkBoxEnableAdditionalProgramProcessing.UseVisualStyleBackColor = true;
            this.checkBoxEnableAdditionalProgramProcessing.CheckedChanged += new System.EventHandler(this.something_Changed);
            // 
            // checkBoxRemoveComments
            // 
            this.checkBoxRemoveComments.AutoSize = true;
            this.checkBoxRemoveComments.Checked = global::PrimeComm.Properties.Settings.Default.RemoveComments;
            this.checkBoxRemoveComments.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "RemoveComments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxRemoveComments.Location = new System.Drawing.Point(35, 97);
            this.checkBoxRemoveComments.Name = "checkBoxRemoveComments";
            this.checkBoxRemoveComments.Size = new System.Drawing.Size(129, 19);
            this.checkBoxRemoveComments.TabIndex = 0;
            this.checkBoxRemoveComments.Text = "Remove comments";
            this.checkBoxRemoveComments.UseVisualStyleBackColor = true;
            // 
            // checkBoxObfuscateVariables
            // 
            this.checkBoxObfuscateVariables.AutoSize = true;
            this.checkBoxObfuscateVariables.Checked = global::PrimeComm.Properties.Settings.Default.ObfuscateVariables;
            this.checkBoxObfuscateVariables.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "ObfuscateVariables", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxObfuscateVariables.Location = new System.Drawing.Point(35, 72);
            this.checkBoxObfuscateVariables.Name = "checkBoxObfuscateVariables";
            this.checkBoxObfuscateVariables.Size = new System.Drawing.Size(162, 19);
            this.checkBoxObfuscateVariables.TabIndex = 0;
            this.checkBoxObfuscateVariables.Text = "Obfuscate variable names";
            this.checkBoxObfuscateVariables.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(379, 380);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Images";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonIcon);
            this.groupBox1.Controls.Add(this.radioButtonDimgrob);
            this.groupBox1.Controls.Add(this.checkBoxImageMethodDimgrobOptimizeBlacks);
            this.groupBox1.Controls.Add(this.radioButtonPixel);
            this.groupBox1.Controls.Add(this.checkBoxImageMethodDimgrobOptimizeSimilar);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image processing method";
            // 
            // radioButtonIcon
            // 
            this.radioButtonIcon.AutoSize = true;
            this.radioButtonIcon.Location = new System.Drawing.Point(15, 122);
            this.radioButtonIcon.Name = "radioButtonIcon";
            this.radioButtonIcon.Size = new System.Drawing.Size(150, 19);
            this.radioButtonIcon.TabIndex = 0;
            this.radioButtonIcon.TabStop = true;
            this.radioButtonIcon.Text = "ICON and BLIT_P (PNG)";
            this.radioButtonIcon.UseVisualStyleBackColor = true;
            this.radioButtonIcon.CheckedChanged += new System.EventHandler(this.something_Changed);
            // 
            // radioButtonDimgrob
            // 
            this.radioButtonDimgrob.AutoSize = true;
            this.radioButtonDimgrob.Location = new System.Drawing.Point(15, 47);
            this.radioButtonDimgrob.Name = "radioButtonDimgrob";
            this.radioButtonDimgrob.Size = new System.Drawing.Size(151, 19);
            this.radioButtonDimgrob.TabIndex = 0;
            this.radioButtonDimgrob.TabStop = true;
            this.radioButtonDimgrob.Text = "DIMGROB_P and BLIT_P";
            this.radioButtonDimgrob.UseVisualStyleBackColor = true;
            this.radioButtonDimgrob.CheckedChanged += new System.EventHandler(this.something_Changed);
            // 
            // checkBoxImageMethodDimgrobOptimizeBlacks
            // 
            this.checkBoxImageMethodDimgrobOptimizeBlacks.AutoSize = true;
            this.checkBoxImageMethodDimgrobOptimizeBlacks.Checked = global::PrimeComm.Properties.Settings.Default.ImageMethodDimgrobOptimizeBlacks;
            this.checkBoxImageMethodDimgrobOptimizeBlacks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxImageMethodDimgrobOptimizeBlacks.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "ImageMethodDimgrobOptimizeBlacks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxImageMethodDimgrobOptimizeBlacks.Location = new System.Drawing.Point(35, 97);
            this.checkBoxImageMethodDimgrobOptimizeBlacks.Name = "checkBoxImageMethodDimgrobOptimizeBlacks";
            this.checkBoxImageMethodDimgrobOptimizeBlacks.Size = new System.Drawing.Size(183, 19);
            this.checkBoxImageMethodDimgrobOptimizeBlacks.TabIndex = 1;
            this.checkBoxImageMethodDimgrobOptimizeBlacks.Text = "Use short form for black color";
            this.checkBoxImageMethodDimgrobOptimizeBlacks.UseVisualStyleBackColor = true;
            // 
            // radioButtonPixel
            // 
            this.radioButtonPixel.AutoSize = true;
            this.radioButtonPixel.Location = new System.Drawing.Point(15, 22);
            this.radioButtonPixel.Name = "radioButtonPixel";
            this.radioButtonPixel.Size = new System.Drawing.Size(72, 19);
            this.radioButtonPixel.TabIndex = 0;
            this.radioButtonPixel.TabStop = true;
            this.radioButtonPixel.Text = "PIXON_P";
            this.radioButtonPixel.UseVisualStyleBackColor = true;
            this.radioButtonPixel.CheckedChanged += new System.EventHandler(this.something_Changed);
            // 
            // checkBoxImageMethodDimgrobOptimizeSimilar
            // 
            this.checkBoxImageMethodDimgrobOptimizeSimilar.AutoSize = true;
            this.checkBoxImageMethodDimgrobOptimizeSimilar.Checked = global::PrimeComm.Properties.Settings.Default.ImageMethodDimgrobOptimizeSimilar;
            this.checkBoxImageMethodDimgrobOptimizeSimilar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxImageMethodDimgrobOptimizeSimilar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "ImageMethodDimgrobOptimizeSimilar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxImageMethodDimgrobOptimizeSimilar.Location = new System.Drawing.Point(35, 72);
            this.checkBoxImageMethodDimgrobOptimizeSimilar.Name = "checkBoxImageMethodDimgrobOptimizeSimilar";
            this.checkBoxImageMethodDimgrobOptimizeSimilar.Size = new System.Drawing.Size(205, 19);
            this.checkBoxImageMethodDimgrobOptimizeSimilar.TabIndex = 1;
            this.checkBoxImageMethodDimgrobOptimizeSimilar.Text = "Optimize similar blocks if possible";
            this.checkBoxImageMethodDimgrobOptimizeSimilar.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(379, 380);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 374);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "RegexProgramName";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PrimeComm.Properties.Settings.Default, "RegexProgramName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(125, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = global::PrimeComm.Properties.Settings.Default.RegexProgramName;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxCompressSpaces;
        private System.Windows.Forms.CheckBox checkBoxRemoveComments;
        private System.Windows.Forms.CheckBox checkBoxObfuscateVariables;
        private System.Windows.Forms.CheckBox checkBoxEnableAdditionalProgramProcessing;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPixel;
        private System.Windows.Forms.CheckBox checkBoxImageMethodDimgrobOptimizeBlacks;
        private System.Windows.Forms.CheckBox checkBoxImageMethodDimgrobOptimizeSimilar;
        private System.Windows.Forms.RadioButton radioButtonDimgrob;
        private System.Windows.Forms.RadioButton radioButtonIcon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}