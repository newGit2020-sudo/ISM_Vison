using Sequence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    public class FUNC_OBJ2 : IFunc_Obj
    {
        public string Name { get; set; }
        public Type type { get =>typeof(FUNC_OBJ2);  }
       
        public List<IFunc_Obj> Fun_obj_list { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public int Load()
        {
            throw new NotImplementedException();
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
