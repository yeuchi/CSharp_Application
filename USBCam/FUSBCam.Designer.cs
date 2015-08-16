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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NUpDownExposureTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.GBFrameGrab = new System.Windows.Forms.GroupBox();
            this.rdoRun = new System.Windows.Forms.RadioButton();
            this.rdoBuffer = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numWhite = new System.Windows.Forms.NumericUpDown();
            this.numBlack = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPNG = new System.Windows.Forms.CheckBox();
            this.chkGIF = new System.Windows.Forms.CheckBox();
            this.chkTIF = new System.Windows.Forms.CheckBox();
            this.chkJPG = new System.Windows.Forms.CheckBox();
            this.numBufferWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBMP = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesFile = new System.Windows.Forms.TextBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.numFiles = new System.Windows.Forms.TextBox();
            this.listFiles = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDirSelect = new System.Windows.Forms.TextBox();
            this.btnDirSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDownExposureTime)).BeginInit();
            this.GBFrameGrab.SuspendLayout();
            this.GBCameraSelect.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBufferWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NUpDownExposureTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lighting and Exposure";
            // 
            // NUpDownExposureTime
            // 
            this.NUpDownExposureTime.Location = new System.Drawing.Point(89, 19);
            this.NUpDownExposureTime.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUpDownExposureTime.Name = "NUpDownExposureTime";
            this.NUpDownExposureTime.Size = new System.Drawing.Size(87, 20);
            this.NUpDownExposureTime.TabIndex = 1;
            this.NUpDownExposureTime.Value = new decimal(new int[] {
            2,
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
            this.GBFrameGrab.Controls.Add(this.rdoRun);
            this.GBFrameGrab.Controls.Add(this.rdoBuffer);
            this.GBFrameGrab.Controls.Add(this.btnSave);
            this.GBFrameGrab.Controls.Add(this.BContFG);
            this.GBFrameGrab.Location = new System.Drawing.Point(331, 18);
            this.GBFrameGrab.Name = "GBFrameGrab";
            this.GBFrameGrab.Size = new System.Drawing.Size(308, 80);
            this.GBFrameGrab.TabIndex = 5;
            this.GBFrameGrab.TabStop = false;
            this.GBFrameGrab.Text = "Frame Grab";
            // 
            // rdoRun
            // 
            this.rdoRun.AutoSize = true;
            this.rdoRun.Location = new System.Drawing.Point(221, 51);
            this.rdoRun.Name = "rdoRun";
            this.rdoRun.Size = new System.Drawing.Size(60, 17);
            this.rdoRun.TabIndex = 3;
            this.rdoRun.Text = "Run-on";
            this.rdoRun.UseVisualStyleBackColor = true;
            this.rdoRun.CheckedChanged += new System.EventHandler(this.rdoRun_CheckedChanged);
            // 
            // rdoBuffer
            // 
            this.rdoBuffer.AutoSize = true;
            this.rdoBuffer.Checked = true;
            this.rdoBuffer.Location = new System.Drawing.Point(221, 23);
            this.rdoBuffer.Name = "rdoBuffer";
            this.rdoBuffer.Size = new System.Drawing.Size(65, 17);
            this.rdoBuffer.TabIndex = 2;
            this.rdoBuffer.TabStop = true;
            this.rdoBuffer.Text = "Buffered";
            this.rdoBuffer.UseVisualStyleBackColor = true;
            this.rdoBuffer.CheckedChanged += new System.EventHandler(this.rdoBuffer_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(118, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BContFG
            // 
            this.BContFG.Enabled = false;
            this.BContFG.Location = new System.Drawing.Point(9, 19);
            this.BContFG.Name = "BContFG";
            this.BContFG.Size = new System.Drawing.Size(90, 23);
            this.BContFG.TabIndex = 0;
            this.BContFG.Text = "Start Preview";
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
            this.GBCameraSelect.Location = new System.Drawing.Point(21, 18);
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
            this.CallBackMessageLabel1.Location = new System.Drawing.Point(339, 101);
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
            this.CallBackMessageLabel2.Location = new System.Drawing.Point(339, 121);
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
            this.CallBackMessageLabel3.Location = new System.Drawing.Point(339, 142);
            this.CallBackMessageLabel3.MaximumSize = new System.Drawing.Size(500, 20);
            this.CallBackMessageLabel3.Name = "CallBackMessageLabel3";
            this.CallBackMessageLabel3.Size = new System.Drawing.Size(307, 19);
            this.CallBackMessageLabel3.TabIndex = 16;
            this.CallBackMessageLabel3.Text = "Call Back Message";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Location = new System.Drawing.Point(21, 177);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(629, 260);
            this.tab.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(10, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(600, 205);
            this.picBox.TabIndex = 18;
            this.picBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.chkPNG);
            this.tabPage2.Controls.Add(this.chkGIF);
            this.tabPage2.Controls.Add(this.chkTIF);
            this.tabPage2.Controls.Add(this.chkJPG);
            this.tabPage2.Controls.Add(this.numBufferWidth);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.chkBMP);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(621, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buffered";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.numWhite);
            this.groupBox4.Controls.Add(this.numBlack);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(242, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(319, 100);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Histogram Equalization";
            this.groupBox4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "White point:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(259, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "manual";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numWhite
            // 
            this.numWhite.Enabled = false;
            this.numWhite.Location = new System.Drawing.Point(104, 23);
            this.numWhite.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numWhite.Name = "numWhite";
            this.numWhite.Size = new System.Drawing.Size(120, 20);
            this.numWhite.TabIndex = 10;
            this.numWhite.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // numBlack
            // 
            this.numBlack.Enabled = false;
            this.numBlack.Location = new System.Drawing.Point(104, 65);
            this.numBlack.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numBlack.Name = "numBlack";
            this.numBlack.Size = new System.Drawing.Size(120, 20);
            this.numBlack.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Black point:";
            // 
            // chkPNG
            // 
            this.chkPNG.AutoSize = true;
            this.chkPNG.Location = new System.Drawing.Point(517, 191);
            this.chkPNG.Name = "chkPNG";
            this.chkPNG.Size = new System.Drawing.Size(44, 17);
            this.chkPNG.TabIndex = 8;
            this.chkPNG.Text = "png";
            this.chkPNG.UseVisualStyleBackColor = true;
            // 
            // chkGIF
            // 
            this.chkGIF.AutoSize = true;
            this.chkGIF.Location = new System.Drawing.Point(411, 191);
            this.chkGIF.Name = "chkGIF";
            this.chkGIF.Size = new System.Drawing.Size(37, 17);
            this.chkGIF.TabIndex = 7;
            this.chkGIF.Text = "gif";
            this.chkGIF.UseVisualStyleBackColor = true;
            // 
            // chkTIF
            // 
            this.chkTIF.AutoSize = true;
            this.chkTIF.Location = new System.Drawing.Point(317, 191);
            this.chkTIF.Name = "chkTIF";
            this.chkTIF.Size = new System.Drawing.Size(34, 17);
            this.chkTIF.TabIndex = 5;
            this.chkTIF.Text = "tif";
            this.chkTIF.UseVisualStyleBackColor = true;
            // 
            // chkJPG
            // 
            this.chkJPG.AutoSize = true;
            this.chkJPG.Location = new System.Drawing.Point(208, 191);
            this.chkJPG.Name = "chkJPG";
            this.chkJPG.Size = new System.Drawing.Size(40, 17);
            this.chkJPG.TabIndex = 4;
            this.chkJPG.Text = "jpg";
            this.chkJPG.UseVisualStyleBackColor = true;
            // 
            // numBufferWidth
            // 
            this.numBufferWidth.Location = new System.Drawing.Point(98, 93);
            this.numBufferWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBufferWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBufferWidth.Name = "numBufferWidth";
            this.numBufferWidth.Size = new System.Drawing.Size(120, 20);
            this.numBufferWidth.TabIndex = 3;
            this.numBufferWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBufferWidth.ValueChanged += new System.EventHandler(this.numBufferWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image Width:";
            // 
            // chkBMP
            // 
            this.chkBMP.AutoSize = true;
            this.chkBMP.Location = new System.Drawing.Point(98, 191);
            this.chkBMP.Name = "chkBMP";
            this.chkBMP.Size = new System.Drawing.Size(46, 17);
            this.chkBMP.TabIndex = 1;
            this.chkBMP.Text = "bmp";
            this.chkBMP.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDesFile);
            this.groupBox2.Controls.Add(this.btnDestination);
            this.groupBox2.Location = new System.Drawing.Point(9, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 59);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination File Name (no extension)";
            // 
            // txtDesFile
            // 
            this.txtDesFile.Location = new System.Drawing.Point(89, 22);
            this.txtDesFile.Name = "txtDesFile";
            this.txtDesFile.Size = new System.Drawing.Size(449, 20);
            this.txtDesFile.TabIndex = 1;
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(7, 20);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(75, 23);
            this.btnDestination.TabIndex = 0;
            this.btnDestination.Text = "Select";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.numFiles);
            this.tabPage3.Controls.Add(this.listFiles);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(621, 234);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Run-on";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Files count:";
            // 
            // numFiles
            // 
            this.numFiles.Enabled = false;
            this.numFiles.Location = new System.Drawing.Point(445, 80);
            this.numFiles.Name = "numFiles";
            this.numFiles.Size = new System.Drawing.Size(100, 20);
            this.numFiles.TabIndex = 2;
            // 
            // listFiles
            // 
            this.listFiles.Location = new System.Drawing.Point(11, 80);
            this.listFiles.Multiline = true;
            this.listFiles.Name = "listFiles";
            this.listFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listFiles.Size = new System.Drawing.Size(275, 139);
            this.listFiles.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDirSelect);
            this.groupBox3.Controls.Add(this.btnDirSelect);
            this.groupBox3.Location = new System.Drawing.Point(11, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 60);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Destination Directory";
            // 
            // txtDirSelect
            // 
            this.txtDirSelect.Location = new System.Drawing.Point(91, 22);
            this.txtDirSelect.Name = "txtDirSelect";
            this.txtDirSelect.Size = new System.Drawing.Size(443, 20);
            this.txtDirSelect.TabIndex = 1;
            // 
            // btnDirSelect
            // 
            this.btnDirSelect.Location = new System.Drawing.Point(7, 20);
            this.btnDirSelect.Name = "btnDirSelect";
            this.btnDirSelect.Size = new System.Drawing.Size(75, 23);
            this.btnDirSelect.TabIndex = 0;
            this.btnDirSelect.Text = "Select";
            this.btnDirSelect.UseVisualStyleBackColor = true;
            this.btnDirSelect.Click += new System.EventHandler(this.btnDirSelect_Click);
            // 
            // FUSBCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 458);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.CallBackMessageLabel3);
            this.Controls.Add(this.CallBackMessageLabel2);
            this.Controls.Add(this.CallBackMessageLabel1);
            this.Controls.Add(this.GBCameraSelect);
            this.Controls.Add(this.GBFrameGrab);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUSBCam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mightex TCE1209-U";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FUSBCam_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDownExposureTime)).EndInit();
            this.GBFrameGrab.ResumeLayout(false);
            this.GBFrameGrab.PerformLayout();
            this.GBCameraSelect.ResumeLayout(false);
            this.GBCameraSelect.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBufferWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDesFile;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.NumericUpDown numBufferWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBMP;
        private System.Windows.Forms.CheckBox chkTIF;
        private System.Windows.Forms.CheckBox chkJPG;
        private System.Windows.Forms.CheckBox chkPNG;
        private System.Windows.Forms.CheckBox chkGIF;
        private System.Windows.Forms.NumericUpDown numBlack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numWhite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoRun;
        private System.Windows.Forms.RadioButton rdoBuffer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox listFiles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDirSelect;
        private System.Windows.Forms.Button btnDirSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numFiles;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

