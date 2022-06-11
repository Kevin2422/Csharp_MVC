using System.ComponentModel.DataAnnotations;
using System;
public class UserData
{
    [NoZNames]
    [Required(ErrorMessage = "NOOÒ Required")]
    [MinLength(2)]
    public string name {get;set;}
    [Required]
    public string location {get;set;}
    [Required]
    public string language {get;set;}
    [MaxLength(20)]
    public string Comments {get;set;}
}

public class NoZNamesAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (((string)value).ToLower()[0] == 'z')
            return new ValidationResult("No names that start with Z allowed!");
        return ValidationResult.Success;
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