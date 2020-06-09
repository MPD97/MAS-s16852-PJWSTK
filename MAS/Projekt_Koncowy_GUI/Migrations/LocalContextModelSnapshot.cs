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

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Component", b =>
                {
                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Identifier");

                    b.ToTable("Component");
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

                    b.ToTable("EndpointDevice");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComponentIdentifier")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EndpointDeviceIdentifier")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.HasIndex("ComponentIdentifier");

                    b.HasIndex("EndpointDeviceIdentifier");

                    b.ToTable("Equipment");
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

                    b.ToTable("Replacement");
                });

            modelBuilder.Entity("Projekt_Koncowy_GUI.Models.Equipment", b =>
                {
                    b.HasOne("Projekt_Koncowy_GUI.Models.Component", "Component")
                        .WithMany("Equipments")
                        .HasForeignKey("ComponentIdentifier");

                    b.HasOne("Projekt_Koncowy_GUI.Models.EndpointDevice", "EndpointDevice")
                        .WithMany("Equipments")
                        .HasForeignKey("EndpointDeviceIdentifier");
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
