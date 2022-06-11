using System.ComponentModel.DataAnnotations;


namespace ProCat.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {get;set;}
        public int ProductId {get;set;}
        public Product ProWCat {get;set;}
        public int CategoryId {get;set;}
        public Category CatWPro {get;set;}
    }
}