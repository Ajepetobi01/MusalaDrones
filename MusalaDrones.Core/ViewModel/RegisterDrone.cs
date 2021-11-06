using System;
using System.ComponentModel.DataAnnotations;
using MusalaDrones.Common.Enums;

namespace MusalaDrones.Core.ViewModel
{
    public class RegisterDrone
    {
        [MaxLength(100)]
        public string SerialNumber { get; set; }

        public DroneModel Model { get; set; }

        public int Weight { get; set; }

    }
}
