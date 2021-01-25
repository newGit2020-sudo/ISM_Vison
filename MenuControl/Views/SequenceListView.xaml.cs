
using CommonServiceLocator;
using MenuControl.ViewModes;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>  : BindableBase
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class SequenceListView : UserControl
    {
        //private ObservableCollection<Sequence.SequenceModule> _observableCollection;

        //public ObservableCollection<Sequence.SequenceModule> ObservableCollection
        //{
        //    get { return _observableCollection; }
        //    set { _observableCollection = value; }
        //}


        public SequenceListView( )
        {
            InitializeComponent(); 
            this.DataContext = ServiceLocator.Current.GetInstance<SequenceListViewMode>();
        }
    }
}
