namespace SkipListTest
{
    partial class TestWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SkipListAddResult = new System.Windows.Forms.Label();
            this.SkipListRemoveResult = new System.Windows.Forms.Label();
            this.StandListAddResult = new System.Windows.Forms.Label();
            this.StandListRemoveResult = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StartButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.SkipListAddResult, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SkipListRemoveResult, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.StandListAddResult, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.StandListRemoveResult, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 387);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StartButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.StartButton, 2);
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Location = new System.Drawing.Point(0, 0);
            this.StartButton.Margin = new System.Windows.Forms.Padding(0);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(292, 73);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add 100,000 Items\r\n(Skip List)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Remove 100,000 Items\r\n(Skip List)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add 100,000 Items\r\n(Standard List)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 40);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remove 100,000 Items\r\n(Standard List)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SkipListAddResult
            // 
            this.SkipListAddResult.AutoSize = true;
            this.SkipListAddResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkipListAddResult.Location = new System.Drawing.Point(146, 73);
            this.SkipListAddResult.Margin = new System.Windows.Forms.Padding(0);
            this.SkipListAddResult.Name = "SkipListAddResult";
            this.SkipListAddResult.Size = new System.Drawing.Size(146, 40);
            this.SkipListAddResult.TabIndex = 6;
            this.SkipListAddResult.Text = "Miliseconds";
            this.SkipListAddResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SkipListRemoveResult
            // 
            this.SkipListRemoveResult.AutoSize = true;
            this.SkipListRemoveResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkipListRemoveResult.Location = new System.Drawing.Point(146, 113);
            this.SkipListRemoveResult.Margin = new System.Windows.Forms.Padding(0);
            this.SkipListRemoveResult.Name = "SkipListRemoveResult";
            this.SkipListRemoveResult.Size = new System.Drawing.Size(146, 40);
            this.SkipListRemoveResult.TabIndex = 7;
            this.SkipListRemoveResult.Text = "Miliseconds";
            this.SkipListRemoveResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StandListAddResult
            // 
            this.StandListAddResult.AutoSize = true;
            this.StandListAddResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandListAddResult.Location = new System.Drawing.Point(146, 153);
            this.StandListAddResult.Margin = new System.Windows.Forms.Padding(0);
            this.StandListAddResult.Name = "StandListAddResult";
            this.StandListAddResult.Size = new System.Drawing.Size(146, 40);
            this.StandListAddResult.TabIndex = 8;
            this.StandListAddResult.Text = "Miliseconds";
            this.StandListAddResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StandListRemoveResult
            // 
            this.StandListRemoveResult.AutoSize = true;
            this.StandListRemoveResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandListRemoveResult.Location = new System.Drawing.Point(146, 193);
            this.StandListRemoveResult.Margin = new System.Windows.Forms.Padding(0);
            this.StandListRemoveResult.Name = "StandListRemoveResult";
            this.StandListRemoveResult.Size = new System.Drawing.Size(146, 40);
            this.StandListRemoveResult.TabIndex = 9;
            this.StandListRemoveResult.Text = "Miliseconds";
            this.StandListRemoveResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBox1, 2);
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 233);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.tableLayoutPanel1.SetRowSpan(this.listBox1, 2);
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(292, 154);
            this.listBox1.TabIndex = 0;
            this.listBox1.TabStop = false;
            this.listBox1.UseTabStops = false;
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 387);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestWindow";
            this.Text = "Test Window";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SkipListAddResult;
        private System.Windows.Forms.Label SkipListRemoveResult;
        private System.Windows.Forms.Label StandListAddResult;
        private System.Windows.Forms.Label StandListRemoveResult;
        private System.Windows.Forms.ListBox listBox1;
    }
}