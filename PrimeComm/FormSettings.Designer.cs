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
            this.tabControlPreferences = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.linkLabelClearWarnings = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageEditor = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabelClearRecent = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageProgram = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPageImages = new System.Windows.Forms.TabPage();
            this.groupBoxDithering = new System.Windows.Forms.GroupBox();
            this.linkLabelDitheringInfo = new System.Windows.Forms.LinkLabel();
            this.comboBoxImageDitheringMethod = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonIcon = new System.Windows.Forms.RadioButton();
            this.radioButtonDimgrob = new System.Windows.Forms.RadioButton();
            this.radioButtonPixel = new System.Windows.Forms.RadioButton();
            this.tabPageEmulator = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBoxCommandsSpecial = new System.Windows.Forms.ComboBox();
            this.comboBoxCommandsKeys = new System.Windows.Forms.ComboBox();
            this.textBoxCommands = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.checkBoxHideAsNotificationIcon = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchReferenceOnSelectionChanged = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchReferenceOnTextChanged = new System.Windows.Forms.CheckBox();
            this.checkBoxRestorePrimeComm = new System.Windows.Forms.CheckBox();
            this.checkBoxMinimizePrimeComm = new System.Windows.Forms.CheckBox();
            this.checkBoxIndentationTabs = new System.Windows.Forms.CheckBox();
            this.checkBoxWordWrap = new System.Windows.Forms.CheckBox();
            this.numericUpDownIndentation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRecentFiles = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxCompressSpacesMore = new System.Windows.Forms.CheckBox();
            this.checkBoxCompressSpaces = new System.Windows.Forms.CheckBox();
            this.checkBoxConversionComment = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableAdditionalProgramProcessing = new System.Windows.Forms.CheckBox();
            this.checkBoxRemoveComments = new System.Windows.Forms.CheckBox();
            this.checkBoxObfuscateVariables = new System.Windows.Forms.CheckBox();
            this.checkBoxImageMethodDimgrobOptimizeBlacks = new System.Windows.Forms.CheckBox();
            this.checkBoxImageMethodDimgrobOptimizeSimilar = new System.Windows.Forms.CheckBox();
            this.tabControlPreferences.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageEditor.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageProgram.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageImages.SuspendLayout();
            this.groupBoxDithering.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageEmulator.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndentation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecentFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(324, 425);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 24);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(243, 425);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 24);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 425);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 24);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "&Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // tabControlPreferences
            // 
            this.tabControlPreferences.Controls.Add(this.tabPageGeneral);
            this.tabControlPreferences.Controls.Add(this.tabPageEditor);
            this.tabControlPreferences.Controls.Add(this.tabPageProgram);
            this.tabControlPreferences.Controls.Add(this.tabPageImages);
            this.tabControlPreferences.Controls.Add(this.tabPageEmulator);
            this.tabControlPreferences.Controls.Add(this.tabPageAdvanced);
            this.tabControlPreferences.Location = new System.Drawing.Point(12, 12);
            this.tabControlPreferences.Name = "tabControlPreferences";
            this.tabControlPreferences.SelectedIndex = 0;
            this.tabControlPreferences.Size = new System.Drawing.Size(387, 408);
            this.tabControlPreferences.TabIndex = 1;
            this.tabControlPreferences.SelectedIndexChanged += new System.EventHandler(this.tabControlPreferences_SelectedIndexChanged);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.groupBox7);
            this.tabPageGeneral.Controls.Add(this.linkLabelClearWarnings);
            this.tabPageGeneral.Controls.Add(this.groupBox3);
            this.tabPageGeneral.Controls.Add(this.label1);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(379, 380);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBoxHideAsNotificationIcon);
            this.groupBox7.Location = new System.Drawing.Point(6, 91);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(367, 55);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Behaviour";
            // 
            // linkLabelClearWarnings
            // 
            this.linkLabelClearWarnings.AutoSize = true;
            this.linkLabelClearWarnings.Location = new System.Drawing.Point(88, 349);
            this.linkLabelClearWarnings.Name = "linkLabelClearWarnings";
            this.linkLabelClearWarnings.Size = new System.Drawing.Size(74, 15);
            this.linkLabelClearWarnings.TabIndex = 3;
            this.linkLabelClearWarnings.TabStop = true;
            this.linkLabelClearWarnings.Text = "clicking here";
            this.linkLabelClearWarnings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearWarnings_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 79);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Startup";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(269, 48);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(66, 15);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Check now";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(15, 47);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(239, 19);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Check for program updates once a week";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Some notes and warning messages appear only once. You can restore them";
            // 
            // tabPageEditor
            // 
            this.tabPageEditor.Controls.Add(this.groupBox6);
            this.tabPageEditor.Controls.Add(this.groupBox5);
            this.tabPageEditor.Controls.Add(this.groupBox4);
            this.tabPageEditor.Location = new System.Drawing.Point(4, 24);
            this.tabPageEditor.Name = "tabPageEditor";
            this.tabPageEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditor.Size = new System.Drawing.Size(379, 380);
            this.tabPageEditor.TabIndex = 4;
            this.tabPageEditor.Text = "Editor";
            this.tabPageEditor.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBoxSearchReferenceOnSelectionChanged);
            this.groupBox6.Controls.Add(this.checkBoxSearchReferenceOnTextChanged);
            this.groupBox6.Location = new System.Drawing.Point(6, 137);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(367, 77);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reference";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxRestorePrimeComm);
            this.groupBox5.Controls.Add(this.checkBoxMinimizePrimeComm);
            this.groupBox5.Location = new System.Drawing.Point(6, 220);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(367, 78);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Behaviour";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxIndentationTabs);
            this.groupBox4.Controls.Add(this.checkBoxWordWrap);
            this.groupBox4.Controls.Add(this.linkLabelClearRecent);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.numericUpDownIndentation);
            this.groupBox4.Controls.Add(this.numericUpDownRecentFiles);
            this.groupBox4.Controls.Add(this.numericUpDownFontSize);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 125);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Editor";
            // 
            // linkLabelClearRecent
            // 
            this.linkLabelClearRecent.AutoSize = true;
            this.linkLabelClearRecent.Location = new System.Drawing.Point(204, 86);
            this.linkLabelClearRecent.Name = "linkLabelClearRecent";
            this.linkLabelClearRecent.Size = new System.Drawing.Size(72, 15);
            this.linkLabelClearRecent.TabIndex = 8;
            this.linkLabelClearRecent.TabStop = true;
            this.linkLabelClearRecent.Text = "Clear entries";
            this.linkLabelClearRecent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearRecent_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Indentation size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maximum recent files:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Default font size:";
            // 
            // tabPageProgram
            // 
            this.tabPageProgram.Controls.Add(this.groupBox2);
            this.tabPageProgram.Location = new System.Drawing.Point(4, 24);
            this.tabPageProgram.Name = "tabPageProgram";
            this.tabPageProgram.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgram.Size = new System.Drawing.Size(379, 380);
            this.tabPageProgram.TabIndex = 1;
            this.tabPageProgram.Text = "Program";
            this.tabPageProgram.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBoxCompressSpacesMore);
            this.groupBox2.Controls.Add(this.checkBoxCompressSpaces);
            this.groupBox2.Controls.Add(this.checkBoxConversionComment);
            this.groupBox2.Controls.Add(this.checkBoxEnableAdditionalProgramProcessing);
            this.groupBox2.Controls.Add(this.checkBoxRemoveComments);
            this.groupBox2.Controls.Add(this.checkBoxObfuscateVariables);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program code";
            // 
            // tabPageImages
            // 
            this.tabPageImages.Controls.Add(this.groupBoxDithering);
            this.tabPageImages.Controls.Add(this.groupBox1);
            this.tabPageImages.Location = new System.Drawing.Point(4, 24);
            this.tabPageImages.Name = "tabPageImages";
            this.tabPageImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImages.Size = new System.Drawing.Size(379, 380);
            this.tabPageImages.TabIndex = 3;
            this.tabPageImages.Text = "Images";
            this.tabPageImages.UseVisualStyleBackColor = true;
            // 
            // groupBoxDithering
            // 
            this.groupBoxDithering.Controls.Add(this.linkLabelDitheringInfo);
            this.groupBoxDithering.Controls.Add(this.comboBoxImageDitheringMethod);
            this.groupBoxDithering.Location = new System.Drawing.Point(6, 168);
            this.groupBoxDithering.Name = "groupBoxDithering";
            this.groupBoxDithering.Size = new System.Drawing.Size(367, 69);
            this.groupBoxDithering.TabIndex = 3;
            this.groupBoxDithering.TabStop = false;
            this.groupBoxDithering.Text = "Image processing";
            // 
            // linkLabelDitheringInfo
            // 
            this.linkLabelDitheringInfo.AutoSize = true;
            this.linkLabelDitheringInfo.Location = new System.Drawing.Point(12, 29);
            this.linkLabelDitheringInfo.Name = "linkLabelDitheringInfo";
            this.linkLabelDitheringInfo.Size = new System.Drawing.Size(104, 15);
            this.linkLabelDitheringInfo.TabIndex = 6;
            this.linkLabelDitheringInfo.TabStop = true;
            this.linkLabelDitheringInfo.Text = "Dithering method:";
            this.linkLabelDitheringInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDitheringInfo_LinkClicked);
            // 
            // comboBoxImageDitheringMethod
            // 
            this.comboBoxImageDitheringMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImageDitheringMethod.FormattingEnabled = true;
            this.comboBoxImageDitheringMethod.Location = new System.Drawing.Point(121, 26);
            this.comboBoxImageDitheringMethod.Name = "comboBoxImageDitheringMethod";
            this.comboBoxImageDitheringMethod.Size = new System.Drawing.Size(175, 23);
            this.comboBoxImageDitheringMethod.TabIndex = 4;
            this.comboBoxImageDitheringMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxImageDitheringMethod_SelectedIndexChanged);
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
            this.groupBox1.Text = "Image output method";
            // 
            // radioButtonIcon
            // 
            this.radioButtonIcon.AutoSize = true;
            this.radioButtonIcon.Enabled = false;
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
            // tabPageEmulator
            // 
            this.tabPageEmulator.Controls.Add(this.groupBox8);
            this.tabPageEmulator.Location = new System.Drawing.Point(4, 24);
            this.tabPageEmulator.Name = "tabPageEmulator";
            this.tabPageEmulator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmulator.Size = new System.Drawing.Size(379, 380);
            this.tabPageEmulator.TabIndex = 5;
            this.tabPageEmulator.Text = "Emulator";
            this.tabPageEmulator.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBoxCommandsSpecial);
            this.groupBox8.Controls.Add(this.comboBoxCommandsKeys);
            this.groupBox8.Controls.Add(this.textBoxCommands);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(367, 368);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Commands";
            // 
            // comboBoxCommandsSpecial
            // 
            this.comboBoxCommandsSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommandsSpecial.FormattingEnabled = true;
            this.comboBoxCommandsSpecial.Location = new System.Drawing.Point(188, 339);
            this.comboBoxCommandsSpecial.Name = "comboBoxCommandsSpecial";
            this.comboBoxCommandsSpecial.Size = new System.Drawing.Size(173, 23);
            this.comboBoxCommandsSpecial.TabIndex = 2;
            this.comboBoxCommandsSpecial.DropDown += new System.EventHandler(this.comboBoxCommands_DropDown);
            this.comboBoxCommandsSpecial.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommands_SelectedIndexChanged);
            this.comboBoxCommandsSpecial.DropDownClosed += new System.EventHandler(this.comboBoxCommands_DropDownClosed);
            // 
            // comboBoxCommandsKeys
            // 
            this.comboBoxCommandsKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommandsKeys.FormattingEnabled = true;
            this.comboBoxCommandsKeys.Location = new System.Drawing.Point(9, 339);
            this.comboBoxCommandsKeys.Name = "comboBoxCommandsKeys";
            this.comboBoxCommandsKeys.Size = new System.Drawing.Size(173, 23);
            this.comboBoxCommandsKeys.TabIndex = 1;
            this.comboBoxCommandsKeys.DropDown += new System.EventHandler(this.comboBoxCommands_DropDown);
            this.comboBoxCommandsKeys.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommands_SelectedIndexChanged);
            this.comboBoxCommandsKeys.DropDownClosed += new System.EventHandler(this.comboBoxCommands_DropDownClosed);
            // 
            // textBoxCommands
            // 
            this.textBoxCommands.Location = new System.Drawing.Point(9, 52);
            this.textBoxCommands.Multiline = true;
            this.textBoxCommands.Name = "textBoxCommands";
            this.textBoxCommands.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCommands.Size = new System.Drawing.Size(352, 281);
            this.textBoxCommands.TabIndex = 3;
            this.textBoxCommands.WordWrap = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Write your own emulator commands here. You may define one command (key sequence) " +
    "per line. Commands are case-sensitive.";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(379, 380);
            this.tabPageAdvanced.TabIndex = 2;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideAsNotificationIcon
            // 
            this.checkBoxHideAsNotificationIcon.AutoSize = true;
            this.checkBoxHideAsNotificationIcon.Checked = global::PrimeComm.Properties.Settings.Default.HideAsNotificationIcon;
            this.checkBoxHideAsNotificationIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideAsNotificationIcon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "HideAsNotificationIcon", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxHideAsNotificationIcon.Location = new System.Drawing.Point(15, 22);
            this.checkBoxHideAsNotificationIcon.Name = "checkBoxHideAsNotificationIcon";
            this.checkBoxHideAsNotificationIcon.Size = new System.Drawing.Size(299, 19);
            this.checkBoxHideAsNotificationIcon.TabIndex = 0;
            this.checkBoxHideAsNotificationIcon.Text = "Hide the main program window as notification icon";
            this.checkBoxHideAsNotificationIcon.UseVisualStyleBackColor = true;
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
            // checkBoxSearchReferenceOnSelectionChanged
            // 
            this.checkBoxSearchReferenceOnSelectionChanged.AutoSize = true;
            this.checkBoxSearchReferenceOnSelectionChanged.Checked = global::PrimeComm.Properties.Settings.Default.EditorSearchReferenceSelectionChanged;
            this.checkBoxSearchReferenceOnSelectionChanged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSearchReferenceOnSelectionChanged.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "EditorSearchReferenceSelectionChanged", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSearchReferenceOnSelectionChanged.Location = new System.Drawing.Point(15, 47);
            this.checkBoxSearchReferenceOnSelectionChanged.Name = "checkBoxSearchReferenceOnSelectionChanged";
            this.checkBoxSearchReferenceOnSelectionChanged.Size = new System.Drawing.Size(279, 19);
            this.checkBoxSearchReferenceOnSelectionChanged.TabIndex = 1;
            this.checkBoxSearchReferenceOnSelectionChanged.Text = "Search the reference when a keyword is selected";
            this.checkBoxSearchReferenceOnSelectionChanged.UseVisualStyleBackColor = true;
            // 
            // checkBoxSearchReferenceOnTextChanged
            // 
            this.checkBoxSearchReferenceOnTextChanged.AutoSize = true;
            this.checkBoxSearchReferenceOnTextChanged.Checked = global::PrimeComm.Properties.Settings.Default.EditorSearchReferenceTextChanged;
            this.checkBoxSearchReferenceOnTextChanged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSearchReferenceOnTextChanged.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "EditorSearchReferenceTextChanged", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSearchReferenceOnTextChanged.Location = new System.Drawing.Point(15, 22);
            this.checkBoxSearchReferenceOnTextChanged.Name = "checkBoxSearchReferenceOnTextChanged";
            this.checkBoxSearchReferenceOnTextChanged.Size = new System.Drawing.Size(239, 19);
            this.checkBoxSearchReferenceOnTextChanged.TabIndex = 0;
            this.checkBoxSearchReferenceOnTextChanged.Text = "Search the reference when cursor moves";
            this.checkBoxSearchReferenceOnTextChanged.UseVisualStyleBackColor = true;
            // 
            // checkBoxRestorePrimeComm
            // 
            this.checkBoxRestorePrimeComm.AutoSize = true;
            this.checkBoxRestorePrimeComm.Checked = global::PrimeComm.Properties.Settings.Default.EditorRestoresPrimeComm;
            this.checkBoxRestorePrimeComm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRestorePrimeComm.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "EditorRestoresPrimeComm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxRestorePrimeComm.Location = new System.Drawing.Point(15, 47);
            this.checkBoxRestorePrimeComm.Name = "checkBoxRestorePrimeComm";
            this.checkBoxRestorePrimeComm.Size = new System.Drawing.Size(284, 19);
            this.checkBoxRestorePrimeComm.TabIndex = 1;
            this.checkBoxRestorePrimeComm.Text = "Restore PrimeComm when closing the last editor";
            this.checkBoxRestorePrimeComm.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinimizePrimeComm
            // 
            this.checkBoxMinimizePrimeComm.AutoSize = true;
            this.checkBoxMinimizePrimeComm.Checked = global::PrimeComm.Properties.Settings.Default.EditorMinimizesPrimeComm;
            this.checkBoxMinimizePrimeComm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMinimizePrimeComm.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "EditorMinimizesPrimeComm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxMinimizePrimeComm.Location = new System.Drawing.Point(15, 22);
            this.checkBoxMinimizePrimeComm.Name = "checkBoxMinimizePrimeComm";
            this.checkBoxMinimizePrimeComm.Size = new System.Drawing.Size(279, 19);
            this.checkBoxMinimizePrimeComm.TabIndex = 0;
            this.checkBoxMinimizePrimeComm.Text = "Minimize PrimeComm when opening the editor";
            this.checkBoxMinimizePrimeComm.UseVisualStyleBackColor = true;
            // 
            // checkBoxIndentationTabs
            // 
            this.checkBoxIndentationTabs.AutoSize = true;
            this.checkBoxIndentationTabs.Location = new System.Drawing.Point(207, 57);
            this.checkBoxIndentationTabs.Name = "checkBoxIndentationTabs";
            this.checkBoxIndentationTabs.Size = new System.Drawing.Size(120, 19);
            this.checkBoxIndentationTabs.TabIndex = 5;
            this.checkBoxIndentationTabs.Text = "Convert to spaces";
            this.checkBoxIndentationTabs.UseVisualStyleBackColor = true;
            this.checkBoxIndentationTabs.CheckedChanged += new System.EventHandler(this.checkBoxIndentationTabs_CheckedChanged);
            // 
            // checkBoxWordWrap
            // 
            this.checkBoxWordWrap.AutoSize = true;
            this.checkBoxWordWrap.Checked = global::PrimeComm.Properties.Settings.Default.EditorWordWrap;
            this.checkBoxWordWrap.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "EditorWordWrap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxWordWrap.Location = new System.Drawing.Point(207, 28);
            this.checkBoxWordWrap.Name = "checkBoxWordWrap";
            this.checkBoxWordWrap.Size = new System.Drawing.Size(86, 19);
            this.checkBoxWordWrap.TabIndex = 2;
            this.checkBoxWordWrap.Text = "Word Wrap";
            this.checkBoxWordWrap.UseVisualStyleBackColor = true;
            // 
            // numericUpDownIndentation
            // 
            this.numericUpDownIndentation.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PrimeComm.Properties.Settings.Default, "EditorIndentationSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownIndentation.Location = new System.Drawing.Point(144, 55);
            this.numericUpDownIndentation.Name = "numericUpDownIndentation";
            this.numericUpDownIndentation.Size = new System.Drawing.Size(48, 23);
            this.numericUpDownIndentation.TabIndex = 4;
            this.numericUpDownIndentation.Value = global::PrimeComm.Properties.Settings.Default.EditorIndentationSize;
            // 
            // numericUpDownRecentFiles
            // 
            this.numericUpDownRecentFiles.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PrimeComm.Properties.Settings.Default, "RecentFilesMaximum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownRecentFiles.Location = new System.Drawing.Point(144, 84);
            this.numericUpDownRecentFiles.Name = "numericUpDownRecentFiles";
            this.numericUpDownRecentFiles.Size = new System.Drawing.Size(48, 23);
            this.numericUpDownRecentFiles.TabIndex = 7;
            this.numericUpDownRecentFiles.Value = global::PrimeComm.Properties.Settings.Default.RecentFilesMaximum;
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PrimeComm.Properties.Settings.Default, "EditorFontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(144, 26);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(48, 23);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.Value = global::PrimeComm.Properties.Settings.Default.EditorFontSize;
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
            // checkBoxCompressSpacesMore
            // 
            this.checkBoxCompressSpacesMore.AutoSize = true;
            this.checkBoxCompressSpacesMore.Checked = global::PrimeComm.Properties.Settings.Default.CompressSpacesMore;
            this.checkBoxCompressSpacesMore.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "CompressSpacesMore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxCompressSpacesMore.Location = new System.Drawing.Point(57, 147);
            this.checkBoxCompressSpacesMore.Name = "checkBoxCompressSpacesMore";
            this.checkBoxCompressSpacesMore.Size = new System.Drawing.Size(143, 19);
            this.checkBoxCompressSpacesMore.TabIndex = 0;
            this.checkBoxCompressSpacesMore.Text = "Remove all line breaks";
            this.checkBoxCompressSpacesMore.UseVisualStyleBackColor = true;
            // 
            // checkBoxCompressSpaces
            // 
            this.checkBoxCompressSpaces.AutoSize = true;
            this.checkBoxCompressSpaces.Checked = global::PrimeComm.Properties.Settings.Default.CompressSpaces;
            this.checkBoxCompressSpaces.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "CompressSpaces", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxCompressSpaces.Location = new System.Drawing.Point(35, 122);
            this.checkBoxCompressSpaces.Name = "checkBoxCompressSpaces";
            this.checkBoxCompressSpaces.Size = new System.Drawing.Size(117, 19);
            this.checkBoxCompressSpaces.TabIndex = 0;
            this.checkBoxCompressSpaces.Text = "Compress spaces";
            this.checkBoxCompressSpaces.UseVisualStyleBackColor = true;
            this.checkBoxCompressSpaces.CheckedChanged += new System.EventHandler(this.something_Changed);
            // 
            // checkBoxConversionComment
            // 
            this.checkBoxConversionComment.AutoSize = true;
            this.checkBoxConversionComment.Checked = global::PrimeComm.Properties.Settings.Default.AddCommentOnConversion;
            this.checkBoxConversionComment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConversionComment.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrimeComm.Properties.Settings.Default, "AddCommentOnConversion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxConversionComment.Location = new System.Drawing.Point(15, 172);
            this.checkBoxConversionComment.Name = "checkBoxConversionComment";
            this.checkBoxConversionComment.Size = new System.Drawing.Size(337, 19);
            this.checkBoxConversionComment.TabIndex = 0;
            this.checkBoxConversionComment.Text = "Add a comment when the file was automatically converted";
            this.checkBoxConversionComment.UseVisualStyleBackColor = true;
            this.checkBoxConversionComment.CheckedChanged += new System.EventHandler(this.something_Changed);
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
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 461);
            this.Controls.Add(this.tabControlPreferences);
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
            this.Shown += new System.EventHandler(this.FormSettings_Shown);
            this.tabControlPreferences.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageEditor.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageProgram.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageImages.ResumeLayout(false);
            this.groupBoxDithering.ResumeLayout(false);
            this.groupBoxDithering.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageEmulator.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndentation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecentFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TabControl tabControlPreferences;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageProgram;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxCompressSpaces;
        private System.Windows.Forms.CheckBox checkBoxRemoveComments;
        private System.Windows.Forms.CheckBox checkBoxObfuscateVariables;
        private System.Windows.Forms.CheckBox checkBoxEnableAdditionalProgramProcessing;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TabPage tabPageImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPixel;
        private System.Windows.Forms.CheckBox checkBoxImageMethodDimgrobOptimizeBlacks;
        private System.Windows.Forms.CheckBox checkBoxImageMethodDimgrobOptimizeSimilar;
        private System.Windows.Forms.RadioButton radioButtonDimgrob;
        private System.Windows.Forms.RadioButton radioButtonIcon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabelClearWarnings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxConversionComment;
        private System.Windows.Forms.GroupBox groupBoxDithering;
        private System.Windows.Forms.ComboBox comboBoxImageDitheringMethod;
        private System.Windows.Forms.LinkLabel linkLabelDitheringInfo;
        private System.Windows.Forms.CheckBox checkBoxHideAsNotificationIcon;
        private System.Windows.Forms.TabPage tabPageEditor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxRestorePrimeComm;
        private System.Windows.Forms.CheckBox checkBoxMinimizePrimeComm;
        private System.Windows.Forms.CheckBox checkBoxWordWrap;
        private System.Windows.Forms.LinkLabel linkLabelClearRecent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownRecentFiles;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.CheckBox checkBoxCompressSpacesMore;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBoxSearchReferenceOnSelectionChanged;
        private System.Windows.Forms.CheckBox checkBoxSearchReferenceOnTextChanged;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabPage tabPageEmulator;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBoxCommands;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCommandsSpecial;
        private System.Windows.Forms.ComboBox comboBoxCommandsKeys;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownIndentation;
        private System.Windows.Forms.CheckBox checkBoxIndentationTabs;
    }
}