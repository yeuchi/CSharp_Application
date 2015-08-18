using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Drawing;

namespace USBCam
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ImageProperty
    {
        [FieldOffset(0)] public int CameraID;
        [FieldOffset(4)] public int ExposureTime;
        [FieldOffset(8)] public int TimeStamp;
        [FieldOffset(12)] public int TriggerOccurred;
        [FieldOffset(16)] public int TriggerEventCount;
        [FieldOffset(20)] public int OverSaturated;
        [FieldOffset(24)] public int LightShieldAverageValue;
    }

    public delegate void FrameCallbackDelegate( int FrameType, int Row, int Col,  ref ImageProperty frameProperty, IntPtr BufferPtr );

    public class CCameraUSB
    {
        //Members...
        public enum CAM_WORKMODE {VIDEO, EXT_TRIG};
        public enum FRAME_TYPE { RAW, DIB };
        public const int INFINITE_FRAMES = 0x8888;
        public FrameCallbackDelegate frameDelegate;
        private FUSBCam MightexCam; // The GUI class
        private int _deviceID = 1;
        private string _camError = "USB Camera Error";

        public string error = "";

        // buffer - save to file elements
        protected Bitmap buffer;            // destination buffered image
        protected bool mode;                // buffered or run-on
        protected bool hasBuffer = false;   // to write or not to write into the buffer
        protected int index=0;              // line index in buffer
        protected BitmapData Bufferdata;    // Bitmap data - pinned
        protected int lastIndex = 0;        // number of lines to scan

        // preview elements
        protected PictureBox picBox;
        protected Bitmap[] bmps;
        protected int current = 0;
        protected Graphics g;
        protected Rectangle rect;
        protected BitmapData Bmpdata;
        protected int pos;

        public const int FRAME_WIDTH = 2048;

        public struct ImageControl
        {
            [XmlElement("Revision")]
            public int _exposureTime;  //current exposure time in microseconds
        }

        public void deallocBitmap()
        {
            if (null != buffer)
            {
                this.hasBuffer = false;
                buffer.Dispose();
                buffer = null;
            }
        }

        public bool allocBitmap(int width,
                                bool mode)
        {
            try
            {
                switch (mode)
                {
                    case true:      // buffer mode
                        if(width<1)
                            width = 1;    // at least 1 line
                        break;

                    case false:     // run-on mode
                        width = 1;                          // can ONLY be 1
                        break;
                }
                buffer = new Bitmap(FRAME_WIDTH, width, PixelFormat.Format8bppIndexed);
                // set gray scale palette
                ColorPalette pal = buffer.Palette; 
                for (int i = 0; i < 256; i++)
                    pal.Entries[i] = Color.FromArgb(255,i,i,i);
                buffer.Palette = pal;
                
                // 90 degree rotated for faster write
                Bufferdata = buffer.LockBits(new Rectangle(0, 0, FRAME_WIDTH, width),
                                            ImageLockMode.ReadWrite,
                                            PixelFormat.Format8bppIndexed);
                index = 0;
                lastIndex = width - 1;
                this.mode = mode;
                return this.hasBuffer = true;
            }
            catch (Exception ex)
            {
                error = "CCameraUSB.allocBitmap() failed:" + ex.Message;
                return false;
            }
        }

        private ImageControl _imgControl = new ImageControl();

        //default constructor for testing
        public CCameraUSB( FUSBCam mightexCamera, PictureBox picBox )
        //public CCameraUSB( FUSBCam mightexCamera  )
        {
            this.picBox = picBox;
            pos = (picBox.Width-1) * 3;
            bmps = new Bitmap[2];
            bmps[0] = new Bitmap(picBox.Width, picBox.Height, PixelFormat.Format24bppRgb);
            bmps[1] = new Bitmap(picBox.Width, picBox.Height, PixelFormat.Format24bppRgb);
            rect = new Rectangle(1, 0, picBox.Width - 1, picBox.Height);

             _imgControl._exposureTime = 5000; // 5ms.

            MightexCam = mightexCamera;
            frameDelegate = new FrameCallbackDelegate(GrabbingFrameCallback);
        }

        // JTZ: The frame callback.
        public void GrabbingFrameCallback(int FrameType, int Row, int Col, ref ImageProperty frameProperty, IntPtr BufferPtr)
        {
            uint i, pixelAvg=0;
            uint frameSize;
            int notCurrent = (current==0)?1:0;
            g = Graphics.FromImage(bmps[notCurrent]);
            g.DrawImage(bmps[current], 0, 0, rect, GraphicsUnit.Pixel);

            Bmpdata = bmps[current].LockBits(new Rectangle(0, 0, picBox.Width, picBox.Height),
                                                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                ushort* frameptr;
                byte* Bmpptr = (byte*)(Bmpdata.Scan0) + pos;
                byte* bufPtr = null;

                if(true == hasBuffer)
                    bufPtr = (byte*)(Bufferdata.Scan0) + Bufferdata.Stride*index;
                
                /*
                 * JTZ: In tihs example, we get "Raw" data.
                 */
                pixelAvg = 0;
                frameSize = (uint)(Row * Col); // We take 1304 as example, it's 3648
                frameptr = (ushort*)BufferPtr;

                // faster to request memory block copy ?
                for (i = 0; i < frameSize; i++)
                {
                    pixelAvg += (uint)*frameptr;
                    byte p = (byte)((uint)*frameptr >> 4);

                    // preview
                    if (i % 10 == 0)
                    {
                        *Bmpptr = p; Bmpptr++;
                        *Bmpptr = p; Bmpptr++;
                        *Bmpptr = p; Bmpptr += (Bmpdata.Stride-2);
                    }

                    // write to buffer
                    if (true == hasBuffer)
                        *bufPtr = p; bufPtr++;

                    // increment source
                    frameptr++;
                }
                if (true == mode)   // buffer mode
                    index++;

                pixelAvg = pixelAvg / frameSize;
            }
                
            // stick it in the picture box !!!

            bmps[current].UnlockBits(Bmpdata);
            picBox.Image = (Image)bmps[current];
            current = notCurrent;
            /*
             * JTZ: For Buffer camera, the callback in invoked in the main thread of the application, so it's 
             * allowed to do any GUI operations here...however, don't block here.
             */
            MightexCam.SetCallBackMessage(ref frameProperty, pixelAvg);

            if (true == hasBuffer &&
                index >= lastIndex)
            {
                hasBuffer = false;
                if (true == mode)
                    buffer.UnlockBits(Bufferdata);
                
                bool success = MightexCam.saveBitmap(buffer);

                // stop if buffered mode or failed to save
                if (true == mode || false==success)
                {
                    deallocBitmap();    
                }
                else // saved ok and run-on mode
                {
                    index = 0;
                    hasBuffer = true;   // keep going for run-on mode
                }
            }
        }

        public int GetExpTime()
        {
            return _imgControl._exposureTime;
        }

        //Thin wrapper for calling into BUF_USBCamera_SDK_Stdcall.dll
        //Interops are in the USBCam.Designer.cs (partial class) file

        /// <summary>
        /// Call this function first, this function communicates with device driver to reserve resources
        /// </summary>
        /// <returns>number of cameras on USB 2.0 chan</returns>
        public int InitDevice()
        {
            int numCam = CCDInitDevice();

            if ( numCam < 0 )
            {
                MessageBox.Show("Error trying to initialize camera resources. No cameras found on USB 2.0 bus.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return numCam;
        }
        
        //Call this function before the app terminates, it releases all resources
        public void UnInitDevice()
        {
            if (CCDUnInitDevice() < 0)
            {
                MessageBox.Show("Error trying to uninitialize camera.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Function used to get the module number on a particular USB channel
        /// </summary>
        /// <returns></returns>
        public string GetModuleNo()
        {
            string moduleNumber = "Unknown";
            //char moduleNo = 'X';
            StringBuilder rtnModuleNo = new StringBuilder();
            StringBuilder rtnSerialNo = new StringBuilder();

            if (CCDGetModuleNoSerialNo( _deviceID, rtnModuleNo, rtnSerialNo) < 0)
            {
                MessageBox.Show("Error trying to retrieve camera module number.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                moduleNumber = rtnModuleNo.ToString();
            }
            return moduleNumber;
        }

        /// <summary>
        /// Function used to get the serial number on a particular USB channel
        /// </summary>
        /// <returns></returns>
        public string GetSerialNo()
        {
            string serialNumber = "Unknown2";
            StringBuilder rtnModuleNo = new StringBuilder();
            StringBuilder rtnSerialNo = new StringBuilder();

            if (CCDGetModuleNoSerialNo(_deviceID, rtnModuleNo, rtnSerialNo) < 0)
            {
                MessageBox.Show("Error trying to retrieve camera serial number.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                serialNumber = rtnSerialNo.ToString();
            }
            return serialNumber;
        }

        public void AddCameraToWorkingSet(int cameraID)
        {
            _deviceID = cameraID;
            if (CCDAddDeviceToWorkingSet( cameraID ) < 0)
            {
                MessageBox.Show("Error adding camera to working set", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void RemoveCameraFromWorkingSet(int cameraID)
        {
            if (CCDRemoveDeviceFromWorkingSet(cameraID) < 0)
            {
                MessageBox.Show("Error removing camera from working set", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //Camera has multithread engine internally, which is responsible for all the frame grabbing, raw data to RGB data conversion…etc. functions. 
        //User MUST start this engine for all the following camera related operations
        //ParentHandle ?The window handle of the main form of user’s application, as the engine relies on
        //Windows Message Queue, it needs a parent window handle
        public void StartCameraEngine(IntPtr parentHandle)
        {
            if (CCDStartCameraEngine(parentHandle) < 0)
            {
                MessageBox.Show("Error trying to start camera engine.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Stops the started camera engine.
        /// </summary>
        public void StopCameraEngine()
        {
            if ( CCDStopCameraEngine() < 0 )
            {
                MessageBox.Show("Error trying to stop camera engine.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets camera to either "video" mode - continuously deliver frames to PC or
        /// "external trigger" mode - camera waits for external trigger to capture 1 frame
        /// </summary>
        /// <param name="mode"></param>
        public void SetCameraWorkMode(CAM_WORKMODE mode)
        {
            int WorkMode = (int)mode;
            if (CCDSetCameraWorkMode(_deviceID, WorkMode) < 0) // We take the first camera as example here.
            {
                MessageBox.Show("Error trying to set camera work mode.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hides (makes invisible) the control panel which will be displayed once the camera engine starts
        /// </summary>
        ///
        /* JTZ: I add this method for user's debug purpose...use might show the control panel...so all the
         * settings (e.g. exposure time...etc.) are visible on this panel...user might hide it in his  formal
         * application.
         */
        public void ShowFactoryControlPanel( uint Left, uint Top)
        {
            String passWord = "123456";

            if (CCDShowFactoryControlPanel(_deviceID, passWord) < 0)
            {
                MessageBox.Show("Error trying to show camera control panel.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hides (makes invisible) the control panel which will be displayed once the camera engine starts
        /// </summary>
        public void HideFactoryControlPanel()
        {
            if ( CCDHideFrameControlPanel() < 0)
            {
                MessageBox.Show("Error trying to hide camera control panel.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Starts frame grabbing after camera resources prepared. After call, user should see images in video window
        /// </summary>
        /// <param name="totalFrames"></param>
        public void StartFrameGrab(int totalFrames)
        {
            // Install frame call back.
            CCDInstallFrameHooker( 0, frameDelegate); // I get raw data in this example.
            if ( CCDStartFrameGrab( totalFrames) < 0)
            {
                MessageBox.Show("Error trying to start frame grabbing images.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Stops frame grabbing, call if totalFrames set to INFINITE_FRAMES
        /// </summary>
        public void StopFrameGrab()
        {
            // Install frame call back.
            CCDInstallFrameHooker( 0, null ); // Unhooker the callback.
            if (CCDStopFrameGrab() < 0)
            {
                MessageBox.Show("Error trying to stop frame grabbing images.", _camError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

          //Note: only two elements _maxExposureTimeIndex and _exposureTime are used by this function, all others are ignored.
        /// <summary>
        /// Set camera exposure parameters
        /// </summary>
        /// <param name="expTime"></param>
        public bool SetExposureTime( int expTime)
        {
            _imgControl._exposureTime = expTime*1000; //convert milli to microseconds

            if (CCDSetExposureTime(_deviceID, (_imgControl._exposureTime), false) < 0)
            {
                this.error = _camError;
                return false;
            }
            return true;
        }

        
        #region Mightex interop functions for accessing CCD_USBCamera_SDK_Stdcall.dll and LinearCameraUsblib.dll files
  
        //Call this function first, this function communicates with device driver to reserve resources
        //When the system uses NTFS use WINNT, for FAT32 use WINDOWS
        /*
         * JTZ: Note that I assume we put CCD_USBCamera_SDK_Stdcall.dll and LinearCameraUsbLib.dll in windows\system32.
         */

        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_InitDevice", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDInitDevice();


        //Call this function before the app terminates, it releases all resources
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_UnInitDevice", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDUnInitDevice();

        //The module number and serial number are what appear if one calls the
        //SDK_HANDLE_API BUFUSB_ShowOpenDeviceDialog() method.
        //returns:  -1 If the function fails (e.g. invalid device handle), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_GetModuleNoSerialNo", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDGetModuleNoSerialNo(int deviceID, StringBuilder moduleNo, StringBuilder serialNo);

        //Add device to working set, deviceID is a one base index, so if InitDevice returns 2 for example, there devices at 1 and 2.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_AddDeviceToWorkingSet", CallingConvention = CallingConvention.StdCall)]
        private static extern uint CCDAddDeviceToWorkingSet(int deviceID);

        //Remove device from working set. 
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_RemoveDeviceFromWorkingSet", CallingConvention = CallingConvention.StdCall)]
        private static extern uint CCDRemoveDeviceFromWorkingSet(int deviceID);

        //Camera has multithread engine internally, which is responsible for all the frame grabbing, raw data to RGB data conversion etc. functions. 
        //User MUST start this engine for all the following camera related operations
        //ParentHandle ?The window handle of the main form of user’s application, as the engine relies on
        //Windows Message Queue, it needs a parent window handle
        //returns:  -1 If the function fails (e.g. invalid device handle), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_StartCameraEngine", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDStartCameraEngine(IntPtr parentHandle );

        //Stops the started camera engine.
        //returns:  -1 If the function fails (e.g. invalid device handle or if the engine is NOT started), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_StopCameraEngine", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDStopCameraEngine();

        //Sets camera to either "video" mode - continuously deliver frames to PC or
        //"external trigger" mode - camera waits for external trigger to capture 1 frame
        //returns:  -1 If the function fails (e.g. invalid device handle), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_SetCameraWorkMode", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDSetCameraWorkMode( int deviceID, int WorkMode);

        //Showes (makes visible) the factory control panel which will be displayed once the camera engine starts
        //returns:  -1 If the function fails (e.g. invalid device handle or if the engine is NOT started yet), 1 if the call succeeds.
        /*
         * JTZ: I add this API for user debug purpose. 
         */
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_ShowFactoryControlPanel", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDShowFactoryControlPanel( int deviceID, String password );

        //Hides (makes invisible) the control panel which will be displayed once the camera engine starts
        //returns:  -1 If the function fails (e.g. invalid device handle or if the engine is NOT started yet), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_HideFactoryControlPanel", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDHideFrameControlPanel();

            //Starts frame grabbing after camera resources prepared.
        //After call, user should see images in video window
        //returns:  -1 If the function fails (e.g. invalid device handle or if the engine is NOT started yet), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_StartFrameGrab", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDStartFrameGrab(int totalFrames);

        //Stops frame grabbing, call if totalFrames set to INFINITE_FRAMES
        //returns:  -1 If the function fails (e.g. invalid device handle or if the engine is NOT started yet), 1 if the call succeeds.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_StopFrameGrab", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDStopFrameGrab();


        //Set exposure parameters
        //returns:  -1 If the function fails (e.g. invalid device handle), 1 if the call succeeds.
        //Note: only two elements _maxExposureTimeIndex and _exposureTime are used by this function, all others are ignored.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_SetExposureTime", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDSetExposureTime( int deviceID, int exposureTime, bool store);

        // JTZ: we allow user to install a callback for each grabbed frame.
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_InstallFrameHooker", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDInstallFrameHooker( int FrameType, Delegate FrameCallBack);

        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_InstallUSBDeviceHooker", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDInstallUSBDeviceHooker( Delegate USBDeviceCallBack);
        
        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_SetGPIOConfig", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDSetGPIOConfig( int deviceID, byte configByte);

        [DllImport("CCD_USBCamera_SDK_Stdcall.dll", EntryPoint = "CCDUSB_SetGPIOInOut", CallingConvention = CallingConvention.StdCall)]
        private static extern int CCDSetGPIOInOut( int deviceID, byte outputByte, out byte InByte );

        #endregion
    }

}
