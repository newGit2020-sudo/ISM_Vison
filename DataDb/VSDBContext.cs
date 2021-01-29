﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataDb
{
    public class VSDBContext : DbContext
    {
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Sequence> Sequences { get; set; }
        public DbSet<ClassTypeString> ClassTypeStrings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=VSDBContext.db");
    }
    public class Camera
    {
        public int CameraId { get; set; }
        public int SerialNumber{ get; set; }
        public string ClassType { get; set; }
        public string Name { get; set; }
        public string ExposureTime { get; set; }
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
        public string Name { get; set; }
        public string CameraName { get; set; }
        public string CameraSerial { get; set; } 
        public string CailbFile { get; set; } 
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public List<ClassTypeString> ClassTypeStrings { get; } = new List<ClassTypeString>();
    }
    public class ClassTypeString
    {
        public int ClassTypeStringId { get; set; }
        public string TypeString { get; set; } 
      
    }
    public class Geometric
    {
        public int GeometricId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Camera Blog { get; set; }
        public byte[] Image { get; set; }
    }
}
