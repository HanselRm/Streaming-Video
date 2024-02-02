using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.Repository
{
    public class ImagenRepository
    {
        private readonly Database.AppContext _dbContext;

        public ImagenRepository(Database.AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Crud
        public async Task AddAsync(Imagen imagen)
        {
            await _dbContext.AddAsync(imagen);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UdapteAsync(Imagen imagen)
        {
            _dbContext.Entry(imagen).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Imagen imagen)
        {
            _dbContext.Set<Imagen>().Remove(imagen);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Imagen>> GetAllAsync()
        {
            return await _dbContext.Set<Imagen>().ToListAsync();
        }

        public async Task<Imagen> GetByIdAsync(int id)
        {

            return await _dbContext.Set<Imagen>().FindAsync(id);

        }
        #endregion
    }
}
