using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication.ViewModels
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe completar el campo")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe completar el campo")]
        public string Enlace { get; set; }
        [Required(ErrorMessage = "Debe completar el campo")]
        public int IdProductora { get; set; }
        [Required(ErrorMessage = "Debe completar el campo")]
        public int IdGeneroPrimario { get; set; }
        public int? IdGeneroSecundario { get; set; }
        [Required(ErrorMessage = "Debe completar el campo")]
        public string ImagenUrl { get; set; }
    }
}
