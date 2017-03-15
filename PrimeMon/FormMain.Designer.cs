namespace PrimeMon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDragHere = new System.Windows.Forms.Label();
            this.fileSystemWatcherMonitor = new System.IO.FileSystemWatcher();
            this.checkBoxStep1Select = new System.Windows.Forms.CheckBox();
            this.checkBoxStep2Edit = new System.Windows.Forms.CheckBox();
            this.checkBoxStep3Escape = new System.Windows.Forms.CheckBox();
            this.timerExecute = new System.Windows.Forms.Timer(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReference = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherMonitor)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.checkBoxTopMost);
            this.groupBox1.Controls.Add(this.labelDragHere);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(354, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Which program to monitor?";
            // 
            // labelDragHere
            // 
            this.labelDragHere.AllowDrop = true;
            this.labelDragHere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDragHere.Location = new System.Drawing.Point(2, 15);
            this.labelDragHere.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDragHere.Name = "labelDragHere";
            this.labelDragHere.Size = new System.Drawing.Size(350, 71);
            this.labelDragHere.TabIndex = 0;
            this.labelDragHere.Text = "Drag a hpprgm file here";
            this.labelDragHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDragHere.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDragHere_DragDrop);
            this.labelDragHere.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDragHere_DragEnter);
            // 
            // fileSystemWatcherMonitor
            // 
            this.fileSystemWatcherMonitor.EnableRaisingEvents = true;
            this.fileSystemWatcherMonitor.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.Size)));
            this.fileSystemWatcherMonitor.SynchronizingObject = this;
            this.fileSystemWatcherMonitor.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcherMonitor_Changed);
            this.fileSystemWatcherMonitor.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherMonitor_Changed);
            // 
            // checkBoxStep1Select
            // 
            this.checkBoxStep1Select.AutoSize = true;
            this.checkBoxStep1Select.Checked = true;
            this.checkBoxStep1Select.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStep1Select.Enabled = false;
            this.checkBoxStep1Select.Location = new System.Drawing.Point(18, 22);
            this.checkBoxStep1Select.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxStep1Select.Name = "checkBoxStep1Select";
            this.checkBoxStep1Select.Size = new System.Drawing.Size(267, 17);
            this.checkBoxStep1Select.TabIndex = 0;
            this.checkBoxStep1Select.Text = "Select the modified program in the Program Catalog";
            this.checkBoxStep1Select.UseVisualStyleBackColor = true;
            // 
            // checkBoxStep2Edit
            // 
            this.checkBoxStep2Edit.AutoSize = true;
            this.checkBoxStep2Edit.Checked = true;
            this.checkBoxStep2Edit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStep2Edit.Location = new System.Drawing.Point(34, 41);
            this.checkBoxStep2Edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxStep2Edit.Name = "checkBoxStep2Edit";
            this.checkBoxStep2Edit.Size = new System.Drawing.Size(208, 17);
            this.checkBoxStep2Edit.TabIndex = 1;
            this.checkBoxStep2Edit.Text = "E&dit the modified program by opening it";
            this.checkBoxStep2Edit.UseVisualStyleBackColor = true;
            this.checkBoxStep2Edit.CheckedChanged += new System.EventHandler(this.checkBoxStep2Edit_CheckedChanged);
            // 
            // checkBoxStep3Escape
            // 
            this.checkBoxStep3Escape.AutoSize = true;
            this.checkBoxStep3Escape.Checked = true;
            this.checkBoxStep3Escape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStep3Escape.Location = new System.Drawing.Point(51, 60);
            this.checkBoxStep3Escape.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxStep3Escape.Name = "checkBoxStep3Escape";
            this.checkBoxStep3Escape.Size = new System.Drawing.Size(286, 17);
            this.checkBoxStep3Escape.TabIndex = 2;
            this.checkBoxStep3Escape.Text = "E&scape the modified program to invoke checking errors";
            this.checkBoxStep3Escape.UseVisualStyleBackColor = true;
            // 
            // timerExecute
            // 
            this.timerExecute.Tick += new System.EventHandler(this.timerExecute_Tick);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(310, 196);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(51, 25);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.Location = new System.Drawing.Point(201, 196);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(105, 25);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.Text = "Edit &Program";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipInfo.SetToolTip(this.buttonEdit, "Trigger the program editor in the Virtual Prime");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.checkBoxStep1Select);
            this.groupBox2.Controls.Add(this.checkBoxStep2Edit);
            this.groupBox2.Controls.Add(this.checkBoxStep3Escape);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(7, 99);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(354, 88);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions after the program changes";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Controls.Add(this.buttonReference, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonExit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonReference
            // 
            this.buttonReference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReference.Image = ((System.Drawing.Image)(resources.GetObject("buttonReference.Image")));
            this.buttonReference.Location = new System.Drawing.Point(7, 196);
            this.buttonReference.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReference.Name = "buttonReference";
            this.buttonReference.Size = new System.Drawing.Size(106, 25);
            this.buttonReference.TabIndex = 4;
            this.buttonReference.Text = "&Reference";
            this.buttonReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReference.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipInfo.SetToolTip(this.buttonReference, "Show the commands reference");
            this.buttonReference.UseVisualStyleBackColor = true;
            this.buttonReference.Visible = false;
            this.buttonReference.Click += new System.EventHandler(this.buttonReference_Click);
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Checked = true;
            this.checkBoxTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTopMost.Location = new System.Drawing.Point(285, 0);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(64, 17);
            this.checkBoxTopMost.TabIndex = 1;
            this.checkBoxTopMost.Text = "On top";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.CheckedChanged += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 233);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "PrimeMon";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherMonitor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDragHere;
        private System.IO.FileSystemWatcher fileSystemWatcherMonitor;
        private System.Windows.Forms.CheckBox checkBoxStep3Escape;
        private System.Windows.Forms.CheckBox checkBoxStep2Edit;
        private System.Windows.Forms.CheckBox checkBoxStep1Select;
        private System.Windows.Forms.Timer timerExecute;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonReference;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
    }
}

