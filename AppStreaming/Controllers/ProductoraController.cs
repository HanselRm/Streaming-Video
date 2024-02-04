using LogicApplication.Service;
using LogicApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStreaming.Controllers
{
    public class ProductoraController : Controller
    {
        public readonly ProductoraService productoraService;

        public ProductoraController(Database.AppContext dbContext)
        {
            productoraService = new(dbContext);
        }
        //Index de la vista del controlador
        public async Task<IActionResult> Index()
        {
            return View(await productoraService.GetAllViewModel());
        }
        
        //Vista de crear productora
        public IActionResult Create()
        {
            return View("SaveProductora", new ProductoraViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductoraViewModel pm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", pm);
            }

            await productoraService.Add(pm);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProductora", await productoraService.GetByIdGeneroViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoraViewModel pm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", pm);
            }
            await productoraService.Udapte(pm);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await productoraService.GetByIdGeneroViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePorPost(int id)
        {

            await productoraService.Delete(id);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }
    }
}
