using ISM_Vision.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Infrastructure.Models;
namespace ISM_Vision.Services
{
    public class DBServer : IDBServer
    {
        //private static DBServer Instance;
        public VSDBContext db;
        public ObservableCollection<Infrastructure.Models.Sequence> Sequences { get; set; }
        public ObservableCollection<Infrastructure.Models.Camera> CameraConfig { get; set; }
        public ObservableCollection<IFunc_ObjTypeString> IFunc_ObjTypeStrings { get; set; }

        public DBServer()
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
        //public static DBServer GetInstance()
        // {
        //     // 如果类的实例不存在则创建，否则直接返回
        //     if (Instance == null)
        //     {
        //         Instance = new DBServer();
        //     }
        //     return Instance;
        // }


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

        public IFunc_ObjTypeString GetIFunc_ObjTypeStrings(string Name)
        {
            var qurey = from b in db.IFunc_ObjTypeStrings
                        where b.Name == Name
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as Infrastructure.Models.IFunc_ObjTypeString;
            }
            else return null;
        }
        public int GetMaxCameraID()
        {
            if (Sequences != null)
            {
                return CameraConfig.Max(x => x.CameraId);
            }
            else
            {
                return 1;
            }

        }

        public int GetMaxSequenceID()
        {
            if (Sequences != null)
            {
                return Sequences.Max(x => x.SequenceId);
            }
            else
            {
                return 1;
            }
        }

        public int GetMaxFunc_ObjTypeStringID()
        {
            if (Sequences != null)
            {
                return IFunc_ObjTypeStrings.Max(x => x.IFunc_ObjTypeStringId);
            }
            else
            {
                return 1;
            }

        }

        public Infrastructure.Models.Sequence GetSequence(int ID)
        {
            var qurey = from b in db.Sequences
                        where b.SequenceId == ID
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as Infrastructure.Models.Sequence;
            }
            else return null;
        }

        public Camera GetCamera(int ID)
        {
            var qurey = from b in db.Cameras
                        where b.CameraId == ID
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as Infrastructure.Models.Camera;
            }
            else return null;
        }
        //CRUD(Create, Read, Update and Delete)
    }
}
