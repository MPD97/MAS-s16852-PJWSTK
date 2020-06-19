﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Koncowy_GUI.Models;

namespace Projekt_Koncowy_GUI.Migrations
{
    [DbContext(typeof(LocalContext))]
    partial class LocalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("EndpointDeviceId")
                        .HasColumnType("int");

                    b.HasKey("AddOnModuleId");

                    b.HasIndex("EndpointDeviceId");

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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LicenseId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("LicenseId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.CommunicationModule", b =>
                {
                    b.Property<string>("IMEI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EndpointDeviceId")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SerialNumber")
                        .HasColumnType("bigint");

                    b.HasKey("IMEI");

                    b.HasIndex("EndpointDeviceId");

                    b.HasIndex("IMEI")
                        .IsUnique();

                    b.ToTable("CommunicationModules");

                    b.HasData(
                        new
                        {
                            IMEI = "432234543231284",
                            EndpointDeviceId = 15,
                            Frequency = 5500,
                            Model = "X425",
                            SerialNumber = 123536190258L
                        },
                        new
                        {
                            IMEI = "999683672983858",
                            EndpointDeviceId = 10,
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.EmployeeServiceman", b =>
                {
                    b.Property<int>("EmployeeServicemanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeServicemanId");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.ToTable("EmployeeServicemans");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.EmployeeStorekeeper", b =>
                {
                    b.Property<int>("EmployeeStorekeeperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("ForkliftLicense")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeStorekeeperId");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.ToTable("EmployeeStorekeepers");
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
                            DateOfProduction = new DateTime(2020, 3, 21, 10, 52, 28, 147, DateTimeKind.Local).AddTicks(9405),
                            Gauge = 2,
                            Model = "Speed 500w",
                            TestResult = 0,
                            Tested = 0
                        },
                        new
                        {
                            Identifier = 15,
                            DateOfProduction = new DateTime(2020, 4, 20, 10, 52, 28, 150, DateTimeKind.Local).AddTicks(4621),
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.FullLicense", b =>
                {
                    b.Property<int>("FullLicenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicenseId")
                        .HasColumnType("int");

                    b.HasKey("FullLicenseId");

                    b.HasIndex("LicenseId")
                        .IsUnique();

                    b.ToTable("fullLicenses");
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.License", b =>
                {
                    b.Property<int>("LicenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EndpointDeviceIdentifier")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LicenseId");

                    b.HasIndex("EndpointDeviceIdentifier");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.PartialLicense", b =>
                {
                    b.Property<int>("PartialLicenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LicenseId")
                        .HasColumnType("int");

                    b.HasKey("PartialLicenseId");

                    b.HasIndex("LicenseId")
                        .IsUnique();

                    b.ToTable("PartialLicenses");
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.StaticProperties", b =>
                {
                    b.Property<int>("StaticPropertiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RequiredNumberOfEmployees")
                        .HasColumnType("int");

                    b.HasKey("StaticPropertiesId");

                    b.ToTable("StaticProperties");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.StorageProcess", b =>
                {
                    b.Property<int>("StorageProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndpointDeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("FromReturn")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PlacementDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("StorageProcessId");

                    b.HasIndex("EndpointDeviceId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("StorageProcesses");
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaInSquareMeters")
                        .HasColumnType("int");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.AddOnModule", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.EndpointDevice", "EndpointDevice")
                        .WithMany("AddOnModules")
                        .HasForeignKey("EndpointDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.BluetoothModule", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.AddOnModule", "AddOnModule")
                        .WithMany("BluetoothModules")
                        .HasForeignKey("AddOnModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Client", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.CommunicationModule", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.EndpointDevice", "EndpointDevice")
                        .WithMany("CommunicationModules")
                        .HasForeignKey("EndpointDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Employee", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.Warehouse", "Warehouse")
                        .WithMany("Employees")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.EmployeeServiceman", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.Employee", "Employee")
                        .WithOne("EmployeeServicemen")
                        .HasForeignKey("Projekt_Koncowy_GUI.Models.EmployeeServiceman", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.EmployeeStorekeeper", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.Employee", "Employee")
                        .WithOne("EmployeeStorekeeper")
                        .HasForeignKey("Projekt_Koncowy_GUI.Models.EmployeeStorekeeper", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.FullLicense", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.License", "License")
                        .WithOne("FullLicense")
                        .HasForeignKey("Projekt_Koncowy_GUI.Models.FullLicense", "LicenseId")
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.License", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.EndpointDevice", null)
                        .WithMany("Licenses")
                        .HasForeignKey("EndpointDeviceIdentifier");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.PartialLicense", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.License", "License")
                        .WithOne("PartialLicense")
                        .HasForeignKey("Projekt_Koncowy_GUI.Models.PartialLicense", "LicenseId")
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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.StorageProcess", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.EndpointDevice", "EndpointDevice")
                        .WithMany("StorageProcesses")
                        .HasForeignKey("EndpointDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Koncowy_GUI.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
