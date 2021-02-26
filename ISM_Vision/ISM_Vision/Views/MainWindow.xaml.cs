﻿
using CameraD;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Windows;

namespace ISM_Vision.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 //       public static MainWindowViewModel mainWindowViewModel { get; set; }
        IContainerProvider _Container;
        public MainWindow(IContainerProvider Container)
        {
            InitializeComponent();
            this._Container = Container;
        }
        public class Product
        {
            public string Name = "Apple";
            public DateTime ExpiryDate = new DateTime(2008, 12, 28);
            public Decimal Price = 3.99M;
            public string[] Sizes { get; set; } = new string[] { "Small", "Medium", "Large" };
            public byte[] Image { get; set; } = new byte[4]{ 25 ,26,27,28};
        }
        private void OpenCamer_Click(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < Cameras.Length; i++)
            //{
            //    try
            //    {
            //        Cameras[i] = new MVS_Camera.HaiKangCamera(Camera0, "c2");
            //        Cameras[i].Start();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //}
        }
        public CameraBase[] Cameras=new CameraBase[4];
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Cameras[1] = new MVS_Camera.HaiKangCamera(Camera1, "c2");
            //Cameras[2] = new MVS_Camera.HaiKangCamera(Camera2, "c3");
            //Cameras[3] = new MVS_Camera.HaiKangCamera(Camera3, "c4");
            for (int i = 0; i < 1; i++)
            {
                try
                {
                    Cameras[0] = new MVS_Camera.HaiKangCamera(Camera0, "c2");
                    if (Cameras[i].OpenCamera())
                        Cameras[i].Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
           // MainWindowViewModel mainWindowViewModel = _Container.Resolve<MainWindowViewModel>();
        }

        private void FunTest_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.DataContext;
            Product product = new Product();
            string output = JsonConvert.SerializeObject(product);
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

            //IFunc_Obj dddd2 = _Container.Resolve<IFunc_Obj>("FUNC_OBJ2");
            //dddd2.Name = "dddd2";
            //IFunc_Obj rrrr2 = _Container.Resolve<IFunc_Obj>("FUNC_OBJ2");
            //rrrr2.Name = "rrrr2";
        }

        private void 打开相机参数设置_Click(object sender, RoutedEventArgs e)
        { 
            MVSHalconWindow.Form1 form1 = new MVSHalconWindow.Form1();
            form1.Show();
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var item in Cameras)
            {
                item?.CloseCamera();
            }
            System.Environment.Exit(0);//强制退出所有线程
        }
    }  
}
