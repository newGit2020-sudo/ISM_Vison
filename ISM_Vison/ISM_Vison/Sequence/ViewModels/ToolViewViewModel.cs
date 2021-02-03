
using ISM_Vison.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM_Vison.Sequence.ViewModels
{
    public class ToolViewViewModel : RegionViewModelBase
    {
        public ToolViewViewModel(IRegionManager regionManager) :base(regionManager)
        {
       //    ServiceLocator.Current.GetService()
        }
    }
}
