﻿// <auto-generated />
using System;
using Eventmi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eventmi.Infrastructure.Migrations
{
    [DbContext(typeof(EventmiDbContext))]
    [Migration("20240118113123_TownsSeeded")]
    partial class TownsSeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eventmi.Infrastructure.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identifier of address");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Sreet of the place");

                    b.Property<int>("TownId")
                        .HasColumnType("int")
                        .HasComment("Identifier of town");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");

                    b.HasComment("Address of the event");
                });

            modelBuilder.Entity("Eventmi.Infrastructure.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identifier of the event");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date deleted");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2")
                        .HasComment("End of the event");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Status of the event");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the event");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int")
                        .HasComment("Identifier of the place");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2")
                        .HasComment("Start of the event");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Events");

                    b.HasComment("Event");
                });

            modelBuilder.Entity("Eventmi.Infrastructure.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identifier of the town");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasComment("Name of the town");

                    b.HasKey("Id");

                    b.ToTable("Towns");

                    b.HasComment("Town of the address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Varna"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bourgas"
                        });
                });

            modelBuilder.Entity("Eventmi.Infrastructure.Data.Models.Address", b =>
                {
                    b.HasOne("Eventmi.Infrastructure.Data.Models.Town", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Eventmi.Infrastructure.Data.Models.Event", b =>
                {
                    b.HasOne("Eventmi.Infrastructure.Data.Models.Address", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Eventmi.Infrastructure.Data.Models.Town", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
