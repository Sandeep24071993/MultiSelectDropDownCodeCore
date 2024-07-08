﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiSelectDropDownCodeCore.Data;

#nullable disable

namespace MultiSelectDropDownCodeCore.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20240617064334_multies")]
    partial class multies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MultiSelectDropDownCodeCore.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("MultiSelectDropDownCodeCore.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("MultiSelectDropDownCodeCore.Models.EmployeeDepartment", b =>
                {
                    b.Property<int>("EmployeeDepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeDepartmentId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeDepartmentId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeDepartment");
                });

            modelBuilder.Entity("MultiSelectDropDownCodeCore.Models.EmployeeDepartment", b =>
                {
                    b.HasOne("MultiSelectDropDownCodeCore.Models.Department", "department")
                        .WithMany("Objempdpt")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiSelectDropDownCodeCore.Models.Employee", "employee")
                        .WithMany("Objempdpt")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MultiSelectDropDownCodeCore.Models.Department", b =>
                {
                    b.Navigation("Objempdpt");
                });

            modelBuilder.Entity("MultiSelectDropDownCodeCore.Models.Employee", b =>
                {
                    b.Navigation("Objempdpt");
                });
#pragma warning restore 612, 618
        }
    }
}
