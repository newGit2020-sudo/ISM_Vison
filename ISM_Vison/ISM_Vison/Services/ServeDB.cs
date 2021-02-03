using ISM_Vison.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //WaitProgress.DialogWindowsManager.WriteMsg("Read  Data Base");
            CameraConfig = db.Cameras.Local.ToObservableCollection();
            Sequences = db.Sequences.Local.ToObservableCollection();
            IFunc_ObjTypeStrings = db.IFunc_ObjTypeStrings.Local.ToObservableCollection();
            //  WaitProgress.DialogWindowsManager.WriteMsg("Read  Data Ok");

            // WaitProgress.DialogWindowsManager.WriteMsg("Init AxisConfig...");
            // foreach (var item in db.AxisCongs) { }
            //// WaitProgress.DialogWindowsManager.WriteMsg("Init 输入表...");
            // foreach (var item in db.输入表) { }
            //// WaitProgress.DialogWindowsManager.WriteMsg("Init 输出表...");
            // foreach (var item in db.输出表) { }
            // foreach (var item in db.UserInfoes) { }
            // foreach (var item in db.Errors) { }
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
    }
}
