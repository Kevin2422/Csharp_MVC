using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
        
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            // If no user exists with provided email
            if(userInDb != null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Email already in use");
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Add(user);
                _context.SaveChanges();
                System.Console.WriteLine(user.UserId + "what is happensn");
                HttpContext.Session.SetInt32("UserId", (int)user.UserId);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpPost("/login")]

         public IActionResult Login(LogUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
            // If no user exists with provided email
            if(userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            var hasher = new PasswordHasher<LogUser>();
            
            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogPassword);
            if(result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
                
                HttpContext.Session.SetInt32("UserId", (int)userInDb.UserId);
                return RedirectToAction("Success");

            }
            return View("Index");
        }

        [HttpGet("Success")]
        public IActionResult Success()

        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }

            User user = _context.Users
            .SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.weddings = _context.Weddings
            .Include(l => l.GuestsWhoRSVPed)
            .ToList();

        return View(user);
        }

        [HttpGet("addwedding")]

        public IActionResult AddWedding()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [HttpPost("CreateWedding")]

        public IActionResult CreateWedding(Wedding addedWedding)
        {
            if(ModelState.IsValid)
            {

            _context.Add(addedWedding);
            _context.SaveChanges();
            return Redirect("Success");
            }
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View("AddWedding");
        }

        [HttpGet("/UnRSVP/{UserId}/{WeddingId}")]

        public IActionResult UNRSVP(int UserId, int WeddingId)
        {
            Reservation unreserve = _context.Reservations.FirstOrDefault(l=> l.WeddingId == WeddingId && l.UserId ==UserId);
            
            _context.Reservations.Remove(unreserve);
            _context.SaveChanges();
            return RedirectToAction("Success");

        }

        [HttpGet("/RSVP/{UserId}/{WeddingId}")]

        public IActionResult RSVP(int UserId, int WeddingId)
        {
            Reservation reserve = new Reservation(UserId, WeddingId);
            
            _context.Add(reserve);
            _context.SaveChanges();
            return RedirectToAction("Success");

        }

        [HttpGet("viewWedding/{WeddingId}")]

        public IActionResult ViewWedding(int WeddingId)
        {
            ViewBag.wedding = _context.Weddings
            .Include(l => l.GuestsWhoRSVPed)
                .ThenInclude(p => p.UserThatRSVPed)
            .FirstOrDefault(l => l.WeddingId == WeddingId);
            return View();
        }

        [HttpGet("delete/{WeddingId}")]

        public IActionResult DeleteWedding( int WeddingId)
        {
            Wedding deletewedding = _context.Weddings.SingleOrDefault(l => l.WeddingId == WeddingId);
            _context.Weddings.Remove(deletewedding);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        [HttpGet("logout")]

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
