namespace SkipListTest
{
    partial class Form1
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
            this.CurrentList = new System.Windows.Forms.ListBox();
            this.RemoveDropDownList = new System.Windows.Forms.ComboBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TestWindowOpenButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.86301F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.13699F));
            this.tableLayoutPanel1.Controls.Add(this.CurrentList, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.RemoveDropDownList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RemoveButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.AddButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.AddTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TestWindowOpenButton, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 273);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CurrentList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CurrentList, 2);
            this.CurrentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentList.FormattingEnabled = true;
            this.CurrentList.Location = new System.Drawing.Point(0, 100);
            this.CurrentList.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentList.Name = "CurrentList";
            this.CurrentList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.CurrentList.Size = new System.Drawing.Size(292, 173);
            this.CurrentList.TabIndex = 0;
            this.CurrentList.TabStop = false;
            this.CurrentList.UseTabStops = false;
            // 
            // RemoveDropDownList
            // 
            this.RemoveDropDownList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveDropDownList.FormattingEnabled = true;
            this.RemoveDropDownList.Location = new System.Drawing.Point(0, 60);
            this.RemoveDropDownList.Margin = new System.Windows.Forms.Padding(0);
            this.RemoveDropDownList.MaxDropDownItems = 100;
            this.RemoveDropDownList.Name = "RemoveDropDownList";
            this.RemoveDropDownList.Size = new System.Drawing.Size(203, 21);
            this.RemoveDropDownList.TabIndex = 0;
            this.RemoveDropDownList.TabStop = false;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(203, 60);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(0);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(89, 20);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.TabStop = false;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(203, 40);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(89, 20);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddTextBox
            // 
            this.AddTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTextBox.Location = new System.Drawing.Point(0, 40);
            this.AddTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(203, 20);
            this.AddTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Skip List Test";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestWindowOpenButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TestWindowOpenButton, 2);
            this.TestWindowOpenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestWindowOpenButton.Location = new System.Drawing.Point(0, 80);
            this.TestWindowOpenButton.Margin = new System.Windows.Forms.Padding(0);
            this.TestWindowOpenButton.Name = "TestWindowOpenButton";
            this.TestWindowOpenButton.Size = new System.Drawing.Size(292, 20);
            this.TestWindowOpenButton.TabIndex = 0;
            this.TestWindowOpenButton.TabStop = false;
            this.TestWindowOpenButton.Text = "Open Test Window";
            this.TestWindowOpenButton.UseVisualStyleBackColor = true;
            this.TestWindowOpenButton.Click += new System.EventHandler(this.TestWindowOpenButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Skip List Test";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox CurrentList;
        private System.Windows.Forms.ComboBox RemoveDropDownList;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox AddTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TestWindowOpenButton;
    }
}

