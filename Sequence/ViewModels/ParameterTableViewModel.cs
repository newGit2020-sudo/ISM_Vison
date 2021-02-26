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
        private SequenceFunc_Obj _sequenceFunc;
        public SequenceFunc_Obj SequenceFun
        {
            get { return _sequenceFunc; }
            set
            {
                _sequenceFunc = value;
             //   IDBServer dBServer = _Container.Resolve<IDBServer>();
                camera = dBServer.GetCamera(_sequenceFunc.sequence.CameraId);
                if (camera!=null)
                {
                    camera.Index = 0;
                }
                
                RaisePropertyChanged(); }
        }
        private Camera camera { get; set; }
        public ObservableCollection<Infrastructure.Models.Camera> CameraConfig { get; set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly  IContainerProvider _Container;
        private IDBServer dBServer;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<Camera> IsSelectedCommand { get; private set; }
        private void Navigate(string viewName){}
        public ParameterTableViewModel(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IContainerProvider Container) : base(regionManager)
        {
            this._Container = Container;
             dBServer = _Container.Resolve<IDBServer>();
            this.CameraConfig = dBServer.CameraConfig;
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            this._Container = Container;
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
            this.IsSelectedCommand = new DelegateCommand<Camera>(this._IsSelectedCommand);
        }
        private void _IsSelectedCommand(Camera SelectItem)
        {
            camera = SelectItem as Camera;
            _sequenceFunc.sequence.CameraId = camera.CameraId;
        }
    }
}
