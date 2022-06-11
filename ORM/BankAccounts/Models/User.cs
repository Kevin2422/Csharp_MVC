using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace BankAccounts.Models
{
    public class User
    {
        [Key]

        public int UserId {get;set;}

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

        [NotMapped]
        [Required]
        [Compare("Password", ErrorMessage = "Passwords Must Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Transaction> MoneyTransfer {get;set;}
    }
}