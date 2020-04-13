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
    public class RegionesController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public RegionesController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/Regiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegiones()
        {
            return await _context.Regiones.ToListAsync();
        }

        // GET: api/Regiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var region = await _context.Regiones.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/Regiones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Regiones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            _context.Regiones.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.Id }, region);
        }

        // DELETE: api/Regiones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Region>> DeleteRegion(int id)
        {
            var region = await _context.Regiones.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regiones.Remove(region);
            await _context.SaveChangesAsync();

            return region;
        }

        private bool RegionExists(int id)
        {
            return _context.Regiones.Any(e => e.Id == id);
        }
    }
}
