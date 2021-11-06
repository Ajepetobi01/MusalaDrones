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

        public DbSet<DroneMedication> DroneMedications { get; set; }



       


        
    }
}
