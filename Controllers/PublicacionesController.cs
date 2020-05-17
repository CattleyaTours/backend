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
    public class PublicacionesController : ControllerBase
    {
        private readonly CattleyaToursContext context;

        private readonly ILogger<PublicacionesController> logger;

        public PublicacionesController(CattleyaToursContext _context, ILogger<PublicacionesController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicaciones()
        {
            return await context.Publicaciones.ToListAsync();
        }

        // GET: api/Publicaciones/region/andina
        [HttpGet("region/{region}")]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicacionesByRegion(string region)
        {
            return await context.Publicaciones.Include(x => x.Sitio).Where(x => x.Sitio.Region == region).ToListAsync();
        }


        // GET: api/Publicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicacion>> GetPublicacion(int id)
        {
            var publicacion = await context.Publicaciones.FindAsync(id);

            if (publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }



        // PUT: api/Publicaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacion(int id, Publicacion publicacion)
        {
            if (id != publicacion.Id)
            {
                return BadRequest();
            }

            context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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

        // POST: api/Publicaciones
        [HttpPost]
        public async Task<ActionResult<Publicacion>> PostPublicacion(Publicacion publicacion)
        {
            context.Publicaciones.Add(publicacion);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacion", new { id = publicacion.Id }, publicacion);
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publicacion>> DeletePublicacion(int id)
        {
            var publicacion = await context.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            context.Publicaciones.Remove(publicacion);
            await context.SaveChangesAsync();

            return publicacion;
        }

        private bool PublicacionExists(int id)
        {
            return context.Publicaciones.Any(e => e.Id == id);
        }
    }
}
