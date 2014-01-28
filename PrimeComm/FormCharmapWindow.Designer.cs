namespace PrimeComm
{
    partial class FormCharmapWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCharmapWindow));
            this.vScrollBarChars = new System.Windows.Forms.VScrollBar();
            this.comboBoxPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChar = new System.Windows.Forms.Button();
            this.buttonHex = new System.Windows.Forms.Button();
            this.buttonDec = new System.Windows.Forms.Button();
            this.labelInsertChar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSelectedChar = new System.Windows.Forms.Panel();
            this.labelChar = new System.Windows.Forms.Label();
            this.charmap = new PrimeComm.CharmapGrid();
            this.panelSelectedChar.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBarChars
            // 
            this.vScrollBarChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBarChars.Location = new System.Drawing.Point(622, 31);
            this.vScrollBarChars.Maximum = 65533;
            this.vScrollBarChars.Minimum = 32;
            this.vScrollBarChars.Name = "vScrollBarChars";
            this.vScrollBarChars.Size = new System.Drawing.Size(17, 141);
            this.vScrollBarChars.TabIndex = 1;
            this.vScrollBarChars.Value = 32;
            this.vScrollBarChars.ValueChanged += new System.EventHandler(this.vScrollBarChars_ValueChanged);
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPage.FormattingEnabled = true;
            this.comboBoxPage.Location = new System.Drawing.Point(6, 6);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Size = new System.Drawing.Size(226, 21);
            this.comboBoxPage.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // buttonChar
            // 
            this.buttonChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChar.Enabled = false;
            this.buttonChar.Location = new System.Drawing.Point(590, 5);
            this.buttonChar.Name = "buttonChar";
            this.buttonChar.Size = new System.Drawing.Size(49, 23);
            this.buttonChar.TabIndex = 4;
            this.buttonChar.Text = "&Char";
            this.buttonChar.UseVisualStyleBackColor = true;
            this.buttonChar.Click += new System.EventHandler(this.buttonChar_Click);
            // 
            // buttonHex
            // 
            this.buttonHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHex.Enabled = false;
            this.buttonHex.Location = new System.Drawing.Point(538, 5);
            this.buttonHex.Name = "buttonHex";
            this.buttonHex.Size = new System.Drawing.Size(49, 23);
            this.buttonHex.TabIndex = 4;
            this.buttonHex.Text = "&Hex";
            this.buttonHex.UseVisualStyleBackColor = true;
            this.buttonHex.Click += new System.EventHandler(this.buttonHex_Click);
            // 
            // buttonDec
            // 
            this.buttonDec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDec.Enabled = false;
            this.buttonDec.Location = new System.Drawing.Point(486, 5);
            this.buttonDec.Name = "buttonDec";
            this.buttonDec.Size = new System.Drawing.Size(49, 23);
            this.buttonDec.TabIndex = 4;
            this.buttonDec.Text = "&Dec";
            this.buttonDec.UseVisualStyleBackColor = true;
            this.buttonDec.Click += new System.EventHandler(this.buttonDec_Click);
            // 
            // labelInsertChar
            // 
            this.labelInsertChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInsertChar.AutoSize = true;
            this.labelInsertChar.Location = new System.Drawing.Point(445, 10);
            this.labelInsertChar.Name = "labelInsertChar";
            this.labelInsertChar.Size = new System.Drawing.Size(36, 13);
            this.labelInsertChar.TabIndex = 5;
            this.labelInsertChar.Text = "Insert:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Selected:";
            // 
            // panelSelectedChar
            // 
            this.panelSelectedChar.Controls.Add(this.labelChar);
            this.panelSelectedChar.Controls.Add(this.label3);
            this.panelSelectedChar.Location = new System.Drawing.Point(238, 4);
            this.panelSelectedChar.Name = "panelSelectedChar";
            this.panelSelectedChar.Size = new System.Drawing.Size(156, 23);
            this.panelSelectedChar.TabIndex = 6;
            // 
            // labelChar
            // 
            this.labelChar.AutoSize = true;
            this.labelChar.Location = new System.Drawing.Point(56, 6);
            this.labelChar.Name = "labelChar";
            this.labelChar.Size = new System.Drawing.Size(33, 13);
            this.labelChar.TabIndex = 5;
            this.labelChar.Text = "None";
            // 
            // charmap
            // 
            this.charmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.charmap.FirstCellChar = ' ';
            this.charmap.Location = new System.Drawing.Point(6, 31);
            this.charmap.Name = "charmap";
            this.charmap.SelectedChar = ' ';
            this.charmap.Size = new System.Drawing.Size(616, 141);
            this.charmap.TabIndex = 0;
            this.charmap.DoubleClick += new System.EventHandler(this.charmap_DoubleClick);
            // 
            // FormCharmapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 178);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panelSelectedChar);
            this.Controls.Add(this.labelInsertChar);
            this.Controls.Add(this.buttonDec);
            this.Controls.Add(this.buttonHex);
            this.Controls.Add(this.buttonChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPage);
            this.Controls.Add(this.vScrollBarChars);
            this.Controls.Add(this.charmap);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCharmapWindow";
            this.Text = "Characters";
            this.Shown += new System.EventHandler(this.FormCharmapWindow_Shown);
            this.Resize += new System.EventHandler(this.FormCharmapWindow_Resize);
            this.panelSelectedChar.ResumeLayout(false);
            this.panelSelectedChar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CharmapGrid charmap;
        private System.Windows.Forms.VScrollBar vScrollBarChars;
        private System.Windows.Forms.ComboBox comboBoxPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChar;
        private System.Windows.Forms.Button buttonHex;
        private System.Windows.Forms.Button buttonDec;
        private System.Windows.Forms.Label labelInsertChar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSelectedChar;
        private System.Windows.Forms.Label labelChar;
    }
}