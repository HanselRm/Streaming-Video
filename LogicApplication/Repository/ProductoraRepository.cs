using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.Repository
{
    public class ProductoraRepository
    {
        private readonly Database.AppContext _dbContext;

        public ProductoraRepository(Database.AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Crud
        public async Task AddAsync(Productora productora)
        {
            await _dbContext.AddAsync(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UdapteAsync(Productora productora)
        {
            _dbContext.Entry(productora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Productora productora)
        {
            _dbContext.Set<Productora>().Remove(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Productora>> GetAllAsync()
        {
            return await _dbContext.Set<Productora>().ToListAsync();
        }

        public async Task<Productora> GetByIdAsync(int id)
        {

            return await _dbContext.Set<Productora>().FindAsync(id);

        }
        #endregion
    }
}
