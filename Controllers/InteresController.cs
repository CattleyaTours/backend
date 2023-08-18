using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class InteresController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public InteresController(CattleyaToursContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetInteresesByPublicacion(int publicacionId, DateTime? fechaInicial, DateTime? fechaFinal)
        {
            var query = _context.Intereses.Include(x => x.Usuario).Where(x => x.PublicacionId == publicacionId).AsQueryable();

            if (fechaInicial.HasValue)
            {
                query = query.Where(x => x.FechaCreacion >= fechaInicial);
            }
            if (fechaFinal.HasValue)
            {
                query = query.Where(x => x.FechaCreacion <= fechaFinal);
            }

            var data = await query.ToListAsync();
            return Ok(data);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetInteresesByUser(string username, DateTime? fechaInicial, DateTime? fechaFinal)
        {
            var query = _context.Intereses.Include(x => x.Publicacion).Where(x => x.Username == username).AsQueryable();

            if (fechaInicial.HasValue)
            {
                query = query.Where(x => x.FechaCreacion >= fechaInicial);
            }
            if (fechaFinal.HasValue)
            {
                query = query.Where(x => x.FechaCreacion <= fechaFinal);
            }

            var data = await query.ToListAsync();
            return Ok(data);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateInteres(Interes interes)
        {

            if (_context.Intereses.Any(x => interes.Username == x.Username && interes.PublicacionId == x.PublicacionId))
            {
                return Conflict();
            }

            _context.Intereses.Add(interes);
            await _context.SaveChangesAsync();

            return Created("CreateInteres", interes);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteInteres(string username, int publicacionId)
        {
            var interes = await _context.Intereses.FindAsync(username,publicacionId);
            if (interes == null)
            {
                return NotFound();
            }

            _context.Intereses.Remove(interes);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
