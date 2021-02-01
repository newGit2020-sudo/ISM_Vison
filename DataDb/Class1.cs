using System;
using System.Collections.Generic;
using System.Text;

namespace DataDb
{
    //public class 系统参数表
    //{
    //    private static 系统参数表 Instance;
    //    public ASK_系统参数Model1 db { get; private set; }

    //    ObservableCollection<AxisCong> AxisCongs;
    //    private 系统参数表()
    //    {
    //        try
    //        {
    //            db = new ASK_系统参数Model1();
    //            WaitProgress.DialogWindowsManager.WriteMsg("Read  Data Base");
    //            var qurey = from b in db.AxisCongs orderby b select b;
    //            WaitProgress.DialogWindowsManager.WriteMsg("Read  Data Ok");

    //            WaitProgress.DialogWindowsManager.WriteMsg("Init AxisConfig...");
    //            foreach (var item in db.AxisCongs) { }
    //            WaitProgress.DialogWindowsManager.WriteMsg("Init 输入表...");
    //            foreach (var item in db.输入表) { }
    //            WaitProgress.DialogWindowsManager.WriteMsg("Init 输出表...");
    //            foreach (var item in db.输出表) { }
    //            //foreach (var item in db.UserInfoes){}
    //            //foreach (var item in db.Errors) { }
    //        }
    //        catch (Exception ex)
    //        {
    //            new Page模板.View.MessageBoxMy2("读取数据库异常:" + ex.Message, false, System.Windows.Media.Brushes.Red, 20).ShowDialog();
    //        }


    //    }
    //    public static 系统参数表 GetInstance()
    //    {
    //        // 如果类的实例不存在则创建，否则直接返回
    //        if (Instance == null)
    //        {
    //            Instance = new 系统参数表();
    //        }
    //        return Instance;
    //    }
    //    public static ObservableCollection<AxisCong> GetAxisCongsInstance()
    //    {
    //        // 如果类的实例不存在则创建，否则直接返回
    //        if (Instance == null)
    //        {
    //            Instance = new 系统参数表();
    //        }
    //        return Instance.db.AxisCongs.Local;
    //    }
    //    public static ObservableCollection<UserInfo> GetUserInfoesInstance()
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = new 系统参数表();
    //        }
    //        return Instance.db.UserInfoes.Local;
    //    }
    //    public static ObservableCollection<输出表> Get输出表Instance()
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = new 系统参数表();
    //        }
    //        return Instance.db.输出表.Local;
    //    }
    //    public static ObservableCollection<输入表> Get输入表Instance()
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = new 系统参数表();
    //        }
    //        return Instance.db.输入表.Local;
    //    }
    //    //public static ObservableCollection<Error> GetErrorsInstance()
    //    //{
    //    //    if (Instance == null)
    //    //    {
    //    //        Instance = new 系统参数表();
    //    //    }
    //    //    //return Instance.db.Errors.Load;
    //    //    return Instance.db.Errors.Local;
    //    ////}
    //    //public ObservableCollection<输入表> Axis_List { get; private set; } 
    //    //public ObservableCollection<输入表> 输出表_List { get; private set; }
    //    //public ObservableCollection<输入表> 输入表_List { get; private set; }
    //    //public ObservableCollection<输入表> 设备报警表_List { get; set; }
    //    //public ObservableCollection<输入表> 生产报警表_List { get; set; }
    //    //public ObservableCollection<输入表> UserInfo_List { get; set; }

    //    public void 保存系统参数表()
    //    {
    //        try
    //        {
    //            foreach (var item in GetAxisCongsInstance())
    //            {
    //                if (item.原点信号电平 > 1 && item.反向限位电平 > 1 && item.正向限位电平 > 1)
    //                {
    //                    new Page模板.View.MessageBoxMy2("信号电平只能设置0或1 ！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
    //                    return;
    //                }
    //                else if (item.导程或周长 == 0)
    //                {
    //                    new Page模板.View.MessageBoxMy2("导程或周长设置不能为0 , 如果度量单位是角度, 导程或周长设置为1 ！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
    //                    return;
    //                }
    //                else if (item.减速比分母 == 0)
    //                {
    //                    new Page模板.View.MessageBoxMy2("减速比分母不能设置为0 ！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
    //                    return;
    //                }
    //                else if (!(item.度量单位.Trim() == 度量单位.毫米.ToString() || item.度量单位.Trim() == 度量单位.角度.ToString()))
    //                {
    //                    new Page模板.View.MessageBoxMy2("度量单位只能选择毫米或角度, 不能输入其他值！！！", false, System.Windows.Media.Brushes.Red).ShowDialog();
    //                    return;
    //                }
    //            }
    //            db.SaveChanges();
    //            OndbChanged();
    //            new Page模板.View.MessageBoxMy2("保存成功！！！", false, System.Windows.Media.Brushes.Green).ShowDialog();
    //        }
    //        catch (Exception ex)
    //        {
    //            new Page模板.View.MessageBoxMy2("写入数据库失败:" + ex.Message, false, System.Windows.Media.Brushes.Red).ShowDialog();
    //        }
    //    }
    //    public AxisCong GetAxisCong(int AxisNo)
    //    {
    //        系统参数表 _系统参数表 = 系统参数表.GetInstance();
    //        var qurey = from b in _系统参数表.db.AxisCongs
    //                    where b.AxisNo == AxisNo
    //                    select b;

    //        if (qurey.Count() != 0)
    //        {
    //            return qurey.First() as AxisCong;
    //        }
    //        else return null;
    //    }

    //    public event Action dbChanged;
    //    void OndbChanged()
    //    {
    //        dbChanged?.Invoke();
    //    }


    //}
}
