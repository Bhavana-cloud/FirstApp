﻿// <auto-generated />
using System;
using LabDal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabDal.Migrations
{
    [DbContext(typeof(LabContext))]
    partial class LabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabDal.onecompany", b =>
                {
                    b.Property<int>("companyid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("companyid"), 1L, 1);

                    b.Property<string>("companyname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("onestudentsId")
                        .HasColumnType("int");

                    b.HasKey("companyid");

                    b.HasIndex("onestudentsId");

                    b.ToTable("onecompanys");
                });

            modelBuilder.Entity("LabDal.Onecourse", b =>
                {
                    b.Property<int>("onecourseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("onecourseid"), 1L, 1);

                    b.Property<string>("TooManyStudentstudentid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("onecourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("onecourseid");

                    b.HasIndex("TooManyStudentstudentid");

                    b.ToTable("onecourses");
                });

            modelBuilder.Entity("LabDal.onestudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("toomanycourseCourseid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("toomanycourseCourseid");

                    b.ToTable("onestudents");
                });

            modelBuilder.Entity("LabDal.toomanycourse", b =>
                {
                    b.Property<int>("Courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Courseid"), 1L, 1);

                    b.Property<string>("Coursename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Courseid");

                    b.ToTable("toomanycourses");
                });

            modelBuilder.Entity("LabDal.TooManyStudent", b =>
                {
                    b.Property<string>("studentid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("studentid");

                    b.ToTable("TooManyStudents");
                });

            modelBuilder.Entity("LabDal.onecompany", b =>
                {
                    b.HasOne("LabDal.onestudent", "onestudents")
                        .WithMany()
                        .HasForeignKey("onestudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("onestudents");
                });

            modelBuilder.Entity("LabDal.Onecourse", b =>
                {
                    b.HasOne("LabDal.TooManyStudent", null)
                        .WithMany("onecourses")
                        .HasForeignKey("TooManyStudentstudentid");
                });

            modelBuilder.Entity("LabDal.onestudent", b =>
                {
                    b.HasOne("LabDal.toomanycourse", null)
                        .WithMany("onestudents")
                        .HasForeignKey("toomanycourseCourseid");
                });

            modelBuilder.Entity("LabDal.toomanycourse", b =>
                {
                    b.Navigation("onestudents");
                });

            modelBuilder.Entity("LabDal.TooManyStudent", b =>
                {
                    b.Navigation("onecourses");
                });
#pragma warning restore 612, 618
        }
    }
}