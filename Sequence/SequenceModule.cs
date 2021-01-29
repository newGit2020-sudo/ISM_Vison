using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Sequence.Views;
using static Infrastructure.KnownRegionNames;
namespace Sequence
{
    public class SequenceModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
       public SequenceModule(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
        {
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this._regionManager.RegisterViewWithRegion(ToolRegion, typeof(Views.ToolView)); 
            this._regionManager.RegisterViewWithRegion(SequenceRegion, typeof(Views.FuncList)); 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFunc_Obj, FUNC_OBJ2>("FUNC_OBJ2");
            containerRegistry.Register<IFunc_Obj, FUNC_OBJ>("FUNC_OBJ");
        }
    }
}