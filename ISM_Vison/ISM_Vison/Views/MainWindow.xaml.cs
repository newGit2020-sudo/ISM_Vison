using CameraD;
using CommonServiceLocator;
using HalconDotNet;
using ISM_Vison.Models;
using ISM_Vison.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Prism.Ioc;
using Sequence;
using System;
using System.Windows;

namespace ISM_Vison.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerProvider _Container;
        IContainerRegistry _ContainerRegistry; 
        public MainWindow(IContainerProvider Container)
        {
            InitializeComponent();
            this._Container = Container;
            //this._ContainerRegistry = ContainerRegistry;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CameraBase c2 = new MVS_Camera.HaiKangCamera(Camera0, "c2");
            c2.OpenCamera();
            c2.Start();
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
            Product product = new Product();
            string output = JsonConvert.SerializeObject(product);
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

            IFunc_Obj dddd2= _Container.Resolve<IFunc_Obj>("FUNC_OBJ2");
            dddd2.Name = "dddd2";
            IFunc_Obj rrrr2 =_Container.Resolve<IFunc_Obj>("FUNC_OBJ2");
            rrrr2.Name = "rrrr2";

            IFunc_Obj dddd = _Container.Resolve<IFunc_Obj>("FUNC_OBJ");
            dddd.Name = "dddd";
            IFunc_Obj rrrr = _Container.Resolve<IFunc_Obj>("FUNC_OBJ");
            rrrr.Name = "rrrr";
        }
        public CameraBase[] Cameras=new CameraBase[4];
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            Cameras[0] = new MVS_Camera.HaiKangCamera(Camera0, "c1");
            Cameras[1] = new MVS_Camera.HaiKangCamera(Camera1, "c2");
            Cameras[2] = new MVS_Camera.HaiKangCamera(Camera2, "c3");
            Cameras[3] = new MVS_Camera.HaiKangCamera(Camera3, "c4");

            for (int i = 0; i < Cameras.Length; i++)
            {
                if (Cameras[i].OpenCamera())
                {
                    Cameras[i].Start();
                } 
            }
        }
    }  
}
