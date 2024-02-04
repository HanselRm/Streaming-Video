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

        public async Task Udapte(GeneroViewModel gm)
        {
            Genero genero = new();
            genero.Id = gm.Id;
            genero.Nombre = gm.Nombre;
            await _generoRepository.UdapteAsync(genero);
        }
        public async Task Add(GeneroViewModel gm)
        {
            Genero genero = new();
            genero.Nombre = gm.Nombre;
            await _generoRepository.AddAsync(genero);
        }

        public async Task Delete(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            
            await _generoRepository.DeleteAsync(genero);
        }

        public async Task<GeneroViewModel> GetByIdGeneroViewModel(int Id)
        {
            var genero = await _generoRepository.GetByIdAsync(Id);

            GeneroViewModel gm = new();

            gm.Id = genero.Id;
            gm.Nombre = genero.Nombre;

            return gm;
        }
    }
}
