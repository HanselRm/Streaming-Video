using LogicApplication.Repository;
using LogicApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.Service
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _productoraRepository;

        public ProductoraService(Database.AppContext dbContex)
        {
            _productoraRepository = new(dbContex);
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var productoraList = await _productoraRepository.GetAllAsync();
            return productoraList.Select(Productora => new ProductoraViewModel
            {
                Id = Productora.Id,
                Nombre = Productora.Nombre
            }).ToList();
        }
    }
}
