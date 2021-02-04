using DataDb;
using ISM_Vison.Core;
using ISM_Vison.Models;
using ISM_Vison.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Sequence
{
    public class ISM_VisonModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
        public ISM_VisonModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
        {
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this._regionViewRegistry.RegisterViewWithRegion(RegionNames.ToolRegion, typeof(ToolView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
         
        }
    }
}