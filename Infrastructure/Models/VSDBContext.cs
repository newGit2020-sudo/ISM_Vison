using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Infrastructure.Models
{
    public interface IDBServer
    {
        public ObservableCollection<Sequence> Sequences { get; set; }
        public ObservableCollection<Camera> CameraConfig { get; set; }
        public ObservableCollection<IFunc_ObjTypeString> IFunc_ObjTypeStrings { get; set; }
        public int SaveChanges();
        public Sequence GetSequence(String Name);
        public Sequence GetSequence(int ID);
        public Camera GetCamera(int ID);
        public Camera GetCamera(String Name);

        public IFunc_ObjTypeString GetIFunc_ObjTypeStrings(int ID);
        public IFunc_ObjTypeString GetIFunc_ObjTypeStrings(String Name);
        public int GetMaxSequenceID();
        public int GetMaxFunc_ObjTypeStringID();
    }

    public class Camera : BindableBase
    {
        public int CameraId { get; set; }
        private string _SerialNumber;
        public string SerialNumber { get { return _SerialNumber; } set { SetProperty(ref _SerialNumber, value); } }

        private string _Name;
        public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }

        private string _ExposureTime;
        public string ExposureTime { get { return _ExposureTime; } set { SetProperty(ref _ExposureTime, value); } }
        private string _CailbFile;
        public string CailbFile { get { return _CailbFile; } set { SetProperty(ref _CailbFile, value); } }
        private string _CameraType;
        public string CameraType { get { return _CameraType; } set { SetProperty(ref _CameraType, value); } }
        private int _index;
        public int Index { get { return _index; } set { SetProperty(ref _index, value); } }
        private string _Field0;
        public string Field0 { get { return _Field0; } set { SetProperty(ref _Field0, value); } }
        private string _Field1;
        public string Field1 { get { return _Field1; } set { SetProperty(ref _Field1, value); } }
        private string _Field2;
        public string Field2 { get { return _Field2; } set { SetProperty(ref _Field2, value); } }
        private string _Field3;
        public string Field3 { get { return _Field3; } set { SetProperty(ref _Field3, value); } }
    }
    public class Sequence : BindableBase
    {
        public int SequenceId { get; set; }
        private string _Product;
        public string Product { get { return _Product; } set { SetProperty(ref _Product, value); } }
        private string _Name = "Sequence";
        public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
        private int _CameraId;
        public int CameraId { get { return _CameraId; } set { SetProperty(ref _CameraId, value); } }
        private string _SequenceType;
        public string SequenceType { get { return _SequenceType; } set { SetProperty(ref _SequenceType, value); } }
        private string _ExposureTime;
        public string ExposureTime { get { return _ExposureTime; } set { SetProperty(ref _ExposureTime, value); } }
        private string _Field1;
        public string Field1 { get { return _Field1; } set { SetProperty(ref _Field1, value); } }
        private string _Field2;
        public string Field2 { get { return _Field2; } set { SetProperty(ref _Field2, value); } }
        private string _Field3;
        public string Field3 { get { return _Field3; } set { SetProperty(ref _Field3, value); } }
        public List<IFunc_ObjTypeString> ClassTypeStrings { get; set; }
    }
    public class IFunc_ObjTypeString : BindableBase
    {
        public int IFunc_ObjTypeStringId { get; set; }
        private string _Name;
        public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
        private string _Func_ObjType;
        public string Func_ObjType { get { return _Func_ObjType; } set { SetProperty(ref _Func_ObjType, value); } }
        private string _parameter;
        public string parameter { get { return _parameter; } set { SetProperty(ref _parameter, value); } }
        public int SequenceId { get; set; }

    }
    //public class Camera :BindableBase 
    //{
    //    public int CameraId { get; set ; }
    //    public int SerialNumber { get; set; }
    //    public string ClassType { get; set; }
    //    public string CameraName { get; set; }
    //    public string ExposureTime { get; set; }
    //    public string CailbFile { get; set; }
    //    public string CameraType { get; set; }
    //    public string Field0 { get; set; }
    //    public string Field1 { get; set; }
    //    public string Field2 { get; set; }
    //    public string Field3 { get; set; }
    //}
    //public class Sequence
    //{
    //    public int SequenceId { get; set; }
    //    public string Product { get; set; }
    //    public string Name { get; set; } = "Sequence01";
    //    public int CameraId { get; set; }
    //    public string Field0 { get; set; }
    //    public string Field1 { get; set; }
    //    public string Field2 { get; set; }
    //    public string Field3 { get; set; }
    //    public List<IFunc_ObjTypeString> ClassTypeStrings { get; set; }
    //}
    //public class IFunc_ObjTypeString
    //{
    //    public int IFunc_ObjTypeStringId { get; set; }
    //    public string TypeName { get; set; }
    //    public string parameter { get; set; }
    //    public int SequenceId { get; set; }

    //}
}
