using Database.Models;
using LogicApplication.Service;
using LogicApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStreaming.Controllers
{
    public class SerieController : Controller
    {
        public readonly SerieService serieService;
        public readonly GeneroService generoService;
        public readonly ProductoraService productoraService;

        public SerieController(Database.AppContext dbContext)
        {
            serieService = new(dbContext);
            generoService = new(dbContext);
            productoraService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await serieService.GetAllViewModel());
        }




        public async Task<IActionResult> Create()
        {
            var generoList = await generoService.GetAllViewModel();
            var productoraList = await productoraService.GetAllViewModel();
            var viewModel = new SaveSerieViewModel
            {
                generoList = generoList,
                productoraList = productoraList
            };
            return View("SaveSerie", viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel sm)
        {

            if (!ModelState.IsValid)
            {
                var generoList = await generoService.GetAllViewModel();
                var productoraList = await productoraService.GetAllViewModel();
                sm.generoList = generoList;
                sm.productoraList = productoraList;
                return View("SaveSerie", sm);
            }

            await serieService.Add(sm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }




        public async Task<IActionResult> Edit(int id)
        {
            var generoList = await generoService.GetAllViewModel();
            var productoraList = await productoraService.GetAllViewModel();
            var serie = await serieService.GetByIdGeneroViewModel(id);
            var viewModel = new SaveSerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                Enlace = serie.Enlace,
                ImagenUrl = serie.ImagenUrl,
                IdGeneroPrimario = serie.IdGeneroPrimario,
                IdGeneroSecundario = serie.IdGeneroSecundario,
                IdProductora = serie.IdProductora,
                generoList = generoList,
                productoraList = productoraList
            };
            return View("SaveSerie", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel sm)
        {
            sm.generoList = await generoService.GetAllViewModel();
            sm.productoraList = await productoraService.GetAllViewModel();



            if (!ModelState.IsValid)
            {
                var generoList = await generoService.GetAllViewModel();
                var productoraList = await productoraService.GetAllViewModel();
                sm.generoList = generoList;
                sm.productoraList = productoraList;

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

        public async Task<IActionResult> Detalles(int id)
        {
            SaveSerieViewModel serie = await serieService.GetByIdGeneroViewModel(id);

            return View("Detalles",serie);
        }
    }
}
