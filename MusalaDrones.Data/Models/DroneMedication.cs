using System;
namespace MusalaDrones.Data.Models
{
    public class DroneMedication
    {
        public int Id { get; set; }

        public int DroneId { get; set; }

        public int MedicationId { get; set; }

        public DateTime TimeLoaded { get; set; }

        public DateTime? TimeDelivered { get; set; }
    }
}
