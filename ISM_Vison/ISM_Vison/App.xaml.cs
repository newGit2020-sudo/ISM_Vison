using ISM_Vison.Modules.ModuleName;
using ISM_Vison.Services;
using ISM_Vison.Services.Interfaces;
using ISM_Vison.Views;
using Prism.Ioc;
using Prism.Modularity;
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
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
