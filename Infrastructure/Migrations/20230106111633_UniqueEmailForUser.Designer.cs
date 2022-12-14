// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230106111633_UniqueEmailForUser")]
    partial class UniqueEmailForUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.ActivityEntity", b =>
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

            modelBuilder.Entity("Infrastructure.Entities.BoardEntity", b =>
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

            modelBuilder.Entity("Infrastructure.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Asignee")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("asignee");

                    b.Property<Guid>("BoardForeignKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Deadline")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<string>("Reporter")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("reporter");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.Property<string>("TimeCreated")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TimeCreated");

                    b.HasKey("Id");

                    b.HasIndex("BoardForeignKey");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Infrastructure.Entities.UserEntity", b =>
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

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Entities.TicketEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.BoardEntity", "Board")
                        .WithMany("Tickets")
                        .HasForeignKey("BoardForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Infrastructure.Entities.BoardEntity", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
