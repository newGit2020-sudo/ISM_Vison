using Infrastructure.Interface;
using Infrastructure.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Sequence.ViewModels;
using Sequence.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Sequence.Sequence
{
    public class SequenceFunc_Obj : BindableBase, IFunc_Obj, ISequenceFunc_Obj
    {
        private object _View;
        public object View
        {
            get { return _View; }
            set { _View = value; RaisePropertyChanged(); }
        }

        public Infrastructure.Models.Sequence sequence { get; set; } = new Infrastructure.Models.Sequence();
        private IDBServer _DBserve;
        private IContainerProvider _Container;
        public string Name { get { return sequence.Name; } set { sequence.Name=value;  } } //"Sequence 01";
        public Type type { get => this.GetType(); }
        public ObservableCollection<IFunc_Obj> Children { get; set; } = new ObservableCollection<IFunc_Obj>();
        public IFunc_Obj parent { get; set; }

        public SequenceFunc_Obj(IContainerProvider Container)
        {
            this._Container = Container;
            this._DBserve = _Container.Resolve<IDBServer>();
            this.DeleteCommand = new DelegateCommand(this._Delete);
            this.IsSelectedCommand = new DelegateCommand(this._IsSelected);
            View = new ParameterTable();
            (((View as ParameterTable).DataContext) as ParameterTableViewModel).sequenceFunc_Obj = this;
            Init();

            Children.Add(this);
        }
        public void Init()
        {
            //(((View as ParameterTable).DataContext) as ParameterTableViewModel).sequenceFunc_Obj = this;
            //this.View = View;
        }
        public int Save()
        {
            ObservableCollection<Infrastructure.Models.Sequence> Sequences = _DBserve.Sequences;
            Infrastructure.Models.Sequence _tmep = _DBserve.GetSequence(Name);
            if (_tmep == null)
            {
                _DBserve.Sequences.Add(sequence);
                _DBserve.SaveChanges();
                return 1;
            }
            else
            {
                //定义消息框             
                string messageBoxText = "序列名重复";
                string caption = "警告";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                //显示消息框              
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                //处理消息框信息              
                //switch (result)
                //{
                //    case MessageBoxResult.Yes:
                //        sequence.Field3 = "Field3";
                //        Name = "field3";
                //        _DBserve.Sequences.Add(sequence);
                //        _DBserve.Sequences.Remove(_tmep);
                //        _DBserve.SaveChanges();
                //        break;
                //    case MessageBoxResult.No:
                //        // ...                      
                //        break;
                //}
            }
            return 0;
        }
        public DelegateCommand DeleteCommand { get; private set; }

        public DelegateCommand IsSelectedCommand { get; private set; }
        public void _Delete()
        {
            for (int i = 1; i < Children.Count; i++)
            {
                Children[i]._Delete();
            }
            _DBserve.Sequences.Remove(sequence);
            _DBserve.SaveChanges();
        }

        private void _IsSelected()
        {
        }

        public int Load()
        {
            return 0;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}
