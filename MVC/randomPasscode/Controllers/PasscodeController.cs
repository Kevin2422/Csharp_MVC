using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
namespace randomPasscode.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            if ( HttpContext.Session.GetInt32("num") == null )
            {
                HttpContext.Session.SetInt32("num", 1);
            }
            else if (HttpContext.Session.GetInt32("num") > 0)
            {
                int? count = HttpContext.Session.GetInt32("num");
                count ++;
                HttpContext.Session.SetInt32("num", (int)count);
            }

            Random rand = new Random();
            string randomstring = "";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for(int i = 0; i<14; i++)
            {
                int randIndex = rand.Next(chars.Length);
                randomstring = randomstring + chars[randIndex];

            }
            ViewBag.passcode = randomstring;
            ViewBag.count =  HttpContext.Session.GetInt32("num");
            return View();


        }
    }
}