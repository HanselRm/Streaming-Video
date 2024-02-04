using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Enlace { get; set; }
        public string ImagenUrl { get; set; }
        public int IdProductora { get; set; }
        public int IdGeneroPrimario { get; set; }
        public int? IdGeneroSecundario { get; set; }
        

        public Productora productora { get; set; }
        public Genero GeneroPrimario { get; set; }
        public Genero? GeneroSecundario { get; set; }
        


    }
}
