using System;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Data.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public int Weight { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        public int ImageId { get; set; }
    }
}
