using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUDelicious.Models;
using System.Linq;
// Other using statements
namespace CRUDelicious.Controllers
{
    public class DishController : Controller
    {
        private MyContext _context;
     
        // here we can "inject" our context service into the constructor
        public DishController(MyContext context)
        {
            _context = context;
        }

     [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> Dishes = _context.Dishes.ToList();
            ViewBag.Dishes = Dishes;
            return View();

    }
    [HttpGet("dish/{Id}")]
    public IActionResult SeeDish(int Id)
    {
        Dish OneDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == Id);
        ViewBag.Adish = OneDish;
        return View();
    }

    [HttpGet("createdish")]

    public ViewResult Create()
    {
        return View();
    }
    [HttpPost("create")]

    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {

        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else
        {
            return View("Create");
        }
        
    }
    [HttpGet("delete/{Id}")]
    public IActionResult DeleteDish(int Id)
    {
        // Like Update, we will need to query for a single user from our Context object
    Dish deleteDish = _context.Dishes
        .SingleOrDefault(dish => dish.DishId == Id);
    
    // Then pass the object we queried for to .Remove() on Users
    _context.Dishes.Remove(deleteDish);
    
    // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
    _context.SaveChanges();
    // Other code
    return RedirectToAction("Index");
    }

    [HttpGet("edit/{Id}")]

    public IActionResult EditDish(int Id)
    {
        Dish getDish = _context.Dishes
        .SingleOrDefault(dish => dish.DishId == Id);
        return View(getDish);
    }

    [HttpPost("editDish/{Id}/{model}")]
    public IActionResult Edit(int Id, Dish newValues)
    {
        Dish getDish = _context.Dishes
        .SingleOrDefault(dish => dish.DishId == Id);
        if (ModelState.IsValid)
        {

        getDish.Name = newValues.Name;
        getDish.Calories = newValues.Calories;
        getDish.Chef = newValues.Chef;
        getDish.Tastiness = newValues.Tastiness;
        getDish.UpdatedAt = newValues.UpdatedAt;
        getDish.Description = newValues.Description;

        _context.SaveChanges();

        System.Console.WriteLine(getDish.DishId);


        return Redirect("/dish/" + getDish.DishId);
        }
        return View("EditDish", getDish);

    }
}
}