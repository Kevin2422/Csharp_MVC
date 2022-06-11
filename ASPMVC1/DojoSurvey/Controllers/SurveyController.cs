using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey
{
    public class SurveyController : Controller
    {
        [HttpGet("")]
        public ViewResult Survey()
        {
            return View();
        }
        [HttpPost("result")]
        public ViewResult Results(string name, string location, string language, string Comments)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.Comments = Comments;
            return View();
        }
        // public RedirectToActionResult Results2(string name, string location, string language, string Comments)
        // {
        //     ViewBag.name = name;
        //     ViewBag.location = location;
        //     ViewBag.language = language;
        //     ViewBag.Comments = Comments;
        //     return RedirectToAction("resultpage", new{name, language, location,Comments} );
        // }
        // [HttpGet("resultpage/{name}/{language}")]
        // public ViewResult ResultPage()
        // {

        // }
    }
}