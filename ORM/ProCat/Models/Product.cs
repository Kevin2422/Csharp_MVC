using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace ProCat.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}

        [Required]

        public string Name {get;set;}

        [Required]
        public string Description {get;set;}
        [Required]
        [Range(0,Int32.MaxValue)]
        public decimal Price {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Association> CAssociations {get;set;}
    }
}