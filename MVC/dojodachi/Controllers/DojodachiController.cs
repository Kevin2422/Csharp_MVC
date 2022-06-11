using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojodachi.Models;
namespace dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
    
        public void makeDachiSession(Dojodachi dachi)
        {
            
            HttpContext.Session.SetInt32("happiness", (int) dachi.happiness);
            HttpContext.Session.SetInt32("fullness", (int)dachi.fullness);
            HttpContext.Session.SetInt32("energy", (int) dachi.energy);
            HttpContext.Session.SetInt32("meals", (int) dachi.meals);
        }

        public Dojodachi getDachiSession()
        {
            Dojodachi dachi = new Dojodachi(HttpContext.Session.GetInt32("happiness"), HttpContext.Session.GetInt32("fullness"),HttpContext.Session.GetInt32("energy"),HttpContext.Session.GetInt32("meals"));
            return dachi;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            if ( HttpContext.Session.GetInt32("happiness") == null )
            {
                Dojodachi NewDachi = new Dojodachi();
                makeDachiSession(NewDachi);

            }
            if (HttpContext.Session.GetString("url")== null)
            {
                HttpContext.Session.SetString("url", "happy.jpg");
            }

            Dojodachi dachi =  getDachiSession();
            if (dachi.DidLose())
            {
                TempData.Clear();
                HttpContext.Session.SetString("url", "sad.jpg");
            }
            if (dachi.DidWin())
            {
                TempData.Clear();
                HttpContext.Session.SetString("url", "happy.jpg");
            }
            
            ViewBag.url = HttpContext.Session.GetString("url");
            

            return View(dachi);
        }
        [HttpGet("action/{actions}")]
        public IActionResult button(string actions)
        {
            
            Dojodachi dachi = getDachiSession();
            if (actions == "feed")
            {
                string [] data = dachi.Feed();
                TempData["message"] = data[0];
                HttpContext.Session.SetString("url", data[1]);
                makeDachiSession(dachi);


            }
            if (actions == "play")
            {
                string [] data = dachi.Play();
                TempData["message"] = data[0];
                HttpContext.Session.SetString("url", data[1]);
                makeDachiSession(dachi);
            }
            if (actions == "work")
            {
                string [] data = dachi.Work();
                TempData["message"] = data[0];
                HttpContext.Session.SetString("url", data[1]);
                makeDachiSession(dachi);

            }
            if (actions == "sleep")
            {
                string [] data = dachi.Sleep();
                TempData["message"] = data[0];
                HttpContext.Session.SetString("url", data[1]);
                makeDachiSession(dachi);
            }
            return RedirectToAction("Index");
        }
        [HttpGet("clear")]
        public RedirectToActionResult clear()
        {
            HttpContext.Session.Clear();
            TempData.Clear();
            return RedirectToAction("Index");
        }
    }
}