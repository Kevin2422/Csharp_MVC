using Microsoft.AspNetCore.Mvc;
namespace portfolio
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public ViewResult About()
        {
            return View();
        }

        
        [HttpGet ("projects")]
        public ViewResult Project()
        {
            return View();
        }

        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View();
        }


    }

}