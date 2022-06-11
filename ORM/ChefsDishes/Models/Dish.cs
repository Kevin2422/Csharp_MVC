using System;
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Range(1,5)]
        public int Tastiness { get; set; }


        [Range(1,int.MaxValue)]
        [Required]
        public int Calories { get; set; }

        [Required]
        public string Description { get; set; }




        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
        public int ChefId {get;set;}

        public Chef chef {get;set;}
    }
}