using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLibrosApi.Model
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Año { get; set; }
        public string Editorial { get; set; }
        public string Isbn { get; set; }
    }
}
