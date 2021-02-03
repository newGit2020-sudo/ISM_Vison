using ISM_Vison.Models;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Sequence.Views;
using static Infrastructure.KnownRegionNames;
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

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFunc_Obj, FUNC_OBJ2>("FUNC_OBJ2");
            containerRegistry.Register<IFunc_Obj, Sequence_Fun>("Sequence_Fun");
            VSDBContext vSDBContext = new VSDBContext();
            containerRegistry.RegisterInstance(vSDBContext);

        }
    }
}