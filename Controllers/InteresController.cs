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
    public class InteresController : ControllerBase
    {
        private readonly CattleyaToursContext context;

        private readonly ILogger<InteresController> logger;

        public InteresController(CattleyaToursContext _context, ILogger<InteresController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        // GET: api/Interes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interes>>> GetInteres()
        {
            return await context.Interes.ToListAsync();
        }

        // GET: api/Interes/publicacion/5/usuario/3
        [HttpGet("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Interes>> GetInteres(int usuarioId, int publicacionId)
        {
            var interes = await context.Interes.FindAsync(usuarioId,publicacionId);

            if (interes == null)
            {
                return NotFound();
            }

            return interes;
        }

        //GET: api/Interes/usuario/3
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<IEnumerable<Interes>>> GetReservaByUserId(int id)
        {
            return await context.Interes.Include(x => x.Publicacion).Where(x => x.Usuario.Id == id).ToListAsync();
        }

        [HttpGet("publicacion/{id}")]
        public async Task<ActionResult<IEnumerable<InteresDTO>>> GetInteresadosByPublicacionId(int id)
        {
            return  await context.Interes
            .Include(x => x.Usuario)
            .Where(x => x.Publicacion.Id == id)
            .Select( x => new InteresDTO(){ 
                Id = x.Id,
                Fecha = x.Fecha,
                Usuario = new UsuarioDTO(){
                    Id = x.Usuario.Id,
                    Email = x.Usuario.Email,
                    Username = x.Usuario.Username,
                    Nombres = x.Usuario.Nombres,
                    Telefono = x.Usuario.Telefono,
                    Nacionalidad = x.Usuario.Nacionalidad,
                    RolId = x.Usuario.RolId
                }
            }).ToListAsync();
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

            context.Entry(interes).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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
            context.Interes.Add(interes);
            try
            {
                await context.SaveChangesAsync();
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
            var interes = await context.Interes.FindAsync(usuarioId,publicacionId);
            if (interes == null)
            {
                return NotFound();
            }

            context.Interes.Remove(interes);
            await context.SaveChangesAsync();

            return interes;
        }

        private bool InteresExists(int id)
        {
            return context.Interes.Any(e => e.UsuarioId == id);
        }
    }
}
