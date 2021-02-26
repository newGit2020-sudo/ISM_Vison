
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
            IDBServer dBServer = _Container.Resolve<IDBServer>();
            TopSequenceFunc_Obj topSequenceFunc_Obj = _Container.Resolve<TopSequenceFunc_Obj>();
            Infrastructure.Models.Sequence sequence = new Infrastructure.Models.Sequence();
            sequence.Name += dBServer.GetMaxSequenceID() + 1;
            dBServer.Sequences.Add(sequence);
            dBServer.SaveChanges();
            topSequenceFunc_Obj.Load(sequence);

            SequenceFunc_Obj _sequenceFunc_Obj = _Container.Resolve<SequenceFunc_Obj>();
            _sequenceFunc_Obj.Name += dBServer.GetMaxSequenceID() +1;
            topSequenceFunc_Obj.Index = topSequenceFunc_Obj.Children.Count - 1;
        }
    }
}
