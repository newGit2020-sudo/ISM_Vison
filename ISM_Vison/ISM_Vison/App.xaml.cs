
using Infrastructure.Interface;
using ISM_Vison.Models;
using ISM_Vison.Sequence;
using ISM_Vison.Services;
using ISM_Vison.Views;
using Prism.Ioc;
using Prism.Modularity;
using PrismMetroSample.Shell.ViewModels.Dialogs;
using PrismMetroSample.Shell.Views.Dialogs;
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
            VSDBContext db = new VSDBContext();
            DBServer dBServer = DBServer.GetInstance();
            containerRegistry.RegisterInstance(typeof(DBServer), dBServer); //注册实例
            containerRegistry.RegisterSingleton<ViewModels.MainWindowViewModel>(); //注册单例
            containerRegistry.RegisterSingleton<Sequence.TopSequenceFunc_Obj>();//注册单例
            containerRegistry.Register<SequenceFunc_Obj>();
            //注册对话框
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>("alert");
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialogWindow<DialogWindow>("WarningDialog");
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ISM_VisonModule>();
            moduleCatalog.AddModule<Infrastructure.InfrastructureModule>();
        }
    }
}
