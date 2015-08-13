using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace USBCam
{
    public partial class FUSBCam : Form
    {
        //private ArrayList _myLights;
        //private string _camConfError = "Camera Configuration Error";
        private CCameraUSB myUSBCam; // = new CCameraUSB( this );
        private int _numCams;
        private bool _camEngineStarted = false;
        private bool _startedContFG = false;
        private int _callbackCount;

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
                myUSBCam.SetExposureTime(newExpTime);
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

        }

        private void btnDestination_Click(object sender, EventArgs e)
        {

        }

        private void numBufferWidth_ValueChanged(object sender, EventArgs e)
        {

        }

     }
}