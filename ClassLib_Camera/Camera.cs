using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
//using System.Collections.Specialized;
//using System.Drawing.Imaging;
//using System.Diagnostics;
//using System.Collections.ObjectModel;

using HalconDotNet;

using ClassLib_HalconControl;
using ClassLib_HalconPackage;

namespace ClassLib_Camera
{
    public abstract partial class Camera// : Control
    {
        public int m_iWidth, m_iHeight;
        public const int CAMERA_THREAD_TIMEOUT = 2000;
        public enum TriggerMode
        { 
            Continue_Mode = 0,
            Soft_Mode = 1,
            Trigger_Mode = 2,
        }
        /// <summary>
        /// 相机打开标识
        /// </summary>
        protected bool m_bIsOpen = false;
        /// <summary>
        ///图像抓取中,没有用到
        /// </summary>
        public bool m_bGrabbing = false;//没有用

        #region 引用类
        protected INI文件读写 globalClass = new INI文件读写();
        protected HalconPackage halconPackage = new HalconPackage();
        #endregion
        public ShowControl m_ShowWindows;
        public string chSerialNumber="";
        public string m_sCameraName = "";
        public Object imageLock = new object();
        private static readonly object obj = new object();
        /// <summary>
        /// 连续采集循环
        /// </summary>
        public bool m_bLivingLoop = false; //
        /// <summary>
        /// 软触发开关
        /// </summary>
        public bool m_bSnap = false;       //软触发开关
        /// <summary>
        /// 连续采集状态
        /// </summary>
        public bool m_IsLiving = false;    
        /// <summary>
        /// 采集到的图像
        /// </summary>
        public HObject m_hImage = null;//new HObject();
        private HObject _tmpImage = new HObject();
        /// <summary>
        /// 图像翻转: m_iDir=0水平轴翻转;m_iDir=1垂直翻转; m_iDir=2对接翻转;其他值忽略
        /// </summary>
        public int m_iDir = -1;

