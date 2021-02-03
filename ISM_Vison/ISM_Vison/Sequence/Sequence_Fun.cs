using Interface;
using Sequence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISM_Vison.Sequence
{
    public class Sequence_Fun : IFunc_Obj
    {
        public string Name { get; set; }
        public Type type { get => this.GetType(); }
        public List<IFunc_Obj> Fun_obj_list { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Init()
        {
            this.GetType();
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
