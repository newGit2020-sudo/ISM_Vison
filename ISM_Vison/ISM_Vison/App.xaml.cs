
using DataDb;
using Interface;
using ISM_Vison.Models;
using ISM_Vison.Sequence;
using ISM_Vison.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using Prism.Modularity;
using Sequence;
using System.Collections.ObjectModel;
using System.Linq;
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
            //this._regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFunc_Obj, FUNC_OBJ2>("FUNC_OBJ2");
            containerRegistry.Register<IFunc_Obj, Sequence_Fun>("Sequence_Fun");
            DBServer dBServer = DBServer.GetInstance();
            containerRegistry.RegisterInstance(typeof(DBServer), dBServer);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ISM_VisonModule>();  
        }
    }
}
