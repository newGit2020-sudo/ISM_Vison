using ISM_Vison.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Infrastructure.Models;
namespace ISM_Vison.Services
{
    public  class DBServer: IDBServer
    {
        private static DBServer Instance;
        public VSDBContext db;
        public ObservableCollection<Infrastructure.Models.Sequence> Sequences { get; set; }
        public ObservableCollection<Infrastructure.Models.Camera> CameraConfig{ get; set; }
        public ObservableCollection<IFunc_ObjTypeString> IFunc_ObjTypeStrings { get; set; }
   
        private DBServer()
        {
            db = new VSDBContext();
           // var qurey = from b in db.Cameras orderby b select b;
            foreach (var item in db.Cameras) { }
            CameraConfig = db.Cameras.Local.ToObservableCollection();
            //var qurey = from b in db.Cameras orderby b select b;
            foreach (var item in db.Sequences) { }
            Sequences = db.Sequences.Local.ToObservableCollection();
            foreach (var item in db.IFunc_ObjTypeStrings) { }
            IFunc_ObjTypeStrings = db.IFunc_ObjTypeStrings.Local.ToObservableCollection();
        }
       public int SaveChanges()
        {
            return db.SaveChanges();
        }
       public static DBServer GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (Instance == null)
            {
                Instance = new DBServer();
            }
            return Instance;
        }
       public int SetSequence(Infrastructure.Models.Sequence sequence)
        {
            var qurey = from b in db.Sequences
                        where b.SequenceId == sequence.SequenceId
                        select b ;
            if (qurey.Count() == 1)
            {
              return  SaveChanges();
            }
            return 0;
        }

        public Infrastructure.Models.Sequence GetSequence(String Name)
        {
            var qurey = from b in db.Sequences
                        where b.Name == Name
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as Infrastructure.Models.Sequence;
            }
            else return null;
        }
        public Infrastructure.Models.Camera GetCamera(String Name)
        {
            var qurey = from b in db.Cameras
                        where b.Name == Name
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as Infrastructure.Models.Camera;
            }
            else return null;
        }
        public IFunc_ObjTypeString GetIFunc_ObjTypeStrings(int ID)
        {
            var qurey = from b in db.IFunc_ObjTypeStrings
                        where b.IFunc_ObjTypeStringId == ID 
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as Infrastructure.Models.IFunc_ObjTypeString;
            }
            else return null;
        }

        //CRUD(Create, Read, Update and Delete)
    }
}
