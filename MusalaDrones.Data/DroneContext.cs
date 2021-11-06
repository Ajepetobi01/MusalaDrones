using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusalaDrones.Common.Enums;
using MusalaDrones.Data.Models;

namespace MusalaDrones.Data
{
    public class DroneContext:DbContext
    {


        public DroneContext(DbContextOptions <DroneContext> options):base(options)
        {

        }

        public DbSet<Drone> Drones { get; set; }

        public DbSet<Medication> Medications { get; set; }

        public DbSet<MedicationImage> MedicationImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drone>().HasData(SeedDrones());
        }


        private static List<Drone> SeedDrones()
        {
            return new List<Drone>
            {
                new Drone("Kristina01",DroneModel.HeavyWeight,450),
                new Drone("Martina01",DroneModel.LightWeight,250),
                new Drone("Dina01",DroneModel.CruiserWeight,400),
                new Drone("Sanja01",DroneModel.MiddleWeight,350),
                new Drone("Kristina02",DroneModel.HeavyWeight,470),
                new Drone("Martina02",DroneModel.LightWeight,230),
                new Drone("Dina02",DroneModel.CruiserWeight,410),
                new Drone("Sanja02",DroneModel.MiddleWeight,365),
                new Drone("Kristina03",DroneModel.HeavyWeight,481),
                new Drone("Martina03",DroneModel.LightWeight,243)
            };
        }
    }
}
