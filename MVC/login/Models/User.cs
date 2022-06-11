using System.ComponentModel.DataAnnotations;
namespace login.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string FirstName {get;set;}
        [Required]
        [MinLength(2)]
        public string LastName {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required]
        [Compare("Password", ErrorMessage ="Passwords must match")]
        [DataType(DataType.Password)]
        
        public string CPassword {get;set;}

    }
}