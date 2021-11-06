using System;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Data.Models
{
    public class MedicationImage
    {
        [Key]
        public int Id { get; set; }

        
        public string ImageBase64 { get; set; }
    }
}
