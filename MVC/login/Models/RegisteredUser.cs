using System.ComponentModel.DataAnnotations;
namespace login.Models
{
    public class RegisteredUser
    {
        [EmailAddress]
        [Required]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}