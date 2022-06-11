using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EFIntro.Models;
using System.Linq;
// Other using statements
namespace Monsters.Controllers
{
    public class MonsterController : Controller
    {
        private MyContext _context;
     
        // here we can "inject" our context service into the constructor
        public MonsterController(MyContext context)
        {
            _context = context;
        }
     
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Monster> AllMonsters = _context.Monsters.ToList();
            ViewBag.Monsters = AllMonsters;
            // Get all Users
            ViewBag.AllUsers = _Context.Users.ToList();
    
            // Get Users with the LastName "Jefferson"
            ViewBag.Jeffersons = dbContext.Users
                .Where(u => u.LastName == "Jefferson");
 
    	    // Get the 5 most recently added Users
            ViewBag.MostRecent = dbContext.Users
    	        .OrderByDescending(u => u.CreatedAt)
    	        .Take(5)
    	        .ToList();
            
            return View();
}
        
            public IActionResult GetOneUser(string Email)
{
    Person oneUser = dbContext.Users.FirstOrDefault(user => user.Email == Email);

    // Other code

    }
    [HttpPost("create")]
public IActionResult CreateUser(User newUser)
{
    // We can take the User object created from a form submission
	// And pass this object to the .Add() method
    dbContext.Add(newUser);
    // OR dbContext.Users.Add(newUser);
    dbContext.SaveChanges();
    // Other code
}

[HttpGet("update/{userId}")]
public IActionResult UpdateUser(int userId)
{
    // We must first Query for a single User from our Context object to track changes.
    User RetrievedUser = dbContext.Users
        .FirstOrDefault(user => user.UserId == userId);
    // Then we may modify properties of this tracked model object
    RetrievedUser.Name = "New name";
    RetrievedUser.UpdatedAt = DateTime.Now;
    
    // Finally, .SaveChanges() will update the DB with these new values
    dbContext.SaveChanges();
    
    // Other code
}
[HttpGet("delete/{userId}")]
public IActionResult DeleteUser(int userId)
{
    // Like Update, we will need to query for a single user from our Context object
    User RetrievedUser = dbContext.Users
        .SingleOrDefault(user => user.UserId == userId);
    
    // Then pass the object we queried for to .Remove() on Users
    dbContext.Users.Remove(RetrievedUser);
    
    // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
    dbContext.SaveChanges();
    // Other code
}
 }
}
