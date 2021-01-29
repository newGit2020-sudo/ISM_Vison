using CameraD;
using CommonServiceLocator;
using HalconDotNet;
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
        public MainWindow(IContainerProvider Container)
        {
            InitializeComponent();
            this._Container = Container;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Camera c2 = new MVS_Camera.HaiKangCamera(Camera0, "c2");
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
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}
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
    }  
}
