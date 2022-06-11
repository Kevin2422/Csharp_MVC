using Microsoft.AspNetCore.Mvc;
using login.Models;
namespace login.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult registerUser(User user)
        {
            if (ModelState.IsValid)
            {
                return View("Success");

            }
            return View("Index");
        }
        [HttpPost("/login")]

         public IActionResult Login(RegisteredUser user)
        {
            if (ModelState.IsValid)
            {
                return View("Success");

            }
            return View("Index");
        }

    }

}