        private Camera()
        {
            OnGetImage = HGrabImage;
        }
        public Camera(ShowControl ShowWindows, string cameraName)
        {
            OnGetImage = HGrabImage;
            m_bGrabbing = false;
            m_ShowWindows = ShowWindows;
            m_sCameraName = cameraName;
            //imageLock = m_ShowWindows.thisLock;
            ////imageLock = ShowControl.thisLock;

            ResetAllEvent();
        }
        public void ChangeShowWindow(ShowControl ShowWindows)
        {
            m_ShowWindows = ShowWindows;
        }
        /// <summary>
        /// 翻转图像
        /// </summary>
        /// <param name="tmpImage"></param>
        public void SetMirror(HObject tmpImage)
        {
            if (m_iDir < 0) 
                return;
            try
            {
                if (m_hImage != null)
                {
                    m_hImage.Dispose();
                }
                if (0 == m_iDir)
                    HOperatorSet.MirrorImage(tmpImage, out m_hImage, "row");
                else if (1 == m_iDir)
                    HOperatorSet.MirrorImage(tmpImage, out m_hImage, "column");
                else if (2 == m_iDir)
                {
                    HOperatorSet.MirrorImage(tmpImage, out m_hImage, "row");
                    HOperatorSet.MirrorImage(m_hImage, out m_hImage, "column");
                }
                else
                    HOperatorSet.MirrorImage(tmpImage, out m_hImage, "diagonal");//对角翻转
                //tmpImage.Dispose();
            }
            catch (HalconException HDevExpDefaultException)
            {
                throw HDevExpDefaultException;
            }
            finally
            {
                tmpImage.Dispose();
            }
        }
        /// <summary>
        ///开闭运算模式 1=开运算,2=闭运算,其他值无效
        /// </summary>
        public int m_MaskModel = 0;
        /// <summary>
        ///开闭运算Mask的Size 
        /// </summary>
        public int m_MaskSizeHeight = 5;
        public int m_MaskSizeWidth = 5;
        /// <summary>
        /// 对图像执行开/闭运算
        /// </summary>
        /// <param name="srcImage"></param>
        public void CopyMaskImage(HObject srcImage)
        {
            lock (imageLock)
            {
                try
                {

                    if (m_hImage!=null)
                    {
                        m_hImage.Dispose();
                    }
                    //if (m_MaskModel == 1)
                    //    HOperatorSet.GrayOpeningRect(srcImage, out m_hImage, m_MaskSizeHeight, m_MaskSizeWidth);
                    //else if (m_MaskModel == 2)
                    //    HOperatorSet.GrayClosingRect(srcImage, out m_hImage, m_MaskSizeHeight, m_MaskSizeWidth);
                    //else if (!srcImage.Equals(m_hImage))
                    HOperatorSet.CopyImage(srcImage, out m_hImage);
                    srcImage.Dispose();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
                finally
                {
                    srcImage.Dispose();
                }
            }
        }

        public void CopyOpenCloseImage(HObject srcImage, int times)
        {
            lock (imageLock)
            {
                try
                {
                    if (m_MaskModel == 1)
                    {
                        for (int i = 0; i < times; i++)
                            HOperatorSet.GrayErosionRect(srcImage, out m_hImage, m_MaskSizeHeight, m_MaskSizeWidth);
                        for (int i = 0; i < times; i++)
                            HOperatorSet.GrayDilationRect(m_hImage, out m_hImage, m_MaskSizeHeight, m_MaskSizeWidth);
                    }
                    else if (m_MaskModel == 2)
                    {
                        for (int i = 0; i < times; i++)
                            HOperatorSet.GrayDilationRect(srcImage, out m_hImage, m_MaskSizeHeight, m_MaskSizeWidth);
                        for (int i = 0; i < times; i++)
                            HOperatorSet.GrayErosionRect(m_hImage, out m_hImage, m_MaskSizeHeight, m_MaskSizeWidth);
                    }
                    else if (!srcImage.Equals(m_hImage))
                        HOperatorSet.CopyImage(srcImage, out m_hImage);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
            }
        }
        public void CopyImage(out HObject hDesImage)
        {
            lock (imageLock)             
            {
                try
                {
                    HOperatorSet.CopyImage(m_hImage, out hDesImage);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    hDesImage = null;
                }
                
            }
        }
        public bool IsShow=true;
        //private void CopyImage()
        //{
        //    lock (imageLock)
        //    {
        //        m_ShowWindows.ShowImage = m_hImage;
        //    }
        //}
        //public delegate void CopyImageDelegat();
        //CopyImageDelegat copyImage = null;
        public void ShowImage()
        {
            //需要线程保护或创建新的image或按值拷贝
            try
            {
               
                lock (imageLock)
                {
                    m_ShowWindows.ShowImage = m_hImage;
                }
                if (IsShow==true)
                {
                    m_ShowWindows.RefreshShow();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 软触发
        /// </summary>
        /// <param name="timerOut"></param>
        /// <param name="bTraggerHardware"></param>
        /// <returns></returns>
        public bool SoftSnap(int timerOut = 220,bool bTraggerHardware = false)
        {
            try
            {
                m_bSnap = true;
                if (!bTraggerHardware)
                    OneShot();
                int time = 0;
                while (m_bSnap)
                {
                    //Application.DoEvents();
                    if (!m_bSnap || !m_bIsOpen)
                        break;
                    if (!bTraggerHardware && time > 200)
                        OneShot();
                    if (time > timerOut)
                    {
                        //MessageBox.Show("等待触发超时", "", MessageBoxButtons.OK);
                        return false;
                    }
                    Application.DoEvents();
                    Thread.Sleep(10);
                    Application.DoEvents();
                    time += 10;
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return false;
            }
        }
        public bool TriggerSnap(int timerOut = CAMERA_THREAD_TIMEOUT)
        {
            return SoftSnap(timerOut, true);
        }
        // 软触发来启用视频模式
        Thread LivingThread;
        public bool IsOpened()
        {
            return m_bIsOpen;
        }
        public bool Start()
        {
            if (!IsOpened())
                return false;

            m_bLivingLoop = true;
            LivingThread = new Thread(new ThreadStart(LiveThreadFunction));
            LivingThread.Start();
            int time = 0;
            while (!m_IsLiving)
            {
                Thread.Sleep(5);
                time++;
                if (time > 200)
                {
                    return false;
                }
            }
            return true;
        }
        public bool Stop()
        {
            StopLive();
            if (!IsOpened() || LivingThread == null)
                return false;

            m_bLivingLoop = false;
            LivingThread.Join();
            int time = 0;
            while (m_IsLiving)
            {
                Thread.Sleep(5);
                time++;
                if (time > 200)
                {
                    MessageBox.Show("关闭视频失败");
                    return false;
                }
            }
            LivingThread = null;
            return true;
        }
        private void LiveThreadFunction()
        {
            if (!IsOpened())
                return;

            //Start();相机自带视频模式
            while (m_bLivingLoop)
            {
                try
                {
                    m_IsLiving = true;
                    SoftSnap();
                    //ShowImage();
                    //Application.DoEvents();
                    //Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    m_IsLiving = false;
                }
            }
            m_IsLiving = false;
            //Stop();
        }
        /// <summary>
        /// 用回调函数来触发图像处理,可在图像处理类中指定
        /// </summary>
        /// <param name="ImageBuffers"></param>
        /// <returns></returns>
        public delegate bool pOnGetImage(int width, int height, IntPtr pImage);
        public pOnGetImage OnGetImage;
        public AutoResetEvent m_mapEventTotal = new AutoResetEvent(false);
        public void ResetAllEvent()
        {
                m_mapEventTotal.Reset();
        }
        public void SetAllEvent()
        {
                m_mapEventTotal.Set();
        }
      
      
     
        /// <summary>
        /// 获取图像,完成后set AutoResetEvent事件
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public bool HGrabImage(int width, int height, IntPtr pImage)
        {
            try
            //if (m_bSnap)
            {                
                bool bRtn = false;
                if (!m_bIsOpen)
                    return false;
                lock (imageLock)
                {
                    HObject __Image = null;
                    if (m_iDir >= 0)
                    {
                        bRtn = HalconPackage.Image2HObject(width, height, pImage, ref __Image);//_tmpImage
                       SetMirror(__Image);  //_tmpImage
                    }
                    else
                        bRtn = HalconPackage.Image2HObject(width, height, pImage, ref __Image);//
                   CopyMaskImage(__Image);
                 //   CopyOpenCloseImage(__Image, 5);                   
                    //要防止在遍历时m_ListEventNow被修改，所以修改 m_ListEventNow 时需要lock (thisLock)
                    //m_bSnap = false;
                }
                ShowImage();
                m_mapEventTotal.Set();
                return bRtn;
            }
            finally
            {
                m_bSnap = false;
            }

            //return false;
        }
        public bool CvGrabImage(int width, int height, IntPtr pImage)
        {
            m_bSnap = false;
            return true;
        }

        public virtual bool OpenCamera()
        {
             m_bIsOpen = true;     // 相机打开标识 
             m_bGrabbing = false;
             return true;
        }
        public virtual bool CloseCamera()   
        {
             m_bIsOpen = false;   // 相机打开标识 
             m_bGrabbing = false;
             return true;
        }
        /// <summary>
        /// 开始抓取一幅图像 Starts the grabbing of one image
        /// </summary>
        /// <returns></returns>
        public abstract bool OneShot();
        /// <summary>
        /// 获取曝光值
        /// </summary>
        /// <returns></returns>
        public virtual int GetExposure() { return 10; }
        public virtual int GetExposureMax() { return 10; }
        public virtual int GetExposureMin() { return 10; }
        public virtual int GetGain() { return 0; }
        public virtual bool ChangeExpouse(int expouse) { return true;}
        public virtual bool ChangeGain(int gain){return true;}

        //SDK自带视频模式
        public virtual void StartLive(int ShowSelect = 0) { m_bGrabbing = true; }
        public virtual void StopLive() { m_bGrabbing = false; }
        public virtual void PauseLive(bool bPause = true){}
        //SDK自带视频模式

        public virtual bool IsTrigger() { return false; }
        public virtual void SetTrigger(TriggerMode trigger) { }
        public virtual int GetWidth() { return 0; }
        public virtual int GetHeight() { return 0; }
        public virtual int GetBitsPerPixel() { return 0; }
    }

}
