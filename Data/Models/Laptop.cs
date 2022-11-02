using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Model { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Processor { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Display { get; set; }

        [Range(0, 100_000_000)]
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        public int OperationSystemId { get; set; }
        public OperationSystem? OperationSystem { get; set; }
    }
}
