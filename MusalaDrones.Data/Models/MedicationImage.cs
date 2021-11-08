using System;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Data.Models
{
    public class MedicationImage
    {

        public MedicationImage()
        {
            
        }

        public MedicationImage(int id, string image)
        {
            Id = id;
            ImageBase64 = image;
        }

        [Key]
        public int Id { get; set; }

        
        
        public string ImageBase64 { get; set; }
    }
}
