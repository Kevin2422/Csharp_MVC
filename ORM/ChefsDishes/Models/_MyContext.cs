using Microsoft.EntityFrameworkCore;
using ChefsDishes.Models;

namespace ChefsDishes.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        public DbSet<Chef> Chefs { get; set; }

        public DbSet<Dish> Dishes {get;set;}
        // other tables will also need a dbset
    }
}