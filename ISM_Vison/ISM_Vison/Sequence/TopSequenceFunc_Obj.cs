using Infrastructure.Interface;
using ISM_Vison.Services;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace ISM_Vison.Sequence
{
    public class TopSequenceFunc_Obj : BindableBase
    {
       public string Product { get; set; }
      //  public Infrastructure.Models.Sequence sequence { get; set; } = new Infrastructure.Models.Sequence();
        private DBServer _serveDB;
        private IContainerProvider _Container;
        public ObservableCollection<IFunc_Obj> Children { get; set; } = new ObservableCollection<IFunc_Obj>();

        public TopSequenceFunc_Obj(IContainerProvider Container) 
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
            _serveDB = _Container.Resolve<DBServer>();
            foreach (var item in _serveDB.Sequences)
            {
                SequenceFunc_Obj _sequenceFunc_Obj = _Container.Resolve<SequenceFunc_Obj>();
                _sequenceFunc_Obj.sequence = item;
                _sequenceFunc_Obj.Load();
                Children.Add(_sequenceFunc_Obj);  
            }
            return 0;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            //  Infrastructure.Models.Sequence temp = _serveDB.GetSequence(Name);
            foreach (var item in Children)
            {
                item.Save();
            }
           return 0;
        }
        
    }
}
