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
        
        public AppContext(DbContextOptions<AppContext> options)
        : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tablas
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Imagen>().ToTable("Imagenes");
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion

            #region "primary key"
            modelBuilder.Entity<Genero>().HasKey(Genero => Genero.Id);
            modelBuilder.Entity<Serie>().HasKey(Serie => Serie.Id);
            modelBuilder.Entity<Imagen>().HasKey(Imagen => Imagen.Id);
            modelBuilder.Entity<Productora>().HasKey(Productora => Productora.Id);
            #endregion

            #region relaciones
            modelBuilder.Entity<Serie>()
                .HasOne(s => s.GeneroPrimario)
                .WithMany(g => g.SeriesPrimarias)
                .HasForeignKey(s => s.IdGeneroPrimario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(G => G.GeneroSecundario)
                .WithMany(g => g.SeriesSecundarias)
                .HasForeignKey(s => s.IdGeneroSecundario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(p => p.Series)
                .WithOne(S => S.productora)
                .HasForeignKey(s => s.IdProductora)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne<Imagen>(s => s.Imagen)
                .WithMany()
                .HasForeignKey(s => s.IdImagen)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
