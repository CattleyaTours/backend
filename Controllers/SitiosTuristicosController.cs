using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitiosTuristicosController : ControllerBase
    {
        private readonly CattleyaToursContext context;

        private readonly ILogger<SitiosTuristicosController> logger;

        public SitiosTuristicosController(CattleyaToursContext _context, ILogger<SitiosTuristicosController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        // GET: api/SitiosTuristicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SitioTuristico>>> GetSitiosTuristicos()
        {
            return await context.SitiosTuristicos.ToListAsync();
        }

        // GET: api/SitiosTuristicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SitioTuristico>> GetSitioTuristico(int id)
        {
            var sitioTuristico = await context.SitiosTuristicos.FindAsync(id);

            if (sitioTuristico == null)
            {
                return NotFound();
            }

            return sitioTuristico;
        }

        // GET: api/SitiosTuristicos/propietario/5
        [HttpGet("propietario/{propietarioId}")]
        public async Task<ActionResult<IEnumerable<SitioTuristico>>> GetSitiosByPropietario(int propietarioId)
        {
            return await context.SitiosTuristicos.Where(x => x.PropietarioId == propietarioId).ToListAsync();
        }

        // GET: api/SitiosTuristicos/region/{region}
        [HttpGet("region/{region}")]
        public async Task<ActionResult<IEnumerable<SitioTuristico>>> GetSitiosByRegion(string region)
        {
            return await context.SitiosTuristicos.Where(x => x.Region == region).ToListAsync();
        }

        // PUT: api/SitiosTuristicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitioTuristico(int id, SitioTuristico sitioTuristico)
        {
            if (id != sitioTuristico.Id)
            {
                return BadRequest();
            }

            context.Entry(sitioTuristico).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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
        [HttpPost]
        public async Task<ActionResult<SitioTuristico>> PostSitioTuristico(SitioTuristico sitioTuristico)
        {

            context.SitiosTuristicos.Add(sitioTuristico);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSitioTuristico", new { id = sitioTuristico.Id }, sitioTuristico);
        }

        // DELETE: api/SitiosTuristicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SitioTuristico>> DeleteSitioTuristico(int id)
        {
            var sitioTuristico = await context.SitiosTuristicos.FindAsync(id);
            if (sitioTuristico == null)
            {
                return NotFound();
            }

            context.SitiosTuristicos.Remove(sitioTuristico);
            await context.SaveChangesAsync();

            return sitioTuristico;
        }

        private bool SitioTuristicoExists(int id)
        {
            return context.SitiosTuristicos.Any(e => e.Id == id);
        }
    }
}
