using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Interface 
{
   public interface IFunc_Obj
    {
        ObservableCollection<IFunc_Obj> Fun_obj_list { get; set; }
        string Name { get; set; }
        Type type { get;  }
        int Load();
        int Save();
        void Init();
        bool Run() ;
    }
}
