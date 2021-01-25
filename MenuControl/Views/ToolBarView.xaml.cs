using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Sequence;
using Sequence.Views;
using SequenceModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MenuControl.Views
{
    /// <summary>
    /// ToolBarView.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBarView : UserControl
    {
        IUnityContainer _Container;
        public ToolBarView(IUnityContainer Container)
        {
            InitializeComponent();
            this._Container = Container;
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SequenceView sequenceView = new SequenceView();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //FUNC_OBJ TEMP1 = _Container.ResolveAll<IFunc_obj>();
            //TEMP1.Name = "hello";
            //   FUNC_OBJ TEMP12 = _Container.Resolve<IFunc_obj>(null);

            //var collection = ServiceLocator.Current.GetAllInstances(typeof(IFunc_obj));
            var collection = ServiceLocator.Current.GetService(typeof(IFunc_obj));
            FUNC_OBJ TEMP1 = collection as FUNC_OBJ;
           //  IFunc_obj[] n = collection as IFunc_obj[];
            //foreach (IFunc_obj item in collection)
            //{
            //    Type type = item.type;
            //}
        }
    }
}
