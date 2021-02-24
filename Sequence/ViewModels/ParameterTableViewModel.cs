using Infrastructure.Code;
using Infrastructure.Models;
using ISM_Vision.Core.Mvvm;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Sequence.Sequence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence.ViewModels
{
    public class ParameterTableViewModel : RegionViewModelBase
    {
        private Infrastructure.Models.Sequence _Sequence;
        public Infrastructure.Models.Sequence Sequence
        {
            get { return _Sequence; }
            set
            {
                _Sequence = value;
                IDBServer dBServer = _Container.Resolve<IDBServer>();
                camera = dBServer.GetCamera(_Sequence.CameraId);
                RaisePropertyChanged(); }
        }
        private Camera camera { get; set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly  IContainerProvider _Container;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private void Navigate(string viewName){}
        public ParameterTableViewModel(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IContainerProvider Container) : base(regionManager)
        {
            this._Container = Container;
            IDBServer dBServer = _Container.Resolve<IDBServer>();
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            this._Container = Container;
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
        }
    }
}
