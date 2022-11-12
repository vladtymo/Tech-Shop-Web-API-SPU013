using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    // Data Transfer Object - uses for data transfering between layers
    public class LaptopDto
    {
        // should contains primitive types
        // should not contins any logic
        public int Id { get; set; }
        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }
        //[Required]
        public string Processor { get; set; }
        public string Display { get; set; }
        //[Range(0, 10000)]
        public decimal Price { get; set; }
        //[Url]
        public string? ImagePath { get; set; }
        public int OSId { get; set; }
        public string? OSName { get; set; }
    }
}
