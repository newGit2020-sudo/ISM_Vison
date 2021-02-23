
using Infrastructure.Models;
using ISM_Vision.Core.Mvvm;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Sequence.Sequence;

namespace Sequence.ViewModels
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
            TopSequenceFunc_Obj topSequenceFunc_Obj = _Container.Resolve<TopSequenceFunc_Obj>();
            SequenceFunc_Obj _sequenceFunc_Obj = _Container.Resolve<SequenceFunc_Obj>();
            IDBServer dBServer = _Container.Resolve<IDBServer>();
            _sequenceFunc_Obj.Name += dBServer.GetMaxSequenceID();
            if (_sequenceFunc_Obj.Save() == 1)
            {
                topSequenceFunc_Obj.Children.Add(_sequenceFunc_Obj);
                topSequenceFunc_Obj.Index = topSequenceFunc_Obj.Children.Count - 1;
                //TODO:这里添加index=0；
               // _sequenceFunc_Obj.Index
            }
            //else
            //{
            //    throw new System.Exception("创建失败，保存数据出错");
            //}
        }
    }
}
