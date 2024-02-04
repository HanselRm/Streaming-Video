using LogicApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Database;
using System.Xml.Linq;

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
            return View(await serieService.GetAllDetallesViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> BuscarNombre(string Name)
        {
            var seriesFiltradas = await serieService.GetByName(Name);
            return View("Index", seriesFiltradas);
        }

        [HttpPost]
        public async Task<IActionResult> BuscarPorGenero(String Genero)
        {
            var series = await serieService.GetAllDetallesViewModel();
            var generosFiltrados = series.Where(s => s.GeneroP.Contains(Genero) || s.GeneroS.Contains(Genero)).ToList();
            return View("Index", generosFiltrados);
        }

        [HttpPost]
        public async Task<IActionResult> BuscarPorProductora(String Productora)
        {
            var series = await serieService.GetAllDetallesViewModel();
            var productorasFiltradas = series.Where(s => s.Productora.Contains(Productora)).ToList();
            return View("Index", productorasFiltradas);
        }
    }
}
