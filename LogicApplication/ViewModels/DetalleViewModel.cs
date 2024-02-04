using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.ViewModels
{
    public class DetalleViewModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Enlace { get; set; }
            public string Productora { get; set; }
            public string? GeneroP { get; set; }
            public string? GeneroS { get; set; }
            public string ImagenUrl { get; set; }

            public List<Genero>? generoList { get; set; }

            public List<Productora>? productoraList { get; set; }
        
    }
}
