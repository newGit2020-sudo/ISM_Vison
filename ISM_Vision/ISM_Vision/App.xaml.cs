
using Infrastructure.Interface;
using ISM_Vision.Models;
using ISM_Vision.Sequence;
using ISM_Vision.Services;
using ISM_Vision.Views;
using Prism.Ioc;
using Prism.Modularity;
using PrismMetroSample.Shell.ViewModels.Dialogs;
using PrismMetroSample.Shell.Views.Dialogs;
using System.Windows;

namespace ISM_Vision
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
            moduleCatalog.AddModule<ISM_VisionModule>();
            moduleCatalog.AddModule<Infrastructure.InfrastructureModule>();
        }
    }
}
