using Infrastructure.Interface;
using Infrastructure.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace Sequence.Sequence
{
    public class TopSequenceFunc_Obj : BindableBase, IFunc_Obj
    {
       public string Product { get; set; }
        private IDBServer _serveDB;
        private IContainerProvider _Container;
        public ObservableCollection<IFunc_Obj> Children { get; set; } = new ObservableCollection<IFunc_Obj>();
        public int Index { get; set; }
        public TopSequenceFunc_Obj(IContainerProvider Container) 
        {
            this._Container = Container;
            this._serveDB = _Container.Resolve<IDBServer>();
            Index = 0;
            this.DeleteCommand = new DelegateCommand(this._Delete);
            this.IsSelectedCommand = new DelegateCommand(this._IsSelected);
        }
        public void Init()
        {
            this.GetType();
        }
        public int Load()
        {
            _serveDB = _Container.Resolve<IDBServer>();
            foreach (var item in _serveDB.Sequences)
            {
                SequenceFunc_Obj _sequenceFunc_Obj = _Container.Resolve<SequenceFunc_Obj>();
                _sequenceFunc_Obj.sequence = item;
                _sequenceFunc_Obj.Load();
                _sequenceFunc_Obj.parent = this;
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
            foreach (var item in Children)
            {
                item.Save();
            }
           return 0;
        }

        public DelegateCommand DeleteCommand { get; private set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFunc_Obj parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type type => throw new NotImplementedException();

        public DelegateCommand IsSelectedCommand { get; set; }

        public void _Delete()
        {
            Children[Index]._Delete();
            Children.RemoveAt(Index);
        }
        private void _IsSelected()
        {
        }

    }
}
