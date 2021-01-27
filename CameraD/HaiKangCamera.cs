using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Threading;

using System.Runtime.InteropServices;

//海康
using MvCamCtrl.NET;
using DeviceSource;
using System.Windows;
using CameraD;
using HLHal;

namespace MVS_Camera
{
    public partial class HaiKangCamera : Camera
    {
        public MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList;
        public CameraOperator m_pOperator;

        MyCamera.cbOutputdelegate m_CaptureCallback;
        public void CallBackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo, IntPtr pUser)
        {
            try
            {
                lock (this)
                {
                    OnGetImage(Convert.ToInt32(pFrameInfo.nWidth), Convert.ToInt32(pFrameInfo.nHeight), pData);
                }
            }
            catch
            { }
        }

        public HaiKangCamera(HCtrl ShowWindows, string cameraName)
            : base(ShowWindows, cameraName)
        {
            m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            m_pOperator = new CameraOperator();
        }

        //public override bool OpenCamera()
        //{
        //    int nRet;
        //    /*创建设备列表*/
        //    System.GC.Collect();
        //    //cbDeviceList.Items.Clear();
        //    nRet = CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
        //    if (0 != nRet)
        //    {
        //        MessageBox.Show("枚举设备失败!");
        //        return false;
        //    }

        //    //在窗体列表中显示设备名
        //    for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
        //    {
        //        MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
        //        if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
        //        {
        //            IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
        //            MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
        //            if (gigeInfo.chUserDefinedName != "")
        //            {
        //                //cbDeviceList.Items.Add("GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
        //            }
        //            else
        //            {
        //                //cbDeviceList.Items.Add("GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
        //            }
        //        }
        //        else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
        //        {
        //            IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
        //            MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
        //            if (usbInfo.chUserDefinedName != "")
        //            {
        //                //cbDeviceList.Items.Add("USB: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
        //            }
        //            else
        //            {
        //                //cbDeviceList.Items.Add("USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
        //            }
        //        }
        //    }

        //    //选择第一项
        //    if (m_pDeviceList.nDeviceNum != 0)
        //    {
        //        //cbDeviceList.SelectedIndex = 0;
        //        //获取选择的设备信息
        //        MyCamera.MV_CC_DEVICE_INFO device =
        //            (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[0],
        //                                                          typeof(MyCamera.MV_CC_DEVICE_INFO));

        //        //打开设备
        //        nRet = m_pOperator.Open(ref device);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            MessageBox.Show("设备打开失败!");
        //            return false;
        //        }

        //        nRet = m_pOperator.SetIntValue("GevHeartbeatTimeout", 5000);

        //        //设置采集连续模式
        //        //m_pOperator.SetEnumValue("AcquisitionMode", 2);// 工作在连续模式
        //        SetTrigger(TriggerMode.Soft_Mode);//软触发

        //        float fExposure = 0;
        //        m_pOperator.GetFloatValue("ExposureTime", ref fExposure);

        //        float fGain = 0;
        //        m_pOperator.GetFloatValue("Gain", ref fGain);

        //        float fFrameRate = 0;
        //        m_pOperator.GetFloatValue("ResultingFrameRate", ref fFrameRate);


        //        m_CaptureCallback = new MyCamera.cbOutputdelegate(CallBackFunc);
        //        m_pOperator.RegisterImageCallBack(m_CaptureCallback, IntPtr.Zero);

        //        //开始采集
        //        nRet = m_pOperator.StartGrabbing();
        //        if (CameraOperator.CO_OK != nRet)
        //        {
        //            MessageBox.Show("开始取流失败！");
        //            return false;
        //        }

        //        //标志位置位false
        //        m_bGrabbing = false;
        //    }

