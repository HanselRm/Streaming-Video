using LogicApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Database;

namespace AppStreaming.Controllers
{
    public class AppController : Controller
    {
        public readonly SerieService serieService;

        public AppController(Database.AppContext dbContext)
        {
            serieService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await serieService.GetAllViewModel());
        }
    }
}
