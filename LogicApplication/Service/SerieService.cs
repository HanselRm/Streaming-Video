using Database.Models;
using LogicApplication.Repository;
using LogicApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogicApplication.Service
{
    public class SerieService
    {
        private readonly SerieRepository _serieRepository;
        private readonly GeneroRepository _generoRepository;
        private readonly ProductoraRepository _productoraRepository;


        public SerieService(Database.AppContext dbContex)
        {
            _serieRepository = new(dbContex);
            _generoRepository = new(dbContex);
            _productoraRepository = new(dbContex);
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
                    Imagenurl = serie.ImagenUrl,
                    GeneroS = nombreGeneroS

                };

                serieViewModelList.Add(serieViewModel);
            }

            return serieViewModelList;
        }
        public async Task<List<DetalleViewModel>> GetAllDetallesViewModel()
        {
            //Obtengo todas las series
            var serieList = await _serieRepository.GetAllAsync();
            var detalleViewModel = new List<DetalleViewModel>();

            var generoL = await _generoRepository.GetAllAsync();
            var productoraList = await _productoraRepository.GetAllAsync();

            foreach (var serie in serieList)
            {
                string nombreProductora = await BuscarNombreProductora(serie.IdProductora);
                string nombreGeneroP = await BuscarNombreGenero(serie.IdGeneroPrimario);
                string nombreGeneroS;

                if (serie.IdGeneroSecundario != null)
                {
                    nombreGeneroS = await BuscarNombreGenero((int)serie.IdGeneroSecundario);
                }

                else
                {
                    nombreGeneroS = "";
                }

                var detalleViewMod = new DetalleViewModel
                {
                    Id = serie.Id,
                    Name = serie.Name,
                    Enlace = serie.Enlace,
                    Productora = nombreProductora,
                    GeneroP = nombreGeneroP,
                    ImagenUrl = serie.ImagenUrl,
                    GeneroS = nombreGeneroS,
                    generoList = generoL,
                    productoraList = productoraList

                };

                detalleViewModel.Add(detalleViewMod);
            }

            return detalleViewModel;
        }

        public async Task Add(SaveSerieViewModel sm)
        {
            Serie serie = new();
            serie.Name = sm.Name;
            serie.IdGeneroPrimario = sm.IdGeneroPrimario;
            serie.IdProductora = sm.IdProductora;
            serie.IdGeneroSecundario = sm.IdGeneroSecundario;
            serie.Enlace = sm.Enlace;
            serie.ImagenUrl = sm.ImagenUrl;
            await _serieRepository.AddAsync(serie);
        }

        public async Task<SaveSerieViewModel> GetByIdGeneroViewModel(int Id)
        {
            var serie = await _serieRepository.GetByIdAsync(Id);

            SaveSerieViewModel sm = new();

            sm.Id = serie.Id;
            sm.Name = serie.Name;
            sm.Enlace = serie.Enlace;
            sm.ImagenUrl = serie.ImagenUrl;
            sm.IdGeneroPrimario = serie.IdGeneroPrimario;
            sm.IdGeneroSecundario = serie.IdGeneroSecundario;
            sm.IdProductora = serie.IdProductora;

            return sm;
        }


        public async Task Udapte(SaveSerieViewModel sm)
        {
            Serie serie = new();
            serie.Id = sm.Id;
            serie.Name = sm.Name;
            serie.IdGeneroPrimario = sm.IdGeneroPrimario;
            serie.IdGeneroSecundario = sm.IdGeneroSecundario;
            serie.IdProductora = sm.IdProductora;
            serie.ImagenUrl = sm.ImagenUrl;
            serie.Enlace = sm.Enlace;
            await _serieRepository.UdapteAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            await _serieRepository.DeleteAsync(serie);
        }

        public async Task<List<DetalleViewModel>> GetByName(string name)
        {
            //Obtengo todas las series filtradas
            var serieList = await _serieRepository.GetAllAsync();
            var seriesFiltradas = serieList.Where(s => s.Name.Contains(name)).ToList();

            var generoL = await _generoRepository.GetAllAsync();
            var productoraList = await _productoraRepository.GetAllAsync();


            var detalleList = new List<DetalleViewModel>();



            foreach (var serie in seriesFiltradas)
            {
                string nombreProductora = await BuscarNombreProductora(serie.IdProductora);
                string nombreGeneroP = await BuscarNombreGenero(serie.IdGeneroPrimario);
                string nombreGeneroS;

                if (serie.IdGeneroSecundario != null)
                {
                    nombreGeneroS = await BuscarNombreGenero((int)serie.IdGeneroSecundario);
                }

                else
                {
                    nombreGeneroS = "";
                }

                var detalleViewModel = new DetalleViewModel
                {
                    Id = serie.Id,
                    Name = serie.Name,
                    Enlace = serie.Enlace,
                    Productora = nombreProductora,
                    GeneroP = nombreGeneroP,
                    ImagenUrl = serie.ImagenUrl,
                    GeneroS = nombreGeneroS,
                    generoList = generoL,
                    productoraList = productoraList
                };

                detalleList.Add(detalleViewModel);
            }

            return detalleList;
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

    }
}
