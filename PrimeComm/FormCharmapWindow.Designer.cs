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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.comboBoxPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChar = new System.Windows.Forms.Button();
            this.buttonHex = new System.Windows.Forms.Button();
            this.buttonDec = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelChar = new System.Windows.Forms.Label();
            this.charmap = new PrimeComm.CharmapGrid();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(656, 31);
            this.vScrollBar1.Maximum = 65533;
            this.vScrollBar1.Minimum = 32;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 141);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Value = 32;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
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
            this.buttonChar.Location = new System.Drawing.Point(624, 5);
            this.buttonChar.Name = "buttonChar";
            this.buttonChar.Size = new System.Drawing.Size(49, 23);
            this.buttonChar.TabIndex = 4;
            this.buttonChar.Text = "&Char";
            this.buttonChar.UseVisualStyleBackColor = true;
            // 
            // buttonHex
            // 
            this.buttonHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHex.Enabled = false;
            this.buttonHex.Location = new System.Drawing.Point(572, 5);
            this.buttonHex.Name = "buttonHex";
            this.buttonHex.Size = new System.Drawing.Size(49, 23);
            this.buttonHex.TabIndex = 4;
            this.buttonHex.Text = "&Hex";
            this.buttonHex.UseVisualStyleBackColor = true;
            // 
            // buttonDec
            // 
            this.buttonDec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDec.Enabled = false;
            this.buttonDec.Location = new System.Drawing.Point(520, 5);
            this.buttonDec.Name = "buttonDec";
            this.buttonDec.Size = new System.Drawing.Size(49, 23);
            this.buttonDec.TabIndex = 4;
            this.buttonDec.Text = "&Dec";
            this.buttonDec.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Insert:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Code:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelChar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(238, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 23);
            this.panel1.TabIndex = 6;
            // 
            // labelChar
            // 
            this.labelChar.AutoSize = true;
            this.labelChar.Location = new System.Drawing.Point(44, 6);
            this.labelChar.Name = "labelChar";
            this.labelChar.Size = new System.Drawing.Size(41, 13);
            this.labelChar.TabIndex = 5;
            this.labelChar.Text = "0 (#0h)";
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
            this.charmap.Size = new System.Drawing.Size(650, 141);
            this.charmap.TabIndex = 0;
            // 
            // FormCharmapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 178);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDec);
            this.Controls.Add(this.buttonHex);
            this.Controls.Add(this.buttonChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPage);
            this.Controls.Add(this.vScrollBar1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CharmapGrid charmap;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ComboBox comboBoxPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChar;
        private System.Windows.Forms.Button buttonHex;
        private System.Windows.Forms.Button buttonDec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelChar;
    }
}