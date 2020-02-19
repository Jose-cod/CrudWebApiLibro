using CrudLibrosApi.Model;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLibrosApi.Data
{
    public class LibroContext:DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options):base(options) { }
        //Crear nuestro DB SET
        public DbSet<Libro> LibroItems { get;set; }
    }
}
