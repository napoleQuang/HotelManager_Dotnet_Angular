﻿// <auto-generated />
using System;
using BackEnd.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240330104212_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEnd.Models.Domains.Bill", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IDGuest")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("IDGuest");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Guest", b =>
                {
                    b.Property<string>("GuestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestID");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.GuestService", b =>
                {
                    b.Property<string>("ServiceID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GuestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ServiceID", "GuestID");

                    b.HasIndex("GuestID");

                    b.ToTable("GuestService");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Reservation", b =>
                {
                    b.Property<string>("ReservationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ConfirmationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationID");

                    b.HasIndex("GuestID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.ReservationRoom", b =>
                {
                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReservationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("RoomID", "ReservationID");

                    b.HasIndex("ReservationID");

                    b.ToTable("ReservationRooms");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Room", b =>
                {
                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsAvaiable")
                        .HasColumnType("bit");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomTypeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoomID");

                    b.HasIndex("RoomTypeID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.RoomType", b =>
                {
                    b.Property<string>("RoomTypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomTypeID");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Service", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("DateJoined")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Bill", b =>
                {
                    b.HasOne("BackEnd.Models.Domains.Guest", "Guest")
                        .WithMany("Bills")
                        .HasForeignKey("IDGuest")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.GuestService", b =>
                {
                    b.HasOne("BackEnd.Models.Domains.Guest", "Guest")
                        .WithMany("GuestService")
                        .HasForeignKey("GuestID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Domains.Service", "Service")
                        .WithMany("GuestService")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Reservation", b =>
                {
                    b.HasOne("BackEnd.Models.Domains.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.ReservationRoom", b =>
                {
                    b.HasOne("BackEnd.Models.Domains.Reservation", "Reservation")
                        .WithMany("ReservationRooms")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Domains.Room", "Room")
                        .WithMany("ReservationRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Room", b =>
                {
                    b.HasOne("BackEnd.Models.Domains.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Guest", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("GuestService");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Reservation", b =>
                {
                    b.Navigation("ReservationRooms");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Room", b =>
                {
                    b.Navigation("ReservationRooms");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BackEnd.Models.Domains.Service", b =>
                {
                    b.Navigation("GuestService");
                });
#pragma warning restore 612, 618
        }
    }
}
