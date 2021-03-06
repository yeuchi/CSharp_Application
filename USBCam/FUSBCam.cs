using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace USBCam
{
    public partial class FUSBCam : Form
    {
        protected const string LABEL_STOP = "Stop";
        protected const string LABEL_SAVE = "Save";

        //private ArrayList _myLights;
        //private string _camConfError = "Camera Configuration Error";
        private CCameraUSB myUSBCam; // = new CCameraUSB( this );
        private int _numCams;
        private bool _camEngineStarted = false;
        private bool _startedContFG = false;
        private int _callbackCount;
        protected int runOnIndex = 0;

        public ImageProperty CurrentImageProperty;
        public uint PixelAverage;


        public FUSBCam()
        {
            InitializeComponent();

            myUSBCam = new CCameraUSB(this, picBox);
            //myUSBCam = new CCameraUSB(this);
            _callbackCount = 0;
            
            _numCams = myUSBCam.InitDevice();
            //Populate camera combo box
            if (_numCams > 0)
            {
                string cam = "";
                for (int i = 0; i < _numCams; i++)
                {
                    cam = String.Format("Camera {0}", i + 1);
                    CBCameraSelect.Items.Add(cam);
                }
                //CBCameraSelect.SelectedIndex = 0;
                NUpDownExposureTime.Value = myUSBCam.GetExpTime()/1000;
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            //Cleanup Resources called by FUSBCam_FormClosed
            Close();
        }

        private void CleanUpResources()
        {
            if (this._camEngineStarted)
            {
                //Free IntPtr memory in myUSBCam object
                myUSBCam.StopCameraEngine();
            }

            //release camera resources
            this.myUSBCam.UnInitDevice();
        }

        private void CBCameraSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Open device and get module and serial numbers
            myUSBCam.AddCameraToWorkingSet( CBCameraSelect.SelectedIndex+1 );
            TBModuleNo.Text = myUSBCam.GetModuleNo();
            TBSerialNo.Text = myUSBCam.GetSerialNo();
            BContFG.Enabled = true;
            
            //Start the camera engine
            myUSBCam.StartCameraEngine(this.Handle);
            _camEngineStarted = true;
            System.Threading.Thread.Sleep(200);

            //Set default camera settings
            Trace.Flush();
            Trace.WriteLine("Calling SetFrameSetting() from FUSBCam Form....");
            Trace.Indent();

            myUSBCam.SetCameraWorkMode(CCameraUSB.CAM_WORKMODE.VIDEO);
            myUSBCam.SetExposureTime(5); // 5ms

            Trace.Unindent();
            Trace.WriteLine("Returned from SetFrameSetting(), end trace.");

       }

         private void BContFG_Click(object sender, EventArgs e)
        {
            if (!_startedContFG)
            {
                myUSBCam.StartFrameGrab(CCameraUSB.INFINITE_FRAMES);
                _startedContFG = true;
                BContFG.Text = "Stop Cont FG";
                //myUSBCam.SetResolution((CCameraUSB.RESOLUTION)CBResolution.SelectedIndex, 1, false);
                //timerContFG.Enabled = true;
                //System.Threading.Thread.Sleep(200);
            }
            else
            {
                myUSBCam.StopFrameGrab();
                _startedContFG = false;
                BContFG.Text = "Start Cont FG";
            }
        }
 
        private void NUpDownExposureTime_ValueChanged(object sender, EventArgs e)
        {
            int newExpTime = System.Convert.ToInt32(NUpDownExposureTime.Value);
            if (_camEngineStarted)
            {
                bool Success = myUSBCam.SetExposureTime(newExpTime);
                //DisplayError("Error trying to set camera exposure settings." + myUSBCam.error);
            }
        }
 
        private void FUSBCam_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanUpResources();
        }

        public void SetCallBackMessage( ref ImageProperty imageProp, uint pixelAvg )
        {
            CurrentImageProperty  = imageProp;
            PixelAverage = pixelAvg;
            _callbackCount++;
            CallBackMessageLabel1.Text = "Frame Count:" + _callbackCount + " Exposure Time: " + (CurrentImageProperty.ExposureTime/10) + "(ms)"; // ShowMessage
            CallBackMessageLabel2.Text = "TimeStamp: " + CurrentImageProperty.TimeStamp;
            CallBackMessageLabel3.Text = "Pixel Average:" + PixelAverage + " ShieldPixel: " + CurrentImageProperty.LightShieldAverageValue ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // need threading..
            bool success;
            try{
                if (false == BContFG.Enabled)
                {
                    DisplayError("Please turn on 'Preview'.");
                    return;
                }

                if (btnSave.Text == LABEL_STOP)
                {
                    myUSBCam.deallocBitmap();
                    btnSave.Text = LABEL_SAVE;
                    return;
                }

                if (rdoBuffer.Checked == true)   // buffered
                {
                     success = myUSBCam.allocBitmap((int)numBufferWidth.Value, true);
                    // signal object to start writing !

                    // save to file when done
                }
                else// run-on
                {
                    // create 1 line for run-on saving to file
                     runOnIndex = 0;
                     success = myUSBCam.allocBitmap(1, false);
                }

                if (false == success)
                    DisplayError(myUSBCam.error);
                else
                    btnSave.Text = LABEL_STOP;

            }
            catch(Exception ex)
            {
                DisplayError("Save failed: " + ex.Message);
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            // buffered destination file dialog
            try
            {
                // set destination file name prefix
                saveFileDialog1.InitialDirectory = "c:\\";
                saveFileDialog1.FileName = "Image";

                saveFileDialog1.Filter = "Multiple files (*)|*|JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png |TIFF files (*.tif)|*.tif|Bitmap files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif";
                saveFileDialog1.FilterIndex = 1;

                // get image and write to disk
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtDesFile.Text = saveFileDialog1.FileName;
                    int pos = txtDesFile.Text.IndexOf(".");
                    
                    if(true==rdoBuffer.Checked)
                        btnSave.Enabled = true;

                    if (pos > 0)
                    {
                        // file type selected
                        txtDesFile.Text = txtDesFile.Text.Substring(0, pos);
                        string filetype = txtDesFile.Text.Substring(pos + 1, 3);
                        chkBMP.Checked = chkJPG.Checked = chkPNG.Checked = chkTIF.Checked = chkGIF.Checked = false;
                        switch (filetype.ToLower())
                        {
                            case "jpg":
                                chkJPG.Checked = true;
                                break;
                            case "png":
                                chkPNG.Checked = true;
                                break;
                            case "tif":
                                chkTIF.Checked = true;
                                break;
                            case "gif":
                                chkGIF.Checked = true;
                                break;
                            case "bmp":
                                chkBMP.Checked = true;
                                break;
                        }
                    }
                    else
                    {
                        // at least 1 should be selected ?
                        if (false == chkBMP.Checked &&
                            false == chkPNG.Checked &&
                            false == chkJPG.Checked &&
                            false == chkGIF.Checked &&
                            false == chkTIF.Checked)
                            chkBMP.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayError("Set Destination failed: " + ex.Message);
            }
        }

        public bool saveBitmap(Bitmap bitmap)
        {
            btnSave.Text = LABEL_SAVE;
            // save bitmap to files

            switch (rdoBuffer.Checked)
            {
                case true:  // buffered mode
                  // bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    if (true == chkBMP.Checked)
                        bitmap.Save(txtDesFile.Text + ".bmp", ImageFormat.Bmp);

                    if (true == chkPNG.Checked)
                        bitmap.Save(txtDesFile.Text + ".png", ImageFormat.Png);

                    if (true == chkJPG.Checked)
                        bitmap.Save(txtDesFile.Text + ".jpg", ImageFormat.Jpeg);

                    if (true == chkTIF.Checked)
                        bitmap.Save(txtDesFile.Text + ".tif", ImageFormat.Tiff);

                    if (true == chkGIF.Checked)
                        bitmap.Save(txtDesFile.Text + ".gif", ImageFormat.Gif);

                    DisplayError("done !");
                    break;

                case false: // run-on mode
                    // save 1 frame to directory
                    string filename = txtDirSelect.Text +"\\frame" + runOnIndex.ToString() + ".png";
                    bitmap.Save(filename, ImageFormat.Png);
                    runOnIndex++;
                   // scanDirectory();
                    break;
            }
            return true;
        }

        private void numBufferWidth_ValueChanged(object sender, EventArgs e)
        {
            // do nothing
        }

        private void rdoBuffer_CheckedChanged(object sender, EventArgs e)
        {
            rdoRun.Checked = false;
            btnSave.Enabled = (txtDesFile.Text.Length > 0) ? true : false;

        }

        private void rdoRun_CheckedChanged(object sender, EventArgs e)
        {
            rdoBuffer.Checked = false;
            btnSave.Enabled = (txtDirSelect.Text.Length > 0) ? true : false;
        }

        // Description:	Display an error box
        void DisplayError(string sError)
        {
            this.Cursor = Cursors.Default;
            MessageBox.Show(sError,
                "Caption", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnDirSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirSelect.Text = folderBrowserDialog1.SelectedPath;
                bool success = scanDirectory();
                
                if (true == success && true == rdoRun.Checked)
                    btnSave.Enabled = true;
            }
        }

        protected bool scanDirectory()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool success = true;
                DirectoryInfo directoryInfo = new DirectoryInfo(txtDirSelect.Text);
                FileSystemInfo[] filesInfo = directoryInfo.GetFiles();

                listFiles.Text = "";
                numFiles.Text = "Files count: " + filesInfo.Length;
                listFiles.Text = "";

                for (int i = 0; i < filesInfo.Length; i++)
                {
                    listFiles.Text += i + ") " + filesInfo[i].Name + "\r\n";
                    if (filesInfo[i].Name.ToLower().Contains("frame"))
                        success = false;
                }
                this.Cursor = Cursors.Default;

                if (false == success)
                    DisplayError("Please use a directory without 'frame' files");

                return success;
            }
            catch (Exception ex)
            {
                DisplayError("scanDirectory() failed" + ex.Message);
                return false;
            }
        }
     }
}