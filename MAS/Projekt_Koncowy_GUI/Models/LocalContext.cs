using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class LocalContext : DbContext
    {

        public DbSet<EndpointDevice> EndpointDevices { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Replacement> Replacements { get; set; }

        public LocalContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EndpointDevice>()
              .HasKey(ed => new { ed.Identifier });

            modelBuilder.Entity<Component>()
              .HasKey(comp => new { comp.Identifier });


            modelBuilder.Entity<EndpointDevice>().HasData(new EndpointDevice
            {
                Identifier = 10,
                DateOfProduction = DateTime.Now.AddDays(-90),
                Gauge = Gauge.P,
                Model = "Speed 500w",
                Tested = Tested.Nie,
                TestResult = TestResult.Negatywny
            });
            modelBuilder.Entity<EndpointDevice>().HasData(new EndpointDevice
            {
                Identifier = 15,
                DateOfProduction = DateTime.Now.AddDays(-60),
                Gauge = Gauge.P,
                Model = "Ride Fast 200W",
                Tested = Tested.Nie,
                TestResult = TestResult.Negatywny
            });


            modelBuilder.Entity<Component>().HasData(new Component
            {
                Identifier = "AAA-BBB-123",
                AvailableAmount = 50,
            });
            modelBuilder.Entity<Component>().HasData(new Component
            {
                Identifier = "356-RRR-QAZ",
                AvailableAmount = 10,
            });
            modelBuilder.Entity<Component>().HasData(new Component
            {
                Identifier = "MMM-005-550",
                AvailableAmount = 3,
            });


            modelBuilder.Entity<Replacement>().HasData(new Replacement
            {
               ReplacementId = "REPLACEMENT-ABC123",
               ReplacedById = "AAA-BBB-123",
               BaseId = "MMM-005-550"
            });


            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
               EquipmentId = 1,
               EndpointDeviceId = 10,
               ComponentId = "356-RRR-QAZ",
               Amount = 5,
            });

            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                EquipmentId = 2,
                EndpointDeviceId = 10,
                ComponentId = "MMM-005-550",
                Amount = 4,
            });

            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                EquipmentId = 3,
                EndpointDeviceId = 15,
                ComponentId = "MMM-005-550",
                Amount = 1,
            });
            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                EquipmentId = 4,
                EndpointDeviceId = 15,
                ComponentId = "AAA-BBB-123",
                Amount = 6,
            });
            
        }
    }
}
