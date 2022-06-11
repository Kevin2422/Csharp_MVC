using Microsoft.AspNetCore.Mvc;
using System;
namespace intro
{
    public class HomeController : Controller

    {
        [HttpGet("")]
public ViewResult Index()
{
    return View();
}
[HttpGet("{favoriteResponse}")]
// use IActionResult if you are returning multiple types of redirects
public IActionResult ItDepends(string favoriteResponse)
{
	if(favoriteResponse == "Redirect")
    {
    	return RedirectToAction("Index");
    }
	else if(favoriteResponse == "Json")
	{
		return Json(new {FavoriteResponse = favoriteResponse});
	}
    return View();
}
        // RedirectToActionResult redirects to a method, RedirectResult redirects to a url
        public RedirectToActionResult Method()
{
    // The anonymous object consists of keys and values
    // The keys should match the parameter names of the method being redirected to
    return RedirectToAction("OtherMethod", new { Food = "sandwiches", Quantity = 5 });
}
 
[HttpGet]
[Route("other/{Food}/{Quantity}")]
public ViewResult OtherMethod(string Food, int Quantity)
{
    Console.WriteLine($"I ate {Quantity} {Food}.");
    // Writes "I ate 5 sandwiches."
    return View();
}
// Other code
public class FirstController : Controller
{
    public RedirectToActionResult Method()
    {
        // redirects to the OtherMethod in SecondController
        return RedirectToAction("OtherMethod", "Second");
    }
}


        [Route("")]
        [HttpGet]
        public ViewResult HiThere()
        {
            // if no arguments passed, looks for HiThere.cshtml in the Views
            // Will look for it in the Home (because your class name is HomeController) folder, then the Shared folder
            // can also provide a string argument in the view, which will look for 
            // string.cshtml
            return View();
        }

        
        [HttpGet ("hello")]
        public string Hello()
        {
            return "Hi again";
        }

        [HttpGet("user/{username}")]
        public string HelloUser(string username)
        {
            return $"hi {username}";
        }


    }

}