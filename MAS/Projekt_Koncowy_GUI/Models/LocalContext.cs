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
        }
    }
}
