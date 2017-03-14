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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDragHere = new System.Windows.Forms.Label();
            this.fileSystemWatcherMonitor = new System.IO.FileSystemWatcher();
            this.checkBoxStep1Select = new System.Windows.Forms.CheckBox();
            this.checkBoxStep2Edit = new System.Windows.Forms.CheckBox();
            this.checkBoxStep3Escape = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelDragHere);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Which program to monitor?";
            // 
            // labelDragHere
            // 
            this.labelDragHere.AllowDrop = true;
            this.labelDragHere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDragHere.Location = new System.Drawing.Point(3, 25);
            this.labelDragHere.Name = "labelDragHere";
            this.labelDragHere.Size = new System.Drawing.Size(645, 103);
            this.labelDragHere.TabIndex = 0;
            this.labelDragHere.Text = "Drag a hpprgm file here";
            this.labelDragHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDragHere.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDragHere_DragDrop);
            this.labelDragHere.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDragHere_DragEnter);
            // 
            // fileSystemWatcherMonitor
            // 
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
            this.checkBoxStep1Select.Location = new System.Drawing.Point(12, 160);
            this.checkBoxStep1Select.Name = "checkBoxStep1Select";
            this.checkBoxStep1Select.Size = new System.Drawing.Size(484, 29);
            this.checkBoxStep1Select.TabIndex = 1;
            this.checkBoxStep1Select.Text = "Select the modified program in the Program Catalog";
            this.checkBoxStep1Select.UseVisualStyleBackColor = true;
            // 
            // checkBoxStep2Edit
            // 
            this.checkBoxStep2Edit.AutoSize = true;
            this.checkBoxStep2Edit.Checked = true;
            this.checkBoxStep2Edit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStep2Edit.Location = new System.Drawing.Point(47, 195);
            this.checkBoxStep2Edit.Name = "checkBoxStep2Edit";
            this.checkBoxStep2Edit.Size = new System.Drawing.Size(258, 29);
            this.checkBoxStep2Edit.TabIndex = 1;
            this.checkBoxStep2Edit.Text = "Edit the modified program";
            this.checkBoxStep2Edit.UseVisualStyleBackColor = true;
            // 
            // checkBoxStep3Escape
            // 
            this.checkBoxStep3Escape.AutoSize = true;
            this.checkBoxStep3Escape.Checked = true;
            this.checkBoxStep3Escape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStep3Escape.Location = new System.Drawing.Point(85, 230);
            this.checkBoxStep3Escape.Name = "checkBoxStep3Escape";
            this.checkBoxStep3Escape.Size = new System.Drawing.Size(512, 29);
            this.checkBoxStep3Escape.TabIndex = 1;
            this.checkBoxStep3Escape.Text = "Escape the modified program to invoke checking errors";
            this.checkBoxStep3Escape.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 283);
            this.Controls.Add(this.checkBoxStep3Escape);
            this.Controls.Add(this.checkBoxStep2Edit);
            this.Controls.Add(this.checkBoxStep1Select);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "PrimeMon";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherMonitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDragHere;
        private System.IO.FileSystemWatcher fileSystemWatcherMonitor;
        private System.Windows.Forms.CheckBox checkBoxStep3Escape;
        private System.Windows.Forms.CheckBox checkBoxStep2Edit;
        private System.Windows.Forms.CheckBox checkBoxStep1Select;
    }
}

