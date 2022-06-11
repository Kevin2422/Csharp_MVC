using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ChefsDishes.Models;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MyContext _context;

        
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _context =context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Chefs = _context.Chefs.Include(l => l.dishes).ToList();
            return View();
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.Dishes = _context.Dishes
            .Include(l => l.chef);
            
            return View();
        }

        [HttpGet("adddish")]

        public IActionResult AddDish()
        {
            ViewBag.Chefs = _context.Chefs.ToList();
            return View();
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dish newdish)
        {
            if (ModelState.IsValid)
        {
            Chef chef = _context.Chefs.FirstOrDefault(l => l.ChefId == newdish.ChefId);
            chef.NumDishes ++;
            

        _context.Add(newdish);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Chefs = _context.Chefs.ToList();
            return View("AddDish");
        }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Add")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult AddChef(Chef newchef)
        {
            if (ModelState.IsValid)
        {

        _context.Add(newchef);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else
        {
            return View("Create");
        }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
