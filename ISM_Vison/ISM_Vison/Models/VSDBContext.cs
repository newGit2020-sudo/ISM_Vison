using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ISM_Vison.Models
{
    public class VSDBContext : DbContext
    {
        public DbSet<Infrastructure.Models.Camera> Cameras { get; set; }
        public DbSet<Infrastructure.Models.Sequence> Sequences { get; set; }
        public DbSet<Infrastructure.Models.IFunc_ObjTypeString> IFunc_ObjTypeStrings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=VSDBContext.db");
    }
    //public class Camera : BindableBase
    //{
    //    public int CameraId { get; set; }
    //    private string _SerialNumber;
    //    public string SerialNumber { get { return _SerialNumber; } set { SetProperty(ref _SerialNumber, value); } }
    //    private string _ClassType;
    //    public string ClassType { get { return _ClassType; } set { SetProperty(ref _ClassType, value); } }
    //    private string _CameraName;
    //    public string CameraName { get { return _CameraName; } set { SetProperty(ref _CameraName, value); } }

    //    private string _ExposureTime;
    //    public string ExposureTime { get { return _ExposureTime; } set { SetProperty(ref _ExposureTime, value); } }
    //    private string _CailbFile;
    //    public string CailbFile { get { return _CailbFile; } set { SetProperty(ref _CailbFile, value); } }
    //    private string _CameraType;
    //    public string CameraType { get { return _CameraType; } set { SetProperty(ref _CameraType, value); } }
    //    private string _Field0;
    //    public string Field0 { get { return _Field0; } set { SetProperty(ref _Field0, value); } }
    //    private string _Field1;
    //    public string Field1 { get { return _Field1; } set { SetProperty(ref _Field1, value); } }
    //    private string _Field2;
    //    public string Field2 { get { return _Field2; } set { SetProperty(ref _Field2, value); } }
    //    private string _Field3;
    //    public string Field3 { get { return _Field3; } set { SetProperty(ref _Field3, value); } }
    //}
    //public class Sequence : BindableBase
    //{
    //    public int SequenceId { get; set; }
    //    private string _Product;
    //    public string Product { get { return _Product; } set { SetProperty(ref _Product, value); } }
    //    private string _Name;
    //    public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
    //    private int _CameraId;
    //    public int CameraId { get { return _CameraId; } set { SetProperty(ref _CameraId, value); } }
    //    private string _Field0;
    //    public string Field0 { get { return _Field0; } set { SetProperty(ref _Field0, value); } }
    //    private string _Field1;
    //    public string Field1 { get { return _Field1; } set { SetProperty(ref _Field1, value); } }
    //    private string _Field2;
    //    public string Field2 { get { return _Field2; } set { SetProperty(ref _Field2, value); } }
    //    private string _Field3;
    //    public string Field3 { get { return _Field3; } set { SetProperty(ref _Field3, value); } }
    //    public List<IFunc_ObjTypeString> ClassTypeStrings { get; set; } 
    //}
    //public class IFunc_ObjTypeString : BindableBase
    //{
    //    public int IFunc_ObjTypeStringId { get; set; }
    //    private string _TypeName;
    //    public string TypeName{ get { return _TypeName; }set { SetProperty(ref _TypeName, value); }}
    //    private string _parameter;
    //    public string parameter { get { return _parameter; } set { SetProperty(ref _parameter, value); } }
    //    private int _SequenceId;
    //    public int SequenceId { get { return _SequenceId; } set { SetProperty(ref _SequenceId, value); } }

    //}

}

