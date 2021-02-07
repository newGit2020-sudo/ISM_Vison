using ISM_Vison.Services;

using Prism.Ioc;
using Prism.Mvvm;
using Sequence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure.Interface;

namespace ISM_Vison.Sequence
{
    public class SequenceFunc_Obj : BindableBase, IFunc_Obj
    {
        public Infrastructure.Models.Sequence Sequence { get; set; } = new Infrastructure.Models.Sequence();
        private DBServer _serveDB;
        private IContainerProvider _Container;
        public string Name { get { return Sequence.Name; } set { Sequence.Name=value;  } } //"Sequence 01";
        public Type type { get => this.GetType(); }
        public ObservableCollection<IFunc_Obj> children { get; set ; }
        public IFunc_Obj parent { get; set; }

        public SequenceFunc_Obj(IContainerProvider Container)
        {
            this._Container = Container;
            this._serveDB = _Container.Resolve<DBServer>();

        }
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
            ObservableCollection<Infrastructure.Models.Sequence> Sequences = _serveDB.Sequences;
            Infrastructure.Models.Sequence kkkk = _serveDB.GetSequence(Name);
            if (kkkk==null)
            {
                _serveDB.db.Add(Sequence);
                _serveDB.SaveChanges();
            }
            else
            {

            }
            return 0;
        }
    }
}
