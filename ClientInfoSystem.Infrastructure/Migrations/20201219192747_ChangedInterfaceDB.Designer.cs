﻿// <auto-generated />
using System;
using ClientInfoSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientInfoSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ClientInfoSysDbContext))]
    [Migration("20201219192747_ChangedInterfaceDB")]
    partial class ChangedInterfaceDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ClientInfoSystem.Core.Entities.Clients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClientInfoSystem.Core.Entities.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Designation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ClientInfoSystem.Core.Entities.Interactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IntDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IntType")
                        .HasColumnType("char(1)");

                    b.Property<string>("Remarks")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmpId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("ClientInfoSystem.Core.Entities.Interactions", b =>
                {
                    b.HasOne("ClientInfoSystem.Core.Entities.Clients", "Clients")
                        .WithMany("Interactions")
                        .HasForeignKey("ClientId");

                    b.HasOne("ClientInfoSystem.Core.Entities.Employees", "Employees")
                        .WithMany("Interactions")
                        .HasForeignKey("EmpId");

                    b.Navigation("Clients");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ClientInfoSystem.Core.Entities.Clients", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("ClientInfoSystem.Core.Entities.Employees", b =>
                {
                    b.Navigation("Interactions");
                });
#pragma warning restore 612, 618
        }
    }
}
