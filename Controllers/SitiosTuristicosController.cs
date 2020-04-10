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
    public class SitiosTuristicosController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public SitiosTuristicosController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/SitiosTuristicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SitioTuristico>>> GetSitiosTuristicos()
        {
            return await _context.SitiosTuristicos.ToListAsync();
        }

        // GET: api/SitiosTuristicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SitioTuristico>> GetSitioTuristico(int id)
        {
            var sitioTuristico = await _context.SitiosTuristicos.FindAsync(id);

            if (sitioTuristico == null)
            {
                return NotFound();
            }

            return sitioTuristico;
        }

        // PUT: api/SitiosTuristicos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitioTuristico(int id, SitioTuristico sitioTuristico)
        {
            if (id != sitioTuristico.Id)
            {
                return BadRequest();
            }

            _context.Entry(sitioTuristico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitioTuristicoExists(id))
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

        // POST: api/SitiosTuristicos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SitioTuristico>> PostSitioTuristico(SitioTuristico sitioTuristico)
        {
            
            _context.SitiosTuristicos.Add(sitioTuristico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSitioTuristico", new { id = sitioTuristico.Id }, sitioTuristico);
        }

        // DELETE: api/SitiosTuristicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SitioTuristico>> DeleteSitioTuristico(int id)
        {
            var sitioTuristico = await _context.SitiosTuristicos.FindAsync(id);
            if (sitioTuristico == null)
            {
                return NotFound();
            }

            _context.SitiosTuristicos.Remove(sitioTuristico);
            await _context.SaveChangesAsync();

            return sitioTuristico;
        }

        private bool SitioTuristicoExists(int id)
        {
            return _context.SitiosTuristicos.Any(e => e.Id == id);
        }
    }
}
