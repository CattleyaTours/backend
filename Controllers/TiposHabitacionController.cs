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
    public class TiposHabitacionController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public TiposHabitacionController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/TiposHabitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetTiposHabitacion()
        {
            return await _context.TiposHabitacion.ToListAsync();
        }

        // GET: api/TiposHabitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoHabitacion>> GetTipoHabitacion(int id)
        {
            var tipoHabitacion = await _context.TiposHabitacion.FindAsync(id);

            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return tipoHabitacion;
        }

        // PUT: api/TiposHabitacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoHabitacion(int id, TipoHabitacion tipoHabitacion)
        {
            if (id != tipoHabitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoHabitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoHabitacionExists(id))
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

        // POST: api/TiposHabitacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoHabitacion>> PostTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
            _context.TiposHabitacion.Add(tipoHabitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoHabitacion", new { id = tipoHabitacion.Id }, tipoHabitacion);
        }

        // DELETE: api/TiposHabitacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoHabitacion>> DeleteTipoHabitacion(int id)
        {
            var tipoHabitacion = await _context.TiposHabitacion.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            _context.TiposHabitacion.Remove(tipoHabitacion);
            await _context.SaveChangesAsync();

            return tipoHabitacion;
        }

        private bool TipoHabitacionExists(int id)
        {
            return _context.TiposHabitacion.Any(e => e.Id == id);
        }
    }
}
