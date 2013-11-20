namespace PrimeComm
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
            this.labelStatusSubtitle = new System.Windows.Forms.Label();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.buttonReceive = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.hidDevice = new UsbLibrary.UsbHidPort(this.components);
            this.openFileDialogProgram = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogProgram = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorkerSend = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelStatusSubtitle);
            this.groupBox1.Controls.Add(this.pictureBoxStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // labelStatusSubtitle
            // 
            this.labelStatusSubtitle.Location = new System.Drawing.Point(80, 29);
            this.labelStatusSubtitle.Name = "labelStatusSubtitle";
            this.labelStatusSubtitle.Size = new System.Drawing.Size(192, 43);
            this.labelStatusSubtitle.TabIndex = 1;
            this.labelStatusSubtitle.Text = "Unknown";
            this.labelStatusSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Image = global::PrimeComm.Properties.Resources.disconnected;
            this.pictureBoxStatus.Location = new System.Drawing.Point(26, 24);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxStatus.TabIndex = 0;
            this.pictureBoxStatus.TabStop = false;
            // 
            // buttonReceive
            // 
            this.buttonReceive.Location = new System.Drawing.Point(12, 111);
            this.buttonReceive.Name = "buttonReceive";
            this.buttonReceive.Size = new System.Drawing.Size(79, 23);
            this.buttonReceive.TabIndex = 1;
            this.buttonReceive.Text = "&Receive";
            this.buttonReceive.UseVisualStyleBackColor = true;
            this.buttonReceive.Click += new System.EventHandler(this.buttonReceive_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(97, 111);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(79, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "&Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(210, 111);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // hidDevice
            // 
            this.hidDevice.ProductId = 1089;
            this.hidDevice.VendorId = 1008;
            this.hidDevice.OnSpecifiedDeviceArrived += new System.EventHandler(this.usbCalculator_OnSpecifiedDeviceArrived);
            this.hidDevice.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usbCalculator_OnSpecifiedDeviceRemoved);
            this.hidDevice.OnDataReceived += new UsbLibrary.DataReceivedEventHandler(this.usbCalculator_OnDataReceived);
            // 
            // openFileDialogProgram
            // 
            this.openFileDialogProgram.Filter = "All supported files (*.hpprgm;*.txt)|*.hpprgm;*.txt|HP Prime Program (*.hpprgm)|*" +
    ".hpprgm|Text file (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialogProgram.Title = "Select file to send";
            // 
            // saveFileDialogProgram
            // 
            this.saveFileDialogProgram.Filter = "HP Prime Program (*.hpprgm)|*.hpprgm|Text file (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialogProgram.Title = "Save received file";
            // 
            // backgroundWorkerSend
            // 
            this.backgroundWorkerSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSend_DoWork);
            this.backgroundWorkerSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSend_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 146);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonReceive);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UsbLibrary.UsbHidPort hidDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.Label labelStatusSubtitle;
        private System.Windows.Forms.Button buttonReceive;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.OpenFileDialog openFileDialogProgram;
        private System.Windows.Forms.SaveFileDialog saveFileDialogProgram;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSend;
    }
}

