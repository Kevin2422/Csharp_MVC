using Microsoft.AspNetCore.Mvc;
using System;
namespace datetime
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult DisplayDate()
        {
            DateTime CurrentTime = DateTime.Now;
            string time = CurrentTime.ToString("MMMM dd, yyyy h:mm tt");


            ViewBag.time = time;
            return View(); 
        }
    }


    
}

