namespace ScintillaNet.Forms.Configuration
{
    partial class StyleConfigControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSample = new System.Windows.Forms.ComboBox();
            this.groupBoxSample = new System.Windows.Forms.GroupBox();
            this.labelSample = new System.Windows.Forms.Label();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.radioButtonLexer = new System.Windows.Forms.RadioButton();
            this.radioButtonLanguage = new System.Windows.Forms.RadioButton();
            this.groupBoxConfig = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxLexer = new System.Windows.Forms.ComboBox();
            this.checkedListBoxAvailableStyles = new System.Windows.Forms.CheckedListBox();
            this.checkBoxEolFilled = new System.Windows.Forms.CheckBox();
            this.checkBoxItalics = new System.Windows.Forms.CheckBox();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.groupBoxStyleSettings = new System.Windows.Forms.GroupBox();
            this.textBoxBackColor = new System.Windows.Forms.TextBox();
            this.textBoxForeColor = new System.Windows.Forms.TextBox();
            this.checkBoxUnderline = new System.Windows.Forms.CheckBox();
            this.labelBackground = new System.Windows.Forms.Label();
            this.labelForeground = new System.Windows.Forms.Label();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.panelSelectedColor = new System.Windows.Forms.Panel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.numericUpDownGreen = new System.Windows.Forms.NumericUpDown();
            this.textBoxHexColor = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.numericUpDownRed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBlue = new System.Windows.Forms.NumericUpDown();
            this.panelBrightness = new System.Windows.Forms.Panel();
            this.labelRGBSelector = new System.Windows.Forms.Label();
            this.fontBrowserFont = new ScintillaNet.Forms.Configuration.FontBrowser();
            this.scintillaControlSample = new ScintillaNet.Scintilla();
            this.groupBoxSample.SuspendLayout();
            this.groupBoxConfig.SuspendLayout();
            this.groupBoxStyleSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSample
            // 
            this.comboBoxSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSample.FormattingEnabled = true;
            this.comboBoxSample.Location = new System.Drawing.Point(54, 19);
            this.comboBoxSample.Name = "comboBoxSample";
            this.comboBoxSample.Size = new System.Drawing.Size(548, 21);
            this.comboBoxSample.TabIndex = 1;
            this.comboBoxSample.SelectedIndexChanged += new System.EventHandler(this.comboBoxSample_SelectedIndexChanged);
            // 
            // groupBoxSample
            // 
            this.groupBoxSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSample.Controls.Add(this.labelSample);
            this.groupBoxSample.Controls.Add(this.comboBoxSample);
            this.groupBoxSample.Controls.Add(this.scintillaControlSample);
            this.groupBoxSample.Location = new System.Drawing.Point(6, 252);
            this.groupBoxSample.Name = "groupBoxSample";
            this.groupBoxSample.Size = new System.Drawing.Size(611, 218);
            this.groupBoxSample.TabIndex = 3;
            this.groupBoxSample.TabStop = false;
            this.groupBoxSample.Text = "Sample";
            // 
            // labelSample
            // 
            this.labelSample.AutoSize = true;
            this.labelSample.Location = new System.Drawing.Point(6, 22);
            this.labelSample.Name = "labelSample";
            this.labelSample.Size = new System.Drawing.Size(42, 13);
            this.labelSample.TabIndex = 4;
            this.labelSample.Text = "Sample";
            // 
            // radioButtonGlobal
            // 
            this.radioButtonGlobal.AutoSize = true;
            this.radioButtonGlobal.Location = new System.Drawing.Point(6, 19);
            this.radioButtonGlobal.Name = "radioButtonGlobal";
            this.radioButtonGlobal.Size = new System.Drawing.Size(55, 17);
            this.radioButtonGlobal.TabIndex = 4;
            this.radioButtonGlobal.TabStop = true;
            this.radioButtonGlobal.Text = "Global";
            this.radioButtonGlobal.UseVisualStyleBackColor = true;
            this.radioButtonGlobal.CheckedChanged += new System.EventHandler(this.radioButtonStyleLevel_CheckedChanged);
            // 
            // radioButtonLexer
            // 
            this.radioButtonLexer.AutoSize = true;
            this.radioButtonLexer.Location = new System.Drawing.Point(6, 42);
            this.radioButtonLexer.Name = "radioButtonLexer";
            this.radioButtonLexer.Size = new System.Drawing.Size(51, 17);
            this.radioButtonLexer.TabIndex = 5;
            this.radioButtonLexer.TabStop = true;
            this.radioButtonLexer.Text = "Lexer";
            this.radioButtonLexer.UseVisualStyleBackColor = true;
            this.radioButtonLexer.CheckedChanged += new System.EventHandler(this.radioButtonStyleLevel_CheckedChanged);
            // 
            // radioButtonLanguage
            // 
            this.radioButtonLanguage.AutoSize = true;
            this.radioButtonLanguage.Location = new System.Drawing.Point(6, 65);
            this.radioButtonLanguage.Name = "radioButtonLanguage";
            this.radioButtonLanguage.Size = new System.Drawing.Size(73, 17);
            this.radioButtonLanguage.TabIndex = 6;
            this.radioButtonLanguage.TabStop = true;
            this.radioButtonLanguage.Text = "Language";
            this.radioButtonLanguage.UseVisualStyleBackColor = true;
            this.radioButtonLanguage.CheckedChanged += new System.EventHandler(this.radioButtonStyleLevel_CheckedChanged);
            // 
            // groupBoxConfig
            // 
            this.groupBoxConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxConfig.Controls.Add(this.comboBoxLanguage);
            this.groupBoxConfig.Controls.Add(this.comboBoxLexer);
            this.groupBoxConfig.Controls.Add(this.radioButtonGlobal);
            this.groupBoxConfig.Controls.Add(this.radioButtonLanguage);
            this.groupBoxConfig.Controls.Add(this.radioButtonLexer);
            this.groupBoxConfig.Location = new System.Drawing.Point(178, 19);
            this.groupBoxConfig.Name = "groupBoxConfig";
            this.groupBoxConfig.Size = new System.Drawing.Size(217, 92);
            this.groupBoxConfig.TabIndex = 7;
            this.groupBoxConfig.TabStop = false;
            this.groupBoxConfig.Text = "Configuration Type";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(77, 61);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(134, 21);
            this.comboBoxLanguage.TabIndex = 9;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // comboBoxLexer
            // 
            this.comboBoxLexer.FormattingEnabled = true;
            this.comboBoxLexer.Location = new System.Drawing.Point(77, 38);
            this.comboBoxLexer.Name = "comboBoxLexer";
            this.comboBoxLexer.Size = new System.Drawing.Size(134, 21);
            this.comboBoxLexer.TabIndex = 8;
            this.comboBoxLexer.SelectedIndexChanged += new System.EventHandler(this.comboBoxLexer_SelectedIndexChanged);
            // 
            // checkedListBoxAvailableStyles
            // 
            this.checkedListBoxAvailableStyles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxAvailableStyles.FormattingEnabled = true;
            this.checkedListBoxAvailableStyles.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxAvailableStyles.Name = "checkedListBoxAvailableStyles";
            this.checkedListBoxAvailableStyles.Size = new System.Drawing.Size(166, 214);
            this.checkedListBoxAvailableStyles.TabIndex = 10;
            this.checkedListBoxAvailableStyles.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAvailableStyles_SelectedIndexChanged);
            // 
            // checkBoxEolFilled
            // 
            this.checkBoxEolFilled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEolFilled.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEolFilled.Location = new System.Drawing.Point(269, 177);
            this.checkBoxEolFilled.Name = "checkBoxEolFilled";
            this.checkBoxEolFilled.Size = new System.Drawing.Size(120, 20);
            this.checkBoxEolFilled.TabIndex = 76;
            this.checkBoxEolFilled.Text = "EOL Filled";
            this.checkBoxEolFilled.ThreeState = true;
            // 
            // checkBoxItalics
            // 
            this.checkBoxItalics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxItalics.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxItalics.Location = new System.Drawing.Point(269, 197);
            this.checkBoxItalics.Name = "checkBoxItalics";
            this.checkBoxItalics.Size = new System.Drawing.Size(120, 20);
            this.checkBoxItalics.TabIndex = 75;
            this.checkBoxItalics.Text = "Italics";
            this.checkBoxItalics.ThreeState = true;
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBold.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBold.Location = new System.Drawing.Point(269, 157);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(120, 20);
            this.checkBoxBold.TabIndex = 74;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.ThreeState = true;
            // 
            // groupBoxStyleSettings
            // 
            this.groupBoxStyleSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStyleSettings.Controls.Add(this.textBoxBackColor);
            this.groupBoxStyleSettings.Controls.Add(this.textBoxForeColor);
            this.groupBoxStyleSettings.Controls.Add(this.checkBoxBold);
            this.groupBoxStyleSettings.Controls.Add(this.checkBoxEolFilled);
            this.groupBoxStyleSettings.Controls.Add(this.checkBoxUnderline);
            this.groupBoxStyleSettings.Controls.Add(this.fontBrowserFont);
            this.groupBoxStyleSettings.Controls.Add(this.checkBoxItalics);
            this.groupBoxStyleSettings.Controls.Add(this.labelBackground);
            this.groupBoxStyleSettings.Controls.Add(this.groupBoxConfig);
            this.groupBoxStyleSettings.Controls.Add(this.labelForeground);
            this.groupBoxStyleSettings.Controls.Add(this.comboBoxFontSize);
            this.groupBoxStyleSettings.Controls.Add(this.labelFont);
            this.groupBoxStyleSettings.Controls.Add(this.checkedListBoxAvailableStyles);
            this.groupBoxStyleSettings.Location = new System.Drawing.Point(216, 3);
            this.groupBoxStyleSettings.Name = "groupBoxStyleSettings";
            this.groupBoxStyleSettings.Size = new System.Drawing.Size(401, 243);
            this.groupBoxStyleSettings.TabIndex = 77;
            this.groupBoxStyleSettings.TabStop = false;
            this.groupBoxStyleSettings.Text = "Style Settings";
            // 
            // textBoxBackColor
            // 
            this.textBoxBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBackColor.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxBackColor.Location = new System.Drawing.Point(180, 209);
            this.textBoxBackColor.Name = "textBoxBackColor";
            this.textBoxBackColor.ReadOnly = true;
            this.textBoxBackColor.Size = new System.Drawing.Size(73, 20);
            this.textBoxBackColor.TabIndex = 98;
            this.textBoxBackColor.Enter += new System.EventHandler(this.TextBoxColor_Enter);
            // 
            // textBoxForeColor
            // 
            this.textBoxForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxForeColor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxForeColor.Location = new System.Drawing.Point(180, 170);
            this.textBoxForeColor.Name = "textBoxForeColor";
            this.textBoxForeColor.ReadOnly = true;
            this.textBoxForeColor.Size = new System.Drawing.Size(73, 20);
            this.textBoxForeColor.TabIndex = 97;
            this.textBoxForeColor.Enter += new System.EventHandler(this.TextBoxColor_Enter);
            // 
            // checkBoxUnderline
            // 
            this.checkBoxUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUnderline.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUnderline.Location = new System.Drawing.Point(269, 217);
            this.checkBoxUnderline.Name = "checkBoxUnderline";
            this.checkBoxUnderline.Size = new System.Drawing.Size(120, 20);
            this.checkBoxUnderline.TabIndex = 96;
            this.checkBoxUnderline.Text = "Underline";
            this.checkBoxUnderline.ThreeState = true;
            // 
            // labelBackground
            // 
            this.labelBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(178, 193);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(65, 13);
            this.labelBackground.TabIndex = 94;
            this.labelBackground.Text = "Background";
            // 
            // labelForeground
            // 
            this.labelForeground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelForeground.AutoSize = true;
            this.labelForeground.Location = new System.Drawing.Point(178, 154);
            this.labelForeground.Name = "labelForeground";
            this.labelForeground.Size = new System.Drawing.Size(61, 13);
            this.labelForeground.TabIndex = 93;
            this.labelForeground.Text = "Foreground";
            // 
            // comboBoxFontSize
            // 
            this.comboBoxFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFontSize.FormattingEnabled = true;
            this.comboBoxFontSize.Location = new System.Drawing.Point(339, 130);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(56, 21);
            this.comboBoxFontSize.TabIndex = 79;
            // 
            // labelFont
            // 
            this.labelFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(178, 114);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(28, 13);
            this.labelFont.TabIndex = 78;
            this.labelFont.Text = "Font";
            // 
            // panelSelectedColor
            // 
            this.panelSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelectedColor.Location = new System.Drawing.Point(38, 185);
            this.panelSelectedColor.Name = "panelSelectedColor";
            this.panelSelectedColor.Size = new System.Drawing.Size(67, 20);
            this.panelSelectedColor.TabIndex = 97;
            this.panelSelectedColor.Visible = false;
            // 
            // panelColor
            // 
            this.panelColor.Location = new System.Drawing.Point(6, 12);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(170, 170);
            this.panelColor.TabIndex = 95;
            this.panelColor.Visible = false;
            // 
            // numericUpDownGreen
            // 
            this.numericUpDownGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGreen.Location = new System.Drawing.Point(86, 208);
            this.numericUpDownGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownGreen.Name = "numericUpDownGreen";
            this.numericUpDownGreen.Size = new System.Drawing.Size(42, 22);
            this.numericUpDownGreen.TabIndex = 91;
            this.numericUpDownGreen.ValueChanged += new System.EventHandler(this.HandleRGBChange);
            // 
            // textBoxHexColor
            // 
            this.textBoxHexColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxHexColor.Location = new System.Drawing.Point(111, 185);
            this.textBoxHexColor.MaxLength = 8;
            this.textBoxHexColor.Name = "textBoxHexColor";
            this.textBoxHexColor.Size = new System.Drawing.Size(65, 20);
            this.textBoxHexColor.TabIndex = 98;
            this.textBoxHexColor.Text = "0x000000";
            this.textBoxHexColor.Leave += new System.EventHandler(this.textBoxHexColor_Leave);
            // 
            // labelColor
            // 
            this.labelColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelColor.Location = new System.Drawing.Point(3, 185);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(48, 20);
            this.labelColor.TabIndex = 94;
            this.labelColor.Text = "Color:";
            this.labelColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownRed
            // 
            this.numericUpDownRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownRed.Location = new System.Drawing.Point(38, 208);
            this.numericUpDownRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownRed.Name = "numericUpDownRed";
            this.numericUpDownRed.Size = new System.Drawing.Size(42, 22);
            this.numericUpDownRed.TabIndex = 90;
            this.numericUpDownRed.ValueChanged += new System.EventHandler(this.HandleRGBChange);
            // 
            // numericUpDownBlue
            // 
            this.numericUpDownBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBlue.Location = new System.Drawing.Point(134, 208);
            this.numericUpDownBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBlue.Name = "numericUpDownBlue";
            this.numericUpDownBlue.Size = new System.Drawing.Size(42, 22);
            this.numericUpDownBlue.TabIndex = 92;
            this.numericUpDownBlue.ValueChanged += new System.EventHandler(this.HandleRGBChange);
            // 
            // panelBrightness
            // 
            this.panelBrightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBrightness.Location = new System.Drawing.Point(182, 12);
            this.panelBrightness.Name = "panelBrightness";
            this.panelBrightness.Size = new System.Drawing.Size(16, 170);
            this.panelBrightness.TabIndex = 96;
            this.panelBrightness.Visible = false;
            // 
            // labelRGBSelector
            // 
            this.labelRGBSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelRGBSelector.Location = new System.Drawing.Point(3, 208);
            this.labelRGBSelector.Name = "labelRGBSelector";
            this.labelRGBSelector.Size = new System.Drawing.Size(48, 23);
            this.labelRGBSelector.TabIndex = 93;
            this.labelRGBSelector.Text = "RGB:";
            this.labelRGBSelector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontBrowserFont
            // 
            this.fontBrowserFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontBrowserFont.Location = new System.Drawing.Point(180, 130);
            this.fontBrowserFont.Name = "fontBrowserFont";
            this.fontBrowserFont.SampleText = "Scintilla.Net";
            this.fontBrowserFont.SelectedFont = "";
            this.fontBrowserFont.ShowName = false;
            this.fontBrowserFont.ShowSample = true;
            this.fontBrowserFont.Size = new System.Drawing.Size(153, 21);
            this.fontBrowserFont.Style = ScintillaNet.Forms.Configuration.FontBrowser.Styles.DropdownListBox;
            this.fontBrowserFont.TabIndex = 95;
            // 
            // scintillaControlSample
            // 
            this.scintillaControlSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scintillaControlSample.ConfigurationManager.Language = null;
            this.scintillaControlSample.IsBraceMatching = false;
            this.scintillaControlSample.Location = new System.Drawing.Point(6, 46);
            this.scintillaControlSample.Name = "scintillaControlSample";
            this.scintillaControlSample.Size = new System.Drawing.Size(596, 166);
            this.scintillaControlSample.Indentation.SmartIndentType = ScintillaNet.SmartIndent.None;
            this.scintillaControlSample.TabIndex = 0;
            // 
            // StyleConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSelectedColor);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.numericUpDownGreen);
            this.Controls.Add(this.textBoxHexColor);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.numericUpDownRed);
            this.Controls.Add(this.numericUpDownBlue);
            this.Controls.Add(this.panelBrightness);
            this.Controls.Add(this.labelRGBSelector);
            this.Controls.Add(this.groupBoxStyleSettings);
            this.Controls.Add(this.groupBoxSample);
            this.MinimumSize = new System.Drawing.Size(620, 473);
            this.Name = "StyleConfigControl";
            this.Size = new System.Drawing.Size(620, 473);
            this.Load += new System.EventHandler(this.StyleConfigControl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleMouse);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleMouse);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StyleConfigControl_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HandleMouseUp);
            this.groupBoxSample.ResumeLayout(false);
            this.groupBoxSample.PerformLayout();
            this.groupBoxConfig.ResumeLayout(false);
            this.groupBoxConfig.PerformLayout();
            this.groupBoxStyleSettings.ResumeLayout(false);
            this.groupBoxStyleSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNet.Scintilla scintillaControlSample;
        private System.Windows.Forms.ComboBox comboBoxSample;
        private System.Windows.Forms.GroupBox groupBoxSample;
        private System.Windows.Forms.Label labelSample;
        private System.Windows.Forms.RadioButton radioButtonGlobal;
        private System.Windows.Forms.RadioButton radioButtonLexer;
        private System.Windows.Forms.RadioButton radioButtonLanguage;
        private System.Windows.Forms.GroupBox groupBoxConfig;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxLexer;
        private System.Windows.Forms.CheckedListBox checkedListBoxAvailableStyles;
        private System.Windows.Forms.CheckBox checkBoxEolFilled;
        private System.Windows.Forms.CheckBox checkBoxItalics;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.GroupBox groupBoxStyleSettings;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.Label labelForeground;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
        private FontBrowser fontBrowserFont;
        internal System.Windows.Forms.Panel panelSelectedColor;
        internal System.Windows.Forms.Panel panelColor;
        internal System.Windows.Forms.NumericUpDown numericUpDownGreen;
        private System.Windows.Forms.TextBox textBoxHexColor;
        internal System.Windows.Forms.Label labelColor;
        internal System.Windows.Forms.NumericUpDown numericUpDownRed;
        internal System.Windows.Forms.NumericUpDown numericUpDownBlue;
        internal System.Windows.Forms.Panel panelBrightness;
        internal System.Windows.Forms.Label labelRGBSelector;
        private System.Windows.Forms.CheckBox checkBoxUnderline;
        private System.Windows.Forms.TextBox textBoxForeColor;
        private System.Windows.Forms.TextBox textBoxBackColor;
    }
}
