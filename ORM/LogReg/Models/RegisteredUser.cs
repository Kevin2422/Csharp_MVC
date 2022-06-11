using System.ComponentModel.DataAnnotations;
namespace LogReg.Models
{
    public class RegisteredUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email required")]
        public string LogEmail {get;set;}
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}
    }
}