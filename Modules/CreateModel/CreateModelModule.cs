using Infrastructure.Interface;
using ISM_Vison.Core.Mvvm;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CreateModel
{
    public class CreateModelModule : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
        public CreateModelModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
        {
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFunc_Obj, ViewModels.MainWindowlViewModel>();
        }
    }
}