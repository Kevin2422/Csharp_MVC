using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models
{
    public class LogUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email required")]
        public string LogEmail {get;set;}
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}
    }
}