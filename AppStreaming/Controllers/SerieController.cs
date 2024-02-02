using LogicApplication.Service;
using LogicApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStreaming.Controllers
{
    public class SerieController : Controller
    {
        public readonly SerieService serieService;

        public SerieController(Database.AppContext dbContext)
        {
            serieService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await serieService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveSerie", new SaveSerieViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel sm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveSerie", sm);
            }

            await serieService.Add(sm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveSerie", await serieService.GetByIdGeneroViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel sm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveSerie", sm);
            }
            await serieService.Udapte(sm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await serieService.GetByIdGeneroViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePorPost(int id)
        {

            await serieService.Delete(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
    }
}
