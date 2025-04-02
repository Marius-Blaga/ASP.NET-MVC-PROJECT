using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Drink
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]

        public int Price { get; set; } 
    }
}
