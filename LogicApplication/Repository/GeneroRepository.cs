using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicApplication.Repository
{
    public class GeneroRepository
    {
        private readonly Database.AppContext _dbContext;

        public GeneroRepository(Database.AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Crud
            public async Task AddAsync(Genero genero)
            {
                await _dbContext.AddAsync(genero);
                await _dbContext.SaveChangesAsync();
            }

            public async Task UdapteAsync(Genero genero)
            {
                 _dbContext.Entry(genero).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            public async Task DeleteAsync(Genero genero)
            {
                 _dbContext.Set<Genero>().Remove(genero);
                await _dbContext.SaveChangesAsync();
            }

            public async Task<List<Genero>> GetAllAsync()
            {
                return await _dbContext.Set<Genero>().ToListAsync();
            }

            public async Task<Genero> GetByIdAsync(int id)
            {

                return await _dbContext.Set<Genero>().FindAsync(id);

            }
        #endregion
    }
}
