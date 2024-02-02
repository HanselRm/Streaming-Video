using LogicApplication.Repository;
using LogicApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.Service
{
    public class ImagenService
    {
        private readonly ImagenRepository _imagenRepository;

        public ImagenService(Database.AppContext dbContex)
        {
            _imagenRepository = new(dbContex);
        }

        public async Task<List<ImagenViewModel>> GetAllViewModel()
        {
            var imagenlist = await _imagenRepository.GetAllAsync();
            return imagenlist.Select(Imagen => new ImagenViewModel
            {
                Id = Imagen.Id,
                Ruta = Imagen.Ruta,
                Name = Imagen.Name
            }).ToList();
        }
    }
}

