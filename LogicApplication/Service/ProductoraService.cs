using Database.Models;
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
        public async Task Udapte(ProductoraViewModel pm)
        {
            Productora productora = new();
            productora.Id = pm.Id;
            productora.Nombre = pm.Nombre;
            await _productoraRepository.UdapteAsync(productora);
        }
        public async Task Add(ProductoraViewModel pm)
        {
            Productora productora = new();
            productora.Nombre = pm.Nombre;
            await _productoraRepository.AddAsync(productora);
        }

        public async Task Delete(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);

            await _productoraRepository.DeleteAsync(productora);
        }

        public async Task<ProductoraViewModel> GetByIdGeneroViewModel(int Id)
        {
            var productora = await _productoraRepository.GetByIdAsync(Id);

            ProductoraViewModel pm = new();

            pm.Id = productora.Id;
            pm.Nombre = productora.Nombre;

            return pm;
        }
    }
}
