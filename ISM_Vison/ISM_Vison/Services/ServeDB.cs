using ISM_Vison.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataDb
{
    public  class ServeDB
    {
        private static ServeDB Instance;
        private VSDBContext db;
        public ObservableCollection<ISM_Vison.Models.Sequence> Sequences { get; set; }
        public ObservableCollection<ISM_Vison.Models.Camera> CameraConfig{ get; set; }
        public ObservableCollection<ISM_Vison.Models.IFunc_ObjTypeString> IFunc_ObjTypeStrings { get; set; }
        private ServeDB()
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
       public void SaveChanges()
        {
            db.SaveChanges();
        }
       public static ServeDB GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (Instance == null)
            {
                Instance = new ServeDB();
            }
            return Instance;
        }
       public ISM_Vison.Models.Sequence GetSequence( String Name)
        {
            var qurey = from b in db.Sequences
                        where b.Name == Name
                        select b ;
            if (qurey.Count() == 1)
            {
                return qurey.First() as ISM_Vison.Models.Sequence;
            }
            else return null;
        }
        public ISM_Vison.Models.Camera GetCamera(String Name)
        {
            var qurey = from b in db.Cameras
                        where b.CameraName == Name
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as ISM_Vison.Models.Camera;
            }
            else return null;
        }
        public ISM_Vison.Models.IFunc_ObjTypeString GetIFunc_ObjTypeStrings(int ID)
        {
            var qurey = from b in db.IFunc_ObjTypeStrings
                        where b.IFunc_ObjTypeStringId == ID 
                        select b;
            if (qurey.Count() == 1)
            {
                return qurey.First() as ISM_Vison.Models.IFunc_ObjTypeString;
            }
            else return null;
        }
    }
}
