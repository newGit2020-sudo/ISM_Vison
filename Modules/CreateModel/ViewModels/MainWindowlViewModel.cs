using Infrastructure.Interface;
using Infrastructure.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateModel.ViewModels
{
    public class MainWindowlViewModel : IFunc_Obj
    {
        IContainerProvider _Container;
        IFunc_ObjTypeString func_ObjTypeString { get; set; }
        public ObservableCollection<IFunc_Obj> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFunc_Obj parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type type => throw new NotImplementedException();

        public DelegateCommand DeleteCommand => throw new NotImplementedException();

        public DelegateCommand IsSelectedCommand => throw new NotImplementedException();

        public void Init()
        {
            throw new NotImplementedException();
        }
        public MainWindowlViewModel(IContainerProvider Container)
        {
            this._Container = Container;
        }
        public int Load()
        {
            IDBServer dBServer = _Container.Resolve<IDBServer>();
            func_ObjTypeString.parameter = JsonConvert.SerializeObject(data);
            data = JsonConvert.DeserializeObject<Data>(func_ObjTypeString.parameter);
            return 0;
        }
        Data data = new Data();
        public int Save()
        {
            IDBServer dBServer = _Container.Resolve<IDBServer>();
            func_ObjTypeString.parameter = JsonConvert.SerializeObject(data);
            return dBServer.SaveChanges();
        }
        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}
