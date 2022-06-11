using Microsoft.AspNetCore.Mvc;
using firstmvc.Models;
using System.Collections.Generic;
namespace firstmvc.Controllers
{
    public class FirstController : Controller
    {
        [HttpGet("users")]
        public ViewResult Users()
        {
            List<User> SomeUsers = new List<User>()
            {
                new User("Bob", "Marley"),
                new User("Paul", "Bunyan"),
                new User("Moose", "Phillips")
            };
            return View(SomeUsers);
        }
        [HttpGet("user")]

        public IActionResult Index()
        {
            User someUser = new User("Moose","Phillips");

            return View(someUser);
        }
        [HttpGet("")]
        public ViewResult String()
        {
            string message = "Hello world";
            return View("String", message);
        }

        [HttpGet("numbers")]
        public ViewResult Numbers()
        {
            int[] numbers = {1,2,3,10,43,5};
            return View(numbers);
        }
        

        }
    }
