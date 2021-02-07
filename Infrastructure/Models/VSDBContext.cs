
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

        public Camera GetCamera(String Name);

        public IFunc_ObjTypeString GetIFunc_ObjTypeStrings(int ID);
    }
    public class Camera
    {
        public int CameraId { get; set; }
        public int SerialNumber { get; set; }
        public string ClassType { get; set; }
        public string CameraName { get; set; }
        public string ExposureTime { get; set; }
        public string CailbFile { get; set; }
        public string CameraType { get; set; }
        public string Field0 { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }
    public class Sequence
    {
        public int SequenceId { get; set; }
        public string Product { get; set; }
        public string Name { get; set; } = "Sequence01";
        public int CameraId { get; set; }
        public string Field0 { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public List<IFunc_ObjTypeString> ClassTypeStrings { get; set; }
    }
    public class IFunc_ObjTypeString
    {
        public int IFunc_ObjTypeStringId { get; set; }
        public string TypeName { get; set; }
        public string parameter { get; set; }
        public int SequenceId { get; set; }

    }
}

