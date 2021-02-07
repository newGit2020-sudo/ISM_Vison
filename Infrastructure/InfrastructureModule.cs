using Infrastructure;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Infrastructure
{
    public class InfrastructureModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Infrastructure.Models.Camera>();
            containerRegistry.Register<Infrastructure.Models.Sequence>();
            containerRegistry.Register<Infrastructure.Models.IFunc_ObjTypeString>();
        }
    }

}