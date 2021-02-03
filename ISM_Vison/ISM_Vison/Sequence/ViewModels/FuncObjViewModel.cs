using ISM_Vison.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM_Vison.Sequence.ViewModels
{
    public class FuncObjViewModel : RegionViewModelBase
    {
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private void Navigate(string viewName)
        {
           
        }
        public FuncObjViewModel(IRegionManager regionManager) : base(regionManager)
        {
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
        }
    }
}
