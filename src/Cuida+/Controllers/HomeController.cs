using Microsoft.AspNetCore.Mvc;

namespace Cuida_.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("home")]
        public IActionResult Index()
        {
            return View("Home");
        }
    }
}
