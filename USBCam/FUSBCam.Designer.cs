namespace USBCam
{
    partial class FUSBCam
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
            this.BOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NUpDownExposureTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.GBFrameGrab = new System.Windows.Forms.GroupBox();
            this.BContFG = new System.Windows.Forms.Button();
            this.CBCameraSelect = new System.Windows.Forms.ComboBox();
            this.LCamera = new System.Windows.Forms.Label();
            this.GBCameraSelect = new System.Windows.Forms.GroupBox();
            this.TBSerialNo = new System.Windows.Forms.TextBox();
            this.TBModuleNo = new System.Windows.Forms.TextBox();
            this.LSerialNo = new System.Windows.Forms.Label();
            this.LModuleNo = new System.Windows.Forms.Label();
            this.CallBackMessageLabel1 = new System.Windows.Forms.Label();
            this.CallBackMessageLabel2 = new System.Windows.Forms.Label();
            this.CallBackMessageLabel3 = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDownExposureTime)).BeginInit();
            this.GBFrameGrab.SuspendLayout();
            this.GBCameraSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BOK
            // 
            this.BOK.Location = new System.Drawing.Point(576, 166);
            this.BOK.Name = "BOK";
            this.BOK.Size = new System.Drawing.Size(90, 23);
            this.BOK.TabIndex = 0;
            this.BOK.Text = "OK";
            this.BOK.UseVisualStyleBackColor = true;
            this.BOK.Click += new System.EventHandler(this.BOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NUpDownExposureTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 104);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lighting and Exposure";
            // 
            // NUpDownExposureTime
            // 
            this.NUpDownExposureTime.Location = new System.Drawing.Point(89, 19);
            this.NUpDownExposureTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUpDownExposureTime.Name = "NUpDownExposureTime";
            this.NUpDownExposureTime.Size = new System.Drawing.Size(87, 20);
            this.NUpDownExposureTime.TabIndex = 1;
            this.NUpDownExposureTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUpDownExposureTime.ValueChanged += new System.EventHandler(this.NUpDownExposureTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cam Exp (ms)";
            // 
            // GBFrameGrab
            // 
            this.GBFrameGrab.Controls.Add(this.BContFG);
            this.GBFrameGrab.Location = new System.Drawing.Point(362, 12);
            this.GBFrameGrab.Name = "GBFrameGrab";
            this.GBFrameGrab.Size = new System.Drawing.Size(297, 72);
            this.GBFrameGrab.TabIndex = 5;
            this.GBFrameGrab.TabStop = false;
            this.GBFrameGrab.Text = "Frame Grab";
            // 
            // BContFG
            // 
            this.BContFG.Location = new System.Drawing.Point(15, 25);
            this.BContFG.Name = "BContFG";
            this.BContFG.Size = new System.Drawing.Size(90, 23);
            this.BContFG.TabIndex = 0;
            this.BContFG.Text = "Start Cont FG";
            this.BContFG.UseVisualStyleBackColor = true;
            this.BContFG.Click += new System.EventHandler(this.BContFG_Click);
            // 
            // CBCameraSelect
            // 
            this.CBCameraSelect.FormattingEnabled = true;
            this.CBCameraSelect.Location = new System.Drawing.Point(106, 21);
            this.CBCameraSelect.Name = "CBCameraSelect";
            this.CBCameraSelect.Size = new System.Drawing.Size(85, 21);
            this.CBCameraSelect.TabIndex = 6;
            this.CBCameraSelect.SelectedIndexChanged += new System.EventHandler(this.CBCameraSelect_SelectedIndexChanged);
            // 
            // LCamera
            // 
            this.LCamera.AutoSize = true;
            this.LCamera.Location = new System.Drawing.Point(15, 25);
            this.LCamera.Name = "LCamera";
            this.LCamera.Size = new System.Drawing.Size(71, 13);
            this.LCamera.TabIndex = 7;
            this.LCamera.Text = "USB Camera:";
            // 
            // GBCameraSelect
            // 
            this.GBCameraSelect.Controls.Add(this.TBSerialNo);
            this.GBCameraSelect.Controls.Add(this.TBModuleNo);
            this.GBCameraSelect.Controls.Add(this.LSerialNo);
            this.GBCameraSelect.Controls.Add(this.LModuleNo);
            this.GBCameraSelect.Controls.Add(this.CBCameraSelect);
            this.GBCameraSelect.Controls.Add(this.LCamera);
            this.GBCameraSelect.Location = new System.Drawing.Point(30, 12);
            this.GBCameraSelect.Name = "GBCameraSelect";
            this.GBCameraSelect.Size = new System.Drawing.Size(304, 80);
            this.GBCameraSelect.TabIndex = 8;
            this.GBCameraSelect.TabStop = false;
            this.GBCameraSelect.Text = "Select Camera && Start Engine";
            // 
            // TBSerialNo
            // 
            this.TBSerialNo.Location = new System.Drawing.Point(212, 49);
            this.TBSerialNo.Name = "TBSerialNo";
            this.TBSerialNo.ReadOnly = true;
            this.TBSerialNo.Size = new System.Drawing.Size(85, 20);
            this.TBSerialNo.TabIndex = 11;
            this.TBSerialNo.Text = "N/A";
            // 
            // TBModuleNo
            // 
            this.TBModuleNo.Location = new System.Drawing.Point(76, 49);
            this.TBModuleNo.Name = "TBModuleNo";
            this.TBModuleNo.ReadOnly = true;
            this.TBModuleNo.Size = new System.Drawing.Size(85, 20);
            this.TBModuleNo.TabIndex = 10;
            this.TBModuleNo.Text = "N/A";
            // 
            // LSerialNo
            // 
            this.LSerialNo.AutoSize = true;
            this.LSerialNo.Location = new System.Drawing.Point(160, 54);
            this.LSerialNo.Name = "LSerialNo";
            this.LSerialNo.Size = new System.Drawing.Size(53, 13);
            this.LSerialNo.TabIndex = 9;
            this.LSerialNo.Text = "Serial No.";
            // 
            // LModuleNo
            // 
            this.LModuleNo.AutoSize = true;
            this.LModuleNo.Location = new System.Drawing.Point(15, 54);
            this.LModuleNo.Name = "LModuleNo";
            this.LModuleNo.Size = new System.Drawing.Size(62, 13);
            this.LModuleNo.TabIndex = 8;
            this.LModuleNo.Text = "Module No.";
            // 
            // CallBackMessageLabel1
            // 
            this.CallBackMessageLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CallBackMessageLabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CallBackMessageLabel1.Location = new System.Drawing.Point(359, 106);
            this.CallBackMessageLabel1.MaximumSize = new System.Drawing.Size(500, 20);
            this.CallBackMessageLabel1.Name = "CallBackMessageLabel1";
            this.CallBackMessageLabel1.Size = new System.Drawing.Size(307, 19);
            this.CallBackMessageLabel1.TabIndex = 14;
            this.CallBackMessageLabel1.Text = "Call Back Message";
            // 
            // CallBackMessageLabel2
            // 
            this.CallBackMessageLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CallBackMessageLabel2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CallBackMessageLabel2.Location = new System.Drawing.Point(359, 125);
            this.CallBackMessageLabel2.MaximumSize = new System.Drawing.Size(500, 20);
            this.CallBackMessageLabel2.Name = "CallBackMessageLabel2";
            this.CallBackMessageLabel2.Size = new System.Drawing.Size(307, 19);
            this.CallBackMessageLabel2.TabIndex = 15;
            this.CallBackMessageLabel2.Text = "Call Back Message";
            // 
            // CallBackMessageLabel3
            // 
            this.CallBackMessageLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CallBackMessageLabel3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CallBackMessageLabel3.Location = new System.Drawing.Point(359, 144);
            this.CallBackMessageLabel3.MaximumSize = new System.Drawing.Size(500, 20);
            this.CallBackMessageLabel3.Name = "CallBackMessageLabel3";
            this.CallBackMessageLabel3.Size = new System.Drawing.Size(307, 19);
            this.CallBackMessageLabel3.TabIndex = 16;
            this.CallBackMessageLabel3.Text = "Call Back Message";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(30, 242);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(500, 205);
            this.picBox.TabIndex = 17;
            this.picBox.TabStop = false;
            // 
            // FUSBCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 591);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.CallBackMessageLabel3);
            this.Controls.Add(this.CallBackMessageLabel2);
            this.Controls.Add(this.CallBackMessageLabel1);
            this.Controls.Add(this.GBCameraSelect);
            this.Controls.Add(this.GBFrameGrab);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUSBCam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB Camera Configuration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FUSBCam_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDownExposureTime)).EndInit();
            this.GBFrameGrab.ResumeLayout(false);
            this.GBCameraSelect.ResumeLayout(false);
            this.GBCameraSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown NUpDownExposureTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GBFrameGrab;
        private System.Windows.Forms.Button BContFG;
        private System.Windows.Forms.ComboBox CBCameraSelect;
        private System.Windows.Forms.Label LCamera;
        private System.Windows.Forms.GroupBox GBCameraSelect;
        private System.Windows.Forms.Label LSerialNo;
        private System.Windows.Forms.Label LModuleNo;
        private System.Windows.Forms.TextBox TBSerialNo;
        private System.Windows.Forms.TextBox TBModuleNo;
        private System.Windows.Forms.Label CallBackMessageLabel1;
        private System.Windows.Forms.Label CallBackMessageLabel2;
        private System.Windows.Forms.Label CallBackMessageLabel3;
        private System.Windows.Forms.PictureBox picBox;
    }
}

