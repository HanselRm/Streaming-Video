using LogicApplication.Service;
using LogicApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStreaming.Controllers
{
    public class GeneroController : Controller
    {
        public readonly GeneroService generoService;

        public GeneroController(Database.AppContext dbContext)
        {
            generoService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await generoService.GetAllViewModel());
        }


        public IActionResult Create()
        {
            return View("SaveGenero", new GeneroViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(GeneroViewModel gm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero",gm);
            }

            await generoService.Add(gm);
            return RedirectToRoute(new { controller = "Genero", action = "Index"});
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveGenero", await generoService.GetByIdGeneroViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GeneroViewModel gm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", gm);
            }
            await generoService.Udapte(gm);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await generoService.GetByIdGeneroViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePorPost(int id)
        {
         
            await generoService.Delete(id);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }
    }
}
