using ISM_Vision.Services;
using ISM_Vision.Core;
using ISM_Vision.Models;
using ISM_Vision.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ISM_Vision.Sequence;

namespace ISM_Vision
{
    public class ISM_VisionModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
        public ISM_VisionModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
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