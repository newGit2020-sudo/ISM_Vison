using Infrastructure.Interface;
using ISM_Vison.Services;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace ISM_Vison.Sequence
{
    public class SequenceFunc_Obj : BindableBase, IFunc_Obj, ISequenceFunc_Obj
    {
        public Infrastructure.Models.Sequence sequence { get; set; } = new Infrastructure.Models.Sequence();
        private DBServer _serveDB;
        private IContainerProvider _Container;
        public string Name { get { return sequence.Name; } set { sequence.Name=value;  } } //"Sequence 01";
        public Type type { get => this.GetType(); }
        public ObservableCollection<IFunc_Obj> Children { get; set; } = new ObservableCollection<IFunc_Obj>();
        public IFunc_Obj parent { get; set; }

        public SequenceFunc_Obj(IContainerProvider Container)
        {
            this._Container = Container;
            this._serveDB = _Container.Resolve<DBServer>();
            this.DeleteCommand = new DelegateCommand(this._Delete);
            this.IsSelectedCommand = new DelegateCommand(this._IsSelected);
            Children.Add(this);
        }
        public void Init()
        {
            this.GetType();
        }
        public int Load()
        {
            //if (Children!=null)
            //{
            //    foreach (var item in Children)
            //    {
            //    }
            //}
            return 0;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            ObservableCollection<Infrastructure.Models.Sequence> Sequences = _serveDB.Sequences;
            Infrastructure.Models.Sequence tmep = _serveDB.GetSequence(Name);
            if (tmep==null)
            {
                _serveDB.db.Add(sequence);
                _serveDB.SaveChanges();
            }
            else
            {

            }
            return 0;
        }
        public DelegateCommand DeleteCommand { get; private set; }

       public DelegateCommand IsSelectedCommand { get; private set; }
        private void _Delete()
        {
            if (Children.Count==0)
            {
                TopSequenceFunc_Obj topSequenceFunc_Obj= _Container.Resolve<TopSequenceFunc_Obj>();
                
            }
        }
        private void _IsSelected()
        {

        }
      
    }
}
