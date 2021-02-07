﻿// <auto-generated />
using ISM_Vison.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ISM_Vison.Migrations
{
    [DbContext(typeof(VSDBContext))]
    partial class VSDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Infrastructure.Models.Camera", b =>
                {
                    b.Property<int>("CameraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CailbFile")
                        .HasColumnType("TEXT");

                    b.Property<string>("CameraName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CameraType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExposureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field0")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field3")
                        .HasColumnType("TEXT");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("CameraId");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("Infrastructure.Models.IFunc_ObjTypeString", b =>
                {
                    b.Property<int>("IFunc_ObjTypeStringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SequenceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("parameter")
                        .HasColumnType("TEXT");

                    b.HasKey("IFunc_ObjTypeStringId");

                    b.HasIndex("SequenceId");

                    b.ToTable("IFunc_ObjTypeStrings");
                });

            modelBuilder.Entity("Infrastructure.Models.Sequence", b =>
                {
                    b.Property<int>("SequenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CameraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Field0")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Product")
                        .HasColumnType("TEXT");

                    b.HasKey("SequenceId");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("Infrastructure.Models.IFunc_ObjTypeString", b =>
                {
                    b.HasOne("Infrastructure.Models.Sequence", null)
                        .WithMany("ClassTypeStrings")
                        .HasForeignKey("SequenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.Sequence", b =>
                {
                    b.Navigation("ClassTypeStrings");
                });
#pragma warning restore 612, 618
        }
    }
}
