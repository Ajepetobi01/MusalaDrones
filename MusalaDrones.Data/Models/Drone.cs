using System;
using System.ComponentModel.DataAnnotations;
using MusalaDrones.Common.Enums;

namespace MusalaDrones.Data.Models
{
    public class Drone
    {


        public Drone()
        {

        }


        public Drone(string serialNumber, DroneModel model, int weight)
        {
            SerialNumber = serialNumber;
            Model = model;
            Weight = weight;
            BatteryCapacity = 100;
            State = DroneState.Idle;

        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string SerialNumber { get; set; }

        public DroneModel Model { get; set; }

        public int Weight { get; set; }

        public double BatteryCapacity  { get; set; }

        public DroneState State { get; set; }
    }
}
