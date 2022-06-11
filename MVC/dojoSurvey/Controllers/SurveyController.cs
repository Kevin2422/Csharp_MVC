using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
namespace dojoSurvey
{
    
    public class SurveyController : Controller
    {
        [HttpGet("")]
        public ViewResult Survey()
        {
            
            int num = RandomNumberGenerator.GetInt32(10000);
            System.Console.WriteLine(num);
            return View();
        }
        [HttpPost("result")]
       
        public IActionResult Results(UserData user)
        {
            if (ModelState.IsValid)
            {
            return View(user);
            }
           
                return View("Survey");
        }
      
    }
}