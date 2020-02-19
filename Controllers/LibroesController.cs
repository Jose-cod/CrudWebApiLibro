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
    public class LibroesController : ControllerBase
    {
        private readonly LibroContext _context;

        public LibroesController(LibroContext context)
        {
            _context = context;
        }

        // GET: api/Libroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibroItems()
        {
            return await _context.LibroItems.ToListAsync();
        }

        // GET: api/Libroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.LibroItems.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libroes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

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

        // POST: api/Libroes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.LibroItems.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        // DELETE: api/Libroes/5
        [HttpDelete("{id}")]
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

        private bool LibroExists(int id)
        {
            return _context.LibroItems.Any(e => e.Id == id);
        }
    }
}
