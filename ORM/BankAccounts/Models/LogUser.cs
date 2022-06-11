using System;
using System.ComponentModel.DataAnnotations;



namespace BankAccounts.Models
{
    public class LogUser
    {
        [Required]
        public string LogEmail {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}

    }
}