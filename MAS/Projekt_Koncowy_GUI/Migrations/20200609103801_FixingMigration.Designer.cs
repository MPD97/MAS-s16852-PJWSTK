﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Koncowy_GUI.Models;

namespace Projekt_Koncowy_GUI.Migrations
{
    [DbContext(typeof(LocalContext))]
    [Migration("20200609103801_FixingMigration")]
    partial class FixingMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Component", b =>
                {
                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AvailableAmount")
                        .HasColumnType("int");

                    b.HasKey("Identifier");

                    b.ToTable("Components");

                    b.HasData(
                        new
                        {
                            Identifier = "AAA-BBB-123",
                            AvailableAmount = 50
                        },
                        new
                        {
                            Identifier = "356-RRR-QAZ",
                            AvailableAmount = 10
                        },
                        new
                        {
                            Identifier = "MMM-005-550",
                            AvailableAmount = 3
                        });
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.EndpointDevice", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfProduction")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gauge")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestResult")
                        .HasColumnType("int");

                    b.Property<int>("Tested")
                        .HasColumnType("int");

                    b.HasKey("Identifier");

                    b.ToTable("EndpointDevices");

                    b.HasData(
                        new
                        {
                            Identifier = 10,
                            DateOfProduction = new DateTime(2020, 3, 11, 12, 38, 1, 562, DateTimeKind.Local).AddTicks(8929),
                            Gauge = 2,
                            Model = "Speed 500w",
                            TestResult = 0,
                            Tested = 0
                        },
                        new
                        {
                            Identifier = 15,
                            DateOfProduction = new DateTime(2020, 4, 10, 12, 38, 1, 566, DateTimeKind.Local).AddTicks(2214),
                            Gauge = 2,
                            Model = "Ride Fast 200W",
                            TestResult = 0,
                            Tested = 0
                        });
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ComponentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EndpointDeviceId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.HasIndex("ComponentId");

                    b.HasIndex("EndpointDeviceId");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            EquipmentId = 1,
                            Amount = 5,
                            ComponentId = "356-RRR-QAZ",
                            EndpointDeviceId = 10
                        },
                        new
                        {
                            EquipmentId = 2,
                            Amount = 4,
                            ComponentId = "MMM-005-550",
                            EndpointDeviceId = 10
                        },
                        new
                        {
                            EquipmentId = 3,
                            Amount = 1,
                            ComponentId = "MMM-005-550",
                            EndpointDeviceId = 15
                        },
                        new
                        {
                            EquipmentId = 4,
                            Amount = 6,
                            ComponentId = "AAA-BBB-123",
                            EndpointDeviceId = 15
                        });
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Replacement", b =>
                {
                    b.Property<string>("ReplacementId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReplacedById")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReplacementId");

                    b.HasIndex("BaseId");

                    b.HasIndex("ReplacedById");

                    b.ToTable("Replacements");

                    b.HasData(
                        new
                        {
                            ReplacementId = "REPLACEMENT-ABC123",
                            BaseId = "MMM-005-550",
                            ReplacedById = "AAA-BBB-123"
                        });
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Equipment", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.Component", "Component")
                        .WithMany("Equipments")
                        .HasForeignKey("ComponentId");

                    b.HasOne("Projekt_Koncowy_GUI.Models.EndpointDevice", "EndpointDevice")
                        .WithMany("Equipments")
                        .HasForeignKey("EndpointDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Replacement", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.Component", "Base")
                        .WithMany("Bases")
                        .HasForeignKey("BaseId");

                    b.HasOne("Projekt_Koncowy_GUI.Models.Component", "ReplacedBy")
                        .WithMany("ReplacedBys")
                        .HasForeignKey("ReplacedById");
                });
#pragma warning restore 612, 618
        }
    }
}
