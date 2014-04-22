namespace PrimeHelp
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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.listBoxTerms = new System.Windows.Forms.ListBox();
            this.textBoxView = new System.Windows.Forms.TextBox();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(13, 13);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(241, 25);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // listBoxTerms
            // 
            this.listBoxTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxTerms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxTerms.FormattingEnabled = true;
            this.listBoxTerms.IntegralHeight = false;
            this.listBoxTerms.ItemHeight = 18;
            this.listBoxTerms.Location = new System.Drawing.Point(13, 46);
            this.listBoxTerms.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxTerms.Name = "listBoxTerms";
            this.listBoxTerms.Size = new System.Drawing.Size(241, 438);
            this.listBoxTerms.TabIndex = 1;
            this.listBoxTerms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxTerms_DrawItem);
            this.listBoxTerms.SelectedValueChanged += new System.EventHandler(this.listBoxTerms_SelectedValueChanged);
            this.listBoxTerms.KeyUp += new System.Windows.Forms.KeyEventHandler(this.control_KeyUp);
            // 
            // textBoxView
            // 
            this.textBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxView.Location = new System.Drawing.Point(262, 13);
            this.textBoxView.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxView.Multiline = true;
            this.textBoxView.Name = "textBoxView";
            this.textBoxView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxView.Size = new System.Drawing.Size(427, 471);
            this.textBoxView.TabIndex = 2;
            this.textBoxView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.control_KeyUp);
            // 
            // backgroundWorkerLoad
            // 
            this.backgroundWorkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoad_DoWork);
            this.backgroundWorkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoad_RunWorkerCompleted);
            // 
            // timerSearch
            // 
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.WorkerSupportsCancellation = true;
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 497);
            this.Controls.Add(this.textBoxView);
            this.Controls.Add(this.listBoxTerms);
            this.Controls.Add(this.textBoxSearch);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrimeHelp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ListBox listBoxTerms;
        private System.Windows.Forms.TextBox textBoxView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoad;
        private System.Windows.Forms.Timer timerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
    }
}

