using LogicApplication.Repository;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicApplication.ViewModels;
using Database.Models;

namespace LogicApplication.Service
{
    public class GeneroService
    {
        private readonly GeneroRepository _generoRepository;

        public GeneroService(Database.AppContext dbContex)
        {
            _generoRepository = new(dbContex);
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generolist = await _generoRepository.GetAllAsync();
            return generolist.Select(Genero => new GeneroViewModel
            {
                Id = Genero.Id,
                Nombre = Genero.Nombre
            }).ToList();
        }
    }
}
