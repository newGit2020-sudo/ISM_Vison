using System;
using System.Collections.Generic;
using System.Text;

namespace Sequence
{
   public interface IFunc_Obj
    {
        List<IFunc_Obj> Fun_obj_list { get; set; }
        string Name { get; set; }
        Type type { get;  }
        int Load();
        int Save();
        void Init();
        bool Run() ;
    }
}
