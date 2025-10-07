using Microsoft.AspNetCore.Mvc;

namespace Cuida.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}