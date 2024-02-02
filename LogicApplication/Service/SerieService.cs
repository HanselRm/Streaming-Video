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
    public class SerieService
    {
        private readonly SerieRepository _serieRepository;
        private readonly GeneroRepository _generoRepository;
        private readonly ProductoraRepository _productoraRepository;
        private readonly ImagenRepository _imagenRepository;

        public SerieService(Database.AppContext dbContex)
        {
            _serieRepository = new(dbContex);
            _generoRepository = new(dbContex);
            _productoraRepository = new(dbContex);
            _imagenRepository = new(dbContex);
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            //Obtengo todas las series
            var serieList = await _serieRepository.GetAllAsync();
            var serieViewModelList = new List<SerieViewModel>();

            foreach (var serie in serieList)
            {
                string nombreProductora = await BuscarNombreProductora(serie.IdProductora);
                string nombreGeneroP = await BuscarNombreGenero(serie.IdGeneroPrimario);
                string rutaImagen = await BuscarRutaImagen(serie.IdImagen);
                string nombreGeneroS;

                if (serie.IdGeneroSecundario != null)
                {
                    nombreGeneroS = await BuscarNombreGenero((int)serie.IdGeneroSecundario);
                }

                else
                {
                    nombreGeneroS = "";
                }

                var serieViewModel = new SerieViewModel
                {
                    Id = serie.Id,
                    Name = serie.Name,
                    Enlace = serie.Enlace,
                    Productora = nombreProductora,
                    GeneroP = nombreGeneroP,
                    Imagen = rutaImagen,
                    GeneroS = nombreGeneroS

                };

                serieViewModelList.Add(serieViewModel);
            }

            return serieViewModelList;
        }


        public async Task<String> BuscarNombreGenero(int id)
        {
            Genero genero = await _generoRepository.GetByIdAsync(id);
            return genero.Nombre;
        }

        public async Task<String> BuscarNombreProductora(int id)
        {
            Productora productora = await _productoraRepository.GetByIdAsync(id);
            return productora.Nombre;
        }
        public async Task<String> BuscarRutaImagen(int id)
        {
            Imagen imagen = await _imagenRepository.GetByIdAsync(id);
            string ruta = $"/imagenes/{imagen.Name}";
            return ruta;
        }
    }
}
