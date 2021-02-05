using DataDb;
using ISM_Vison.Models;
using ISM_Vison.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ISM_Vison.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private DBServer _serveDB;
        public MainWindow _mainWindow;
        IContainerProvider _Container;
        // public  ObservableCollection<ISM_Vison.Models.Sequence> Sequences { get; set; } = DBServer.GetInstance().Sequences;
         public  ObservableCollection<ISM_Vison.Models.Sequence> Sequences { get; set; } 
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> TestCommand { get; private set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;

        private string _title = "ISM-Vison";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IContainerProvider Container)
        {
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            this._Container = Container;
            _serveDB = _Container.Resolve<DBServer>();
            Sequences = _serveDB.Sequences;
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
            this.TestCommand = new DelegateCommand<string>(this._TestCommand);
        }
        private void Navigate(string viewName)
        {
        }
        private void _TestCommand(string viewName)
        {
            foreach (var item in Sequences)
            {
                item.Name += 3;
            } 
        }
    }
}
