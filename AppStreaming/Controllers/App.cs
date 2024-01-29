using Microsoft.AspNetCore.Mvc;

namespace AppStreaming.Controllers
{
    public class App : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
