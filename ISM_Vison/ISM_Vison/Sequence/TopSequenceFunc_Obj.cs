using Infrastructure.Interface;
using ISM_Vison.Services;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace ISM_Vison.Sequence
{
    public class TopSequenceFunc_Obj : BindableBase, IFunc_Obj
    {
       public string Product { get; set; }
      //  public Infrastructure.Models.Sequence sequence { get; set; } = new Infrastructure.Models.Sequence();
        private DBServer _serveDB;
        private IContainerProvider _Container;
        public ObservableCollection<IFunc_Obj> Children { get; set; } = new ObservableCollection<IFunc_Obj>();
        //private int _index;
        //public int Index
        //{
        //    get { return _index; }
        //    set { _index = value; RaisePropertyChanged(); }
        //}
        public int Index { get; set; }
        public TopSequenceFunc_Obj(IContainerProvider Container) 
        {
            this._Container = Container;
            this._serveDB = _Container.Resolve<DBServer>();
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
            _serveDB = _Container.Resolve<DBServer>();
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

        private void _Delete()
        {   
            //todo: 这里要调用子元素的删除
            Children.RemoveAt(Index);
        }
        private void _IsSelected()
        {
        }

    }
}
