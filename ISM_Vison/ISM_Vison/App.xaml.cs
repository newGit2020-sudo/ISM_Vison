
using ISM_Vison.Services;
using ISM_Vison.Services.Interfaces;
using ISM_Vison.Views;
using Prism.Ioc;
using Prism.Modularity;
using Sequence;
using System.Windows;

namespace ISM_Vison
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();

            //this._regionViewRegistry = ServiceLocator.Current.GetInstance<IRegionViewRegistry>();
            //this._regionManager  = ServiceLocator.Current.GetInstance<IRegionManager>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ISM_VisonModule>();
        }
    }
}
