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

        public SerieService(Database.AppContext dbContex)
        {
            _serieRepository = new(dbContex);
            _generoRepository = new(dbContex);
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            //Obtengo todas las series
            var serieList = await _serieRepository.GetAllAsync();
            var serieViewModelList = new List<SerieViewModel>();

            foreach (var serie in serieList)
            {
                Genero generoP = await _generoRepository.GetByIdAsync(serie.IdGeneroPrimario);
                Genero generoS = null;

                if (serie.IdGeneroSecundario != null)
                {
                    generoS = await _generoRepository.GetByIdAsync((int)serie.IdGeneroSecundario);
                }
                
                string nombreGeneroP = generoP.Nombre;
                string nombreGeneroS;

                
                if (generoS != null)
                {
                    nombreGeneroS = generoS.Nombre;
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
                    Productora = serie.IdProductora.ToString(),
                    GeneroP = nombreGeneroP,
                    GeneroS = nombreGeneroS

                };

                serieViewModelList.Add(serieViewModel);
            }

            return serieViewModelList;
        }


        public async Task<Genero> BuscarGenero(int id)
        {
            Genero genero = await _generoRepository.GetByIdAsync(id);
            return genero;
        }
    }
}
