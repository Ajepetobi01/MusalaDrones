using System;
using System.Collections.Generic;
using MusalaDrones.Common.Enums;
using MusalaDrones.Data;
using MusalaDrones.Data.Models;

namespace MusalaDrones.Core.ViewModel
{
    public static class SeedData
    {
        public static void SeedDrones(DroneContext dbContext)
        {
            var drones = new List<Drone>
            {
                new Drone(1,"Kristina01",DroneModel.HeavyWeight,450),
                new Drone(2, "Martina01",DroneModel.LightWeight,250),
                new Drone(3, "Dina01",DroneModel.CruiserWeight,400),
                new Drone(4, "Sanja01",DroneModel.MiddleWeight,350),
                new Drone(5, "Kristina02",DroneModel.HeavyWeight,470),
                new Drone(6, "Martina02",DroneModel.LightWeight,230),
                new Drone(7, "Dina02",DroneModel.CruiserWeight,410),
                new Drone(8, "Sanja02",DroneModel.MiddleWeight,365),
                new Drone(9,"Kristina03",DroneModel.HeavyWeight,481),
                new Drone(10,"Martina03",DroneModel.LightWeight,243)
            };

            dbContext.Drones.AddRange(drones);
            dbContext.SaveChanges();
        }
    }
}
