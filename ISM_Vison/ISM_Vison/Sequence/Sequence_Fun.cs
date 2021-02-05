using DataDb;
using Interface;
using Prism.Ioc;
using Prism.Mvvm;
using Sequence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISM_Vison.Sequence
{
    public class Sequence_Fun :BindableBase, IFunc_Obj 
    {
        public Models.Sequence Sequence { get; set; } = new Models.Sequence();
        private DBServer _serveDB;
        private IContainerProvider _Container;
        public string Name { get { return Sequence.Name; } set { Sequence.Name=value; } } //"Sequence 01";
        public Type type { get => this.GetType(); }
        public ObservableCollection<IFunc_Obj> Fun_obj_list { get; set ; }

        public Sequence_Fun(IContainerProvider Container)
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
            ObservableCollection<ISM_Vison.Models.Sequence> Sequences = _serveDB.Sequences;
            ISM_Vison.Models.Sequence kkkk = _serveDB.GetSequence(Name);
            if (kkkk==null)
            {
                _serveDB.db.Add(Sequence);
                _serveDB.SaveChanges();
            }
            else
            {

            }
            return 0;
           // throw new NotImplementedException();
        }
    }
}
