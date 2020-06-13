using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteresController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public InteresController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/Interes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interes>>> GetInteres()
        {
            return await _context.Interes.ToListAsync();
        }

        // GET: api/Interes/publicacion/5/usuario/3
        [HttpGet("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Interes>> GetInteres(int usuarioId, int publicacionId)
        {
            var interes = await _context.Interes.FindAsync(usuarioId,publicacionId);

            if (interes == null)
            {
                return NotFound();
            }

            return interes;
        }

        // PUT: api/Interes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteres(int id, Interes interes)
        {
            if (id != interes.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(interes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteresExists(id))
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

        // POST: api/Interes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Interes>> PostInteres(Interes interes)
        {
            _context.Interes.Add(interes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InteresExists(interes.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInteres", new { id = interes.UsuarioId }, interes);
        }

        // DELETE: api/Interes/publicacion/5/usuario/3
        [HttpDelete("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Interes>> DeleteInteres(int usuarioId, int publicacionId)
        {
            var interes = await _context.Interes.FindAsync(usuarioId,publicacionId);
            if (interes == null)
            {
                return NotFound();
            }

            _context.Interes.Remove(interes);
            await _context.SaveChangesAsync();

            return interes;
        }

        private bool InteresExists(int id)
        {
            return _context.Interes.Any(e => e.UsuarioId == id);
        }
    }
}
