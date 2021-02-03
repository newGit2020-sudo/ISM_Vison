using ISM_Vison.Models;
using ISM_Vison.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataDb
{
    public class ServeDB
    {
        public VSDBContext db { get; private set; }
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
       

        //public LocalView<Camera> GetCameras()
        //{
        //    return db.Cameras.Local;
        //}

        //public static ObservableCollection<输出表> Get输出表Instance()
        //{

        //    return db.输出表.Local;
        //}

        //public void 保存系统参数表()
        //{
        //    try
        //    {
        //        foreach (var item in GetAxisCongsInstance())
        //        {
        //            if (item.原点信号电平 > 1 && item.反向限位电平 > 1 && item.正向限位电平 > 1)
        //            {
        //                new Page模板.View.MessageBoxMy2("信号电平只能设置0或1 ！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
        //                return;
        //            }
        //            else if (item.导程或周长 == 0)
        //            {
        //                new Page模板.View.MessageBoxMy2("导程或周长设置不能为0 , 如果度量单位是角度, 导程或周长设置为1 ！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
        //                return;
        //            }
        //            else if (item.减速比分母 == 0)
        //            {
        //                new Page模板.View.MessageBoxMy2("减速比分母不能设置为0 ！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
        //                return;
        //            }
        //            else if (!(item.度量单位.Trim() == 度量单位.毫米.ToString() || item.度量单位.Trim() == 度量单位.角度.ToString()))
        //            {
        //                new Page模板.View.MessageBoxMy2("度量单位只能选择毫米或角度, 不能输入其他值！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
        //                return;
        //            }
        //        }
        //        db.SaveChanges();
        //        OndbChanged();
        //        new Page模板.View.MessageBoxMy2("保存成功！！！", false, System.Windows.Media.Brushes.Green).ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        new Page模板.View.MessageBoxMy2("写入数据库失败:" + ex.Message, false, System.Windows.Media.Brushes.Red).ShowDialog();
        //    }
        //}
        //public AxisCong GetAxisCong(int AxisNo)
        //{
        //    系统参数表 _系统参数表 = 系统参数表.GetInstance();
        //    var qurey = from b in _系统参数表.db.AxisCongs
        //                where b.AxisNo == AxisNo
        //                select b;

        //    if (qurey.Count() != 0)
        //    {
        //        return qurey.First() as AxisCong;
        //    }
        //    else return null;
        //}

        //public event Action dbChanged;
        //void OndbChanged()
        //{
        //    dbChanged?.Invoke();
        //}
    }
}
