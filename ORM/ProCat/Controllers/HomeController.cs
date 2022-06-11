using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProCat.Models;
using Microsoft.EntityFrameworkCore;

namespace ProCat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.products = _context.Products.ToList();
            return View();
        }
        [HttpPost("CProduct")]
        public IActionResult CreateProduct(Product SubProduct)
        {
            if(ModelState.IsValid)
            {

            _context.Add(SubProduct);
            _context.SaveChanges();
            return Redirect("/");
            }
            ViewBag.products = _context.Products.ToList();
            return View("Index");
        }
        [HttpGet("/product/{ProductId}")]
        public IActionResult ViewProduct(int ProductId)
        {
          
            ViewBag.product = _context.Products
            .Include(l => l.CAssociations)
                .ThenInclude(p => p.CatWPro)
            .FirstOrDefault(l => l.ProductId == ProductId);

            ViewBag.OtherCategories = _context.Categories
            .Include(l => l.Associations)
            .Where( l => !l.Associations.Any(l => l.ProductId == ProductId) || !l.Associations.Any())
            .ToList();
            return View();
        }

        [HttpPost("/addcategory-p")]

        public IActionResult AddCatToProduct(Association association)
        {
            if(ModelState.IsValid)
            {

            _context.Add(association);
            _context.SaveChanges();
            return Redirect($"/product/{association.ProductId}");
            }
            return View("ViewProduct");
        }
        [HttpGet("categories")]

        public IActionResult Categories()
        {
            List<Category> categories = _context.Categories.ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost("CCategory")]
        public IActionResult CreateCategory(Category SubCat)
        {
            if(ModelState.IsValid)
            {

            _context.Add(SubCat);
            _context.SaveChanges();
            return Redirect("/categories");
            }
            ViewBag.categories = _context.Categories.ToList();
            return View("Categories");
        }

        [HttpGet("/category/{CategoryId}")]
        public IActionResult ViewCategory(int CategoryId)
        {
          
            ViewBag.category = _context.Categories
            .Include(l => l.Associations)
                .ThenInclude(p => p.ProWCat)
            .FirstOrDefault(l => l.CategoryId == CategoryId);

            ViewBag.OtherProducts = _context.Products
            .Include(l => l.CAssociations)
            .Where( l => !l.CAssociations.Any(l => l.CategoryId == CategoryId) || !l.CAssociations.Any())
            .ToList();
            return View();
        }

         [HttpPost("/addproduct-c")]

        public IActionResult AddProductToCat(Association association)
        {
            if(ModelState.IsValid)
            {

            _context.Add(association);
            _context.SaveChanges();
            return Redirect($"/category/{association.CategoryId}");
            }
            return View("ViewProduct");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
