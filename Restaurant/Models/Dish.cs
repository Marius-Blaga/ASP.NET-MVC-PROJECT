using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public int Calories { get; set; }

        public int Price { get; set; }
        public string Description { get; set; }
        public string Reccomendation { get; set; }

    }
}
