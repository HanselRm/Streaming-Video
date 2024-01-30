using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AppContext: DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tablas
            modelBuilder.Entity<Genero>().ToTable("Productos");
            modelBuilder.Entity<Imagen>().ToTable("Imagenes");
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion
        }
    }
}
