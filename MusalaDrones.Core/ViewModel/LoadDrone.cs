using System;
using System.Collections.Generic;

namespace MusalaDrones.Core.ViewModel
{
    public class LoadDrone
    {
       public int DroneId { get; set; }

       public List<int> MedicationIds { get; set; }
    }
}
