using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.Repository
{
    internal class SerieRepository
    {
        private readonly Database.AppContext _dbContext;

        public SerieRepository(Database.AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Crud
        public async Task AddAsync(Serie serie)
        {
            await _dbContext.AddAsync(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UdapteAsync(Serie serie)
        {
            _dbContext.Entry(serie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Serie serie)
        {
            _dbContext.Set<Serie>().Remove(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetAllAsync()
        {
            return await _dbContext.Set<Serie>().ToListAsync();
        }

        public async Task<Serie> GetByIdAsync(int id)
        {

            return await _dbContext.Set<Serie>().FindAsync(id);

        }
        #endregion
    }
}
