using MenuControl.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using static Infrastructure.KnownRegionNames;

namespace MenuControl
{
    public class MenuControlModule : IModule
    {
        public MenuControlModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
        {
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            //this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;

       
        ////private void Navigate(string viewName)
        ////{
        ////    this._regionManager.RequestNavigate(MainRegion, viewName);
        ////}

        public void Initialize()
        {
            this._regionViewRegistry.RegisterViewWithRegion(MenuRegion, typeof(Views.MenuView));
            this._regionViewRegistry.RegisterViewWithRegion(ToolRegion, typeof(Views.ToolBarView));
            this._regionViewRegistry.RegisterViewWithRegion(SequenceListlRegion, typeof(Views.SequenceListView));

        }
    }
}