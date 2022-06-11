using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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


        //  Register User
        [HttpPost("register")]

        public IActionResult RegisterUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return Redirect($"Accounts/{newUser.UserId}");
            }
            return View("Index");
        }

        // Login with validate Email and Password Hashing

        [HttpPost("signin")]
        public IActionResult SignIn(LogUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
                // If no user exists with provided email
                if (userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }

                // Initialize hasher object
                var hasher = new PasswordHasher<LogUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogPassword);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return Redirect($"Accounts/{userInDb.UserId}");
            } 
            return View("Login");
        }

     // Amount page
        [HttpGet("Accounts/{UserId}")]
        public IActionResult Accounts(int UserId)
        {

            int? SessionId= HttpContext.Session.GetInt32("UserId");

            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                Console.WriteLine("No User");
                TempData["Variable"] = "Please Login";
                return RedirectToAction("Index");
            }
            
            decimal CurrentBalance = 0;

            ViewBag.User = _context.Users
            .Include(t => t.MoneyTransfer)
            .FirstOrDefault(p => p.UserId == (int) SessionId);
            foreach(var t in ViewBag.User.MoneyTransfer)
            {
                CurrentBalance += t.Amount;
            }
            ViewBag.UserId = SessionId;
            ViewBag.CurrentBalance = string.Format("{0:C}", CurrentBalance);


            return View("Accounts"); 
        }

    // Login Page
        [HttpGet("login")]

        public ViewResult LoginPage()
        {
            return View("Login");
        }

    // Withdraw/Deposit
        [HttpPost("changeamt")]
        public IActionResult UserTransaction(Transaction amt)
        {
            int? SessionId= HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = (int) SessionId;

            Console.WriteLine(ViewBag.UserId);
            Console.WriteLine(amt.UserId);
            decimal CurrentBalance = 0;

            ViewBag.User = _context.Users
            .Include(t => t.MoneyTransfer)
            .FirstOrDefault(p => p.UserId == (int) SessionId);
            foreach(var t in ViewBag.User.MoneyTransfer)
            {
                CurrentBalance += t.Amount;
                ;
            }
            ViewBag.CurrentBalance = string.Format("{0:C}", CurrentBalance);

            if(ModelState.IsValid)
            {
                System.Console.WriteLine(amt.Amount);
                if(amt.Amount < 0 && Math.Abs(amt.Amount) <= CurrentBalance || amt.Amount > 0)
                {

                _context.Add(amt);
                _context.SaveChanges();
                return Redirect($"Accounts/{SessionId}");
                }
                ModelState.AddModelError("Amount", "Cannot withdraw more than balance");
                    return View("Accounts");
            }
            
            return View("Accounts");
        }
        
    }
}
