using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

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
        [NotMapped]
        public string CPassword {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Wedding> CreatedWeddings {get;set;}
        public List<Reservation> RSVPWeddings {get;set;}




    }
}