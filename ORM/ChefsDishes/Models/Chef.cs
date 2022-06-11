using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ChefsDishes.Models
{
    public class Chef


    {
        public Chef()
        {
            NumDishes = 0;
        }

        [Key]
        public int ChefId { get; set; }
        [Required]
        public string FirstName { get; set; }
        

        [Required]
        public string LastName { get; set; }

        [Required]
        
        [PastDateAttribute]
        [Over18]

        
        public DateTime Birthday {get;set;}


        public int NumDishes {get;set;}






        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public List<Dish> dishes {get;set;}
    }
}

public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt;
            // safely unbox value to DateTime
            if(value is DateTime)
                dt = (DateTime)value;
            else
                return new ValidationResult("Invalid datetime");
            
            if(dt > DateTime.Now)
                return new ValidationResult("Date must be in the past");

            return ValidationResult.Success;
        }
    }

    public class Over18 : ValidationAttribute
    {
        protected  override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt;
            if(value is DateTime)
                dt = (DateTime)value;
            else
                return new ValidationResult("Invalid datetime");

            TimeSpan result = DateTime.Now.Subtract(dt)/365;
            int results = (int)Math.Floor(result.TotalDays);
            if(results<18)
            {
                return new ValidationResult("Age must be over 18");
            }
            return ValidationResult.Success;
        }
    }