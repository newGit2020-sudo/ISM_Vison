using ISM_Vision.Services;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Sequence.Sequence;

namespace ISM_Vision.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Product { get; set; }
        private DBServer _serveDB;
        IContainerProvider _Container;
        // public ObservableCollection<SequenceFunc_Obj> TopFunc_Obj { get; set; } = new ObservableCollection< SequenceFunc_Obj >();
        // public ObservableCollection<Infrastructure.Models.Sequence> Sequences { get; set; } 
        public TopSequenceFunc_Obj TopFunc_Obj { get; set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<SequenceFunc_Obj> IsSelectedCommand { get; private set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;

        private string _title = "ISM-Vison";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IContainerProvider Container)
        {
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            this._Container = Container;
            _serveDB = _Container.Resolve<DBServer>();
            TopFunc_Obj = _Container.Resolve<TopSequenceFunc_Obj>();
            TopFunc_Obj.Load();
     
            //foreach (var item in Sequences)
            //{
            //    SequenceFunc_Obj _sequenceFunc_Obj = _Container.Resolve<SequenceFunc_Obj>();
            //    TopFunc_Obj.Add(_sequenceFunc_Obj);
            //    _sequenceFunc_Obj.sequence = item;
            //    _sequenceFunc_Obj.Load();
            //}

            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
            this.IsSelectedCommand = new DelegateCommand<SequenceFunc_Obj>(this._IsSelectedCommand);
        }
        public string test { get; set; } = "firat";
        private void Navigate(string viewName)
        {
            
        }
        private void _IsSelectedCommand(SequenceFunc_Obj viewName)
        {
          
        }
    }
}
