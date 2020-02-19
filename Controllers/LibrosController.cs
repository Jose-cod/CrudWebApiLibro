using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudLibrosApi.Data;
using CrudLibrosApi.Model;

namespace CrudLibrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibroContext _context;
        public LibrosController(LibroContext contexto)
        {
            _context = contexto;
        }


        //Petición tipo Get:api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibroItems()
        {
            return await _context.LibroItems.ToListAsync();
        }
        //petición tipo get de un solo registro tipo: api/libros/4
        [HttpGet("{Id}")]
        public async Task<ActionResult<Libro>> GetLibroItem(int id) {
            var libroItem = await _context.LibroItems.FindAsync(id);
            if (libroItem == null)
            {
                return NotFound();
            }
            return libroItem;
        }
        // petición tipo POST api/libros
        //item guarda el modelo Libro
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibroItem(Libro item)
        {
            _context.LibroItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLibroItem), new { id = item.Id }, item);

        }
        //petición tipo PUT api/libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroItem(int id, Libro item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return _context.LibroItems.Any(e => e.Id == id);
        }
        //petición tipo DELETE: api/libros/2

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Libro>> DeleteLibro(int id)
        {
            var libro = await _context.LibroItems.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.LibroItems.Remove(libro);
            await _context.SaveChangesAsync();

            return libro;
        }

    }
}