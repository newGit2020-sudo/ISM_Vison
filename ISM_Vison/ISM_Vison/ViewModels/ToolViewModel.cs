
using ISM_Vison.Core.Mvvm;
using ISM_Vison.Sequence;
using ISM_Vison.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM_Vison.ViewModels
{
    public class ToolViewModel : RegionViewModelBase
    {
        IDialogService dialog;
        IContainerProvider _Container;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> CreateCommand { get; private set; }
        public ToolViewModel(IRegionManager regionManager , IContainerProvider Container,IDialogService dialog)
            :base(regionManager)
        {
            this._Container = Container;
            this.dialog = dialog;
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
            this.CreateCommand = new DelegateCommand<string>(this.Create);
        }
        private void Navigate(string viewName)
        {
        }
        private void Create(string viewName)
        {
            //dialog.ShowDialog("alert"); 
            //dialog.ShowDialog("WarningDialog");

             TopSequenceFunc_Obj topSequenceFunc_Obj = _Container.Resolve<TopSequenceFunc_Obj>();
            SequenceFunc_Obj _sequenceFunc_Obj = _Container.Resolve<SequenceFunc_Obj>();
           // _sequenceFunc_Obj.sequence.Name = "hello1111";
            _sequenceFunc_Obj.Name = "hello1111";
            topSequenceFunc_Obj.Children.Add(_sequenceFunc_Obj);
           topSequenceFunc_Obj.Save();

        }
    }
}
