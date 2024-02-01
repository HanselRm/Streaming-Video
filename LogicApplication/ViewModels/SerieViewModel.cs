using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.ViewModels
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Enlace { get; set; }
        public string Productora { get; set; }
        public string GeneroP { get; set; }
        public string? GeneroS { get; set; }
        public string Imagen { get; set; }
    }
}
