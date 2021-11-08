using System;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Data.Models
{
    public class PeriodicHistoryLog
    {
        [Key]
        public int Id { get; set; }

        public DateTime InsertedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public string EventData { get; set; }

        public double BatteryCapacity { get; set; }

        public int DroneId { get; set; }
    }
}