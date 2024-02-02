using LogicApplication.Service;
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

        public async Task<IActionResult> Index()
        {
            return View(await productoraService.GetAllViewModel());
        }
    }
}
