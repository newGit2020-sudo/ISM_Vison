using CameraD;
using HalconDotNet;
using System.Windows;

namespace ISM_Vison.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Camera c2 = new MVS_Camera.HaiKangCamera(Camera0, "c2");
            c2.OpenCamera();
            c2.Start();
        }
    }
}
