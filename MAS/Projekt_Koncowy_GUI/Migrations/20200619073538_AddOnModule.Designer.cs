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
    [Migration("20200619073538_AddOnModule")]
    partial class AddOnModule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.AddOnModule", b =>
                {
                    b.Property<int>("AddOnModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AddOnModuleId");

                    b.ToTable("AddOnModules");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.BluetoothModule", b =>
                {
                    b.Property<int>("BluetoothModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddOnModuleId")
                        .HasColumnType("int");

                    b.Property<string>("TransmisionVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BluetoothModuleId");

                    b.HasIndex("AddOnModuleId");

                    b.ToTable("BluetoothModules");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.CommunicationModule", b =>
                {
                    b.Property<string>("IMEI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SerialNumber")
                        .HasColumnType("bigint");

                    b.HasKey("IMEI");

                    b.HasIndex("IMEI")
                        .IsUnique();

                    b.ToTable("CommunicationModules");

                    b.HasData(
                        new
                        {
                            IMEI = "432234543231284",
                            Frequency = 5500,
                            Model = "X425",
                            SerialNumber = 123536190258L
                        },
                        new
                        {
                            IMEI = "999683672983858",
                            Frequency = 5500,
                            Model = "WW849",
                            SerialNumber = 643643634634L
                        });
                });

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

                    b.Property<string>("CommunicationModuleImei")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("CommunicationModuleImei");

                    b.ToTable("EndpointDevices");

                    b.HasData(
                        new
                        {
                            Identifier = 10,
                            CommunicationModuleImei = "432234543231284",
                            DateOfProduction = new DateTime(2020, 3, 21, 9, 35, 38, 474, DateTimeKind.Local).AddTicks(7079),
                            Gauge = 2,
                            Model = "Speed 500w",
                            TestResult = 0,
                            Tested = 0
                        },
                        new
                        {
                            Identifier = 15,
                            CommunicationModuleImei = "999683672983858",
                            DateOfProduction = new DateTime(2020, 4, 20, 9, 35, 38, 477, DateTimeKind.Local).AddTicks(358),
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.GPSModule", b =>
                {
                    b.Property<int>("GPSModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddOnModuleId")
                        .HasColumnType("int");

                    b.HasKey("GPSModuleId");

                    b.HasIndex("AddOnModuleId");

                    b.ToTable("GPSModules");
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.SupportedSattelites", b =>
                {
                    b.Property<int>("SupportedSattelitesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GPSModuleId")
                        .HasColumnType("int");

                    b.HasKey("SupportedSattelitesId");

                    b.HasIndex("GPSModuleId");

                    b.ToTable("SupportedSattelites");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.BluetoothModule", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.AddOnModule", "AddOnModule")
                        .WithMany("BluetoothModules")
                        .HasForeignKey("AddOnModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.EndpointDevice", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.CommunicationModule", "CommunicationModule")
                        .WithMany("EndpointDevices")
                        .HasForeignKey("CommunicationModuleImei")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.GPSModule", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.AddOnModule", "AddOnModule")
                        .WithMany("GPSModules")
                        .HasForeignKey("AddOnModuleId")
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.SupportedSattelites", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.GPSModule", "GPSModules")
                        .WithMany("SupportedSatellites")
                        .HasForeignKey("GPSModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
