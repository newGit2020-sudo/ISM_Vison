using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ISM_Vison.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public DelegateCommand<string> NavigateCommand { get; private set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;

        private string _title = "ISM-Vison";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
        {

            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
        }
        private void Navigate(string viewName)
        {

        }
    }
}
