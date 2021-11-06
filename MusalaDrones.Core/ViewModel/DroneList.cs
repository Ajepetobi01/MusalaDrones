using System;
namespace MusalaDrones.Core.ViewModel
{
    public class DroneList
    {
       
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public double BatteryCapacity { get; set; }

        public string State { get; set; }
    }
}
