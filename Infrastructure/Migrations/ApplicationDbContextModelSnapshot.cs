﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Owner")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Owner");

                    b.Property<string>("TimeCreated")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TimeCreated");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Infrastructure.Entities.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("NoOfTickets")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("NoOfTickets");

                    b.Property<string>("Owner")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("OwnerName");

                    b.Property<string>("TimeCreated")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TimeCreated");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Infrastructure.Entities.BugTicket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualResult")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("actual_result");

                    b.Property<string>("Asignee")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("asignee");

                    b.Property<string>("Deadline")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("ExpectedResult")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("expected_result");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<string>("Reporter")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("reporter");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.Property<string>("StepsToReproduce")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("steps_to_reproduce");

                    b.Property<string>("TimeCreated")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TimeCreated");

                    b.HasKey("Id");

                    b.ToTable("BugTickets");
                });

            modelBuilder.Entity("Infrastructure.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Password");

                    b.Property<string>("TimeCreated")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TimeCreated");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
