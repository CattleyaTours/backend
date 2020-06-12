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
    public class ActividadController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public ActividadController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/Actividad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividades()
        {
            return await _context.Actividades.ToListAsync();
        }

        // GET: api/Actividad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // PUT: api/Actividad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
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

        // POST: api/Actividad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Actividad>> PostActividad(Actividad actividad)
        {
            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividad", new { id = actividad.Id }, actividad);
        }

        // DELETE: api/Actividad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actividad>> DeleteActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();

            return actividad;
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(e => e.Id == id);
        }
    }
}
