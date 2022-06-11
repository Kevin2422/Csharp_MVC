
using Microsoft.AspNetCore.Mvc;
namespace razorfun
{
    public class HomeController : Controller
    {
        [HttpGet ("")]
        public ViewResult Food()
        { 
            return View();
        }

    }
}