        //    m_bIsOpen = true;
        //    return true;
        //}
        public override bool OpenCamera()
        {
            int nRet;
            /*创建设备列表*/
            System.GC.Collect();
            //cbDeviceList.Items.Clear();
            nRet = CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
            if (0 != nRet)
            {
                MessageBox.Show("枚举设备失败!");
                return false;
            }

            //在窗体列表中显示设备名
            for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    if (gigeInfo.chUserDefinedName == m_sCameraName)
                    {
                            //打开设备
                            nRet = m_pOperator.Open(ref device);
                            if (MyCamera.MV_OK != nRet)
                            {
                                MessageBox.Show("设备打开失败!");
                                return false;
                            }

                            nRet = m_pOperator.SetIntValue("GevHeartbeatTimeout", 5000);

                            //设置采集连续模式
                            //m_pOperator.SetEnumValue("AcquisitionMode", 2);// 工作在连续模式
                            SetTrigger(TriggerMode.Soft_Mode);//软触发

                            float fExposure = 0;
                            m_pOperator.GetFloatValue("ExposureTime", ref fExposure);

                            float fGain = 0;
                            m_pOperator.GetFloatValue("Gain", ref fGain);

                            float fFrameRate = 0;
                            m_pOperator.GetFloatValue("ResultingFrameRate", ref fFrameRate);


                            m_CaptureCallback = new MyCamera.cbOutputdelegate(CallBackFunc);
                            m_pOperator.RegisterImageCallBack(m_CaptureCallback, IntPtr.Zero);
                        //开始采集
                        nRet = m_pOperator.StartGrabbing();
                        if (CameraOperator.CO_OK != nRet)
                        {
                            MessageBox.Show("开始取流失败！");
                            m_bIsOpen = false;
                        }
                        else
                        {
                            //标志位置位false
                            m_bGrabbing = false;
                            m_bIsOpen = true;   
                        }
                        return m_bIsOpen;
                    } 
                } 
            }
            MessageBox.Show("相机" + m_sCameraName +"打开失败!");
            return false;
        }
        public override bool CloseCamera()
        {
            try
            {
                m_bIsOpen = false;

                //先停止视频模式，等线程结束以后再停止流，否则会报错
                StopLive();
                //Application.DoEvents();
                Thread.Sleep(100);
                //停止采集
                int nRet = m_pOperator.StopGrabbing();
                if (nRet != CameraOperator.CO_OK)
                {
                    MessageBox.Show("停止取流失败！");
                }
                Thread.Sleep(100);
                m_pOperator.Close();
                m_bGrabbing = false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override bool OneShot()
        {
            int nRet;

            SetTrigger(TriggerMode.Soft_Mode);
            //触发命令
            nRet = m_pOperator.CommandExecute("TriggerSoftware");
            if (CameraOperator.CO_OK != nRet)
            {
                //MessageBox.Show("触发失败！");
                return false;
            }
            return true;
        }
        public override int GetExposure()
        {
            float fExposure = 0;
            m_pOperator.GetFloatValue("ExposureTime", ref fExposure);
            return Convert.ToInt32(fExposure);
        }
        public override int GetGain()
        {
            float fGain = 0;
            m_pOperator.GetFloatValue("Gain", ref fGain);
            return Convert.ToInt32(fGain);
        }
        public override bool ChangeExpouse(int expouse)
        {
            int nRet;
            m_pOperator.SetEnumValue("ExposureAuto", 0);
            nRet = m_pOperator.SetFloatValue("ExposureTime", Convert.ToInt32(expouse));
            if (nRet != CameraOperator.CO_OK)
            {
                MessageBox.Show("设置曝光时间失败！");
            }
            //nRet = m_pOperator.SetFloatValue("AcquisitionFrameRate", float.Parse(tbFrameRate.Text));
            //if (nRet != CameraOperator.CO_OK)
            //{
            //    MessageBox.Show("设置帧率失败！");
            //} 
            return true;
        }
        public override bool ChangeGain(int gain)
        {
            int nRet;
            m_pOperator.SetEnumValue("GainAuto", 0);
            nRet = m_pOperator.SetFloatValue("Gain", Convert.ToInt32(gain));
            if (nRet != CameraOperator.CO_OK)
            {
                MessageBox.Show("设置增益失败！");
            }
            return true;
        }
        public override void SetTrigger(TriggerMode trigger)
        {
            if (trigger == TriggerMode.Trigger_Mode)
            {//硬触发
                m_pOperator.SetEnumValue("TriggerMode", 1);
                m_pOperator.SetEnumValue("TriggerSource", 0);
            }
            else if (trigger == TriggerMode.Soft_Mode)
            {//软触发
                m_pOperator.SetEnumValue("TriggerMode", 1);
                m_pOperator.SetEnumValue("TriggerSource", 7);
            }
            else //连续
                m_pOperator.SetEnumValue("TriggerMode", 0);
            ResetAllEvent();
        }

        public override void StartLive(int ShowSelect = 0)
        {
            SetTrigger(TriggerMode.Continue_Mode);
            //开始采集
            //int nRet = m_pOperator.StartGrabbing();
            //if (MyCamera.MV_OK != nRet)
            //{
            //    MessageBox.Show("开始取流失败！");
            //    return;
            //}

            //标志位置位true
            m_bGrabbing = true;
        }
        public override void StopLive()
        {
            SetTrigger(TriggerMode.Soft_Mode);
            //int nRet = -1;
            ////停止采集
            //nRet = m_pOperator.StopGrabbing();
            //if (nRet != CameraOperator.CO_OK)
            //{
            //    MessageBox.Show("停止取流失败！");
            //}

            //标志位设为false
            m_bGrabbing = false;
        }

        public override void PauseLive(bool bPause = true) { return; }
        public override bool IsTrigger() { return true; }
        public override int GetWidth() { return 0; }
        public override int GetHeight() { return 0; }
        public override int GetBitsPerPixel() { return 0; }
    }
}
