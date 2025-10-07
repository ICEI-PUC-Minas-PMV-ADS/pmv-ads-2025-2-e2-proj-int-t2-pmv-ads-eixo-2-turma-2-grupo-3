using Microsoft.AspNetCore.Mvc;

namespace Cuida.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}