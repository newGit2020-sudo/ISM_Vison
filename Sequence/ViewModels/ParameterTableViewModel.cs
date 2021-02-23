using Infrastructure.Code;
using ISM_Vision.Core.Mvvm;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Sequence.Sequence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence.ViewModels
{
    public class ParameterTableViewModel : RegionViewModelBase
    {
       public SequenceFunc_Obj sequenceFunc_Obj { get; set; }
       static int i = 0;
        public string value { get; set; }
        public ObservableCollection<TTextbox> DataContexs { get; set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _regionViewRegistry;
        private readonly  IContainerProvider _Container;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private void Navigate(string viewName){}
        public ParameterTableViewModel(IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IContainerProvider Container) : base(regionManager)
        {
            value = i.ToString();
            i++;
            this._regionViewRegistry = regionViewRegistry;
            this._regionManager = regionManager;
            this._Container = Container;
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);

        }
    }
}
