using ISM_Vison.Models;
using ISM_Vison.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace ISM_Vison.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public VSDBContext db { get; private set; }
        public MainWindow _mainWindow{ get; private set; }
        IContainerProvider _Container;
        IContainerRegistry _ContainerRegistry;
        public DelegateCommand<string> NavigateCommand { get; private set; }
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
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
            VSDBContext rrrr2 = _Container.Resolve<VSDBContext>();
        }
        private void Navigate(string viewName)
        {
            // VSDBContext
       
        }
    }
}
