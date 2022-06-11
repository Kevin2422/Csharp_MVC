using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace WeddingPlanner.Models
{
    public class Wedding

    {
        [Key]

        public int WeddingId {get;set;}

        [Required]
        public string WedderOne {get;set;}
        [Required]
        public string WedderTwo {get;set;}

        [Required]
        [DataType(DataType.DateTime)]
        [FutureDate]
        public DateTime DateofWedding {get;set;}

        [Required]

        public string WeddingAddress {get;set;}

        public int UserId {get;set;}

        public List<Reservation> GuestsWhoRSVPed {get;set;}

        public User Creator {get;set;}

       
    }
}
public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt;
            // safely unbox value to DateTime
            if(value is DateTime)
                dt = (DateTime)value;
            else
                return new ValidationResult("Invalid datetime");
            
            if(dt < DateTime.Now)
                return new ValidationResult("Date must be in the future");

            return ValidationResult.Success;
        }
    }