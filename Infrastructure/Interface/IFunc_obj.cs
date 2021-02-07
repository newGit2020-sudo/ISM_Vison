using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Infrastructure.Interface 
{
    public interface IFunc_Obj
    {
        ObservableCollection<IFunc_Obj> children { get; set; } 
        string Name { get; set; }
        IFunc_Obj parent {get;set;}
        Type type { get;  }
        int Load();
        int Save();
        void Init();
        bool Run() ;
    }
}
