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
    public class ComentariosController : ControllerBase
    {
        private readonly CattleyaToursContext context;
        private readonly ILogger<PublicacionesController> logger;

        public ComentariosController(CattleyaToursContext _context, ILogger<PublicacionesController> _logger)
        {
            context = _context;
            logger = _logger;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
            return await context.Comentario.ToListAsync();
        }

        // GET: api/Comentario/publicacion/5/usuario/3
        [HttpGet("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Comentario>> GetComentario(int usuarioId, int publicacionId)
        {

            var comentario = await context.Comentario.FindAsync(usuarioId, publicacionId);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetReservaByUserId(int id)
        {
            return await context.Comentario.Include(x => x.Publicacion).Where(x => x.Usuario.Id == id).ToListAsync();
        }

        [HttpGet("publicacion/{id}")]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetReservaByPublicacionId(int id)
        {
            return await context.Comentario
            .Include(x => x.Usuario)
            .Where(x => x.Publicacion.Id == id)
            .Select(x => new ComentarioDTO()
            {
                Fecha = x.Fecha,
                Contenido = x.Contenido,
                Usuario = new UsuarioDTO()
                {
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


        // PUT: api/Comentarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<IActionResult> PutComentario(int usuarioId, int publicacionId, Comentario comentario)
        {
            if (usuarioId != comentario.UsuarioId || publicacionId != comentario.PublicacionId)
            {
                return BadRequest();
            }

            context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(usuarioId, publicacionId))
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

        // POST: api/Comentarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            context.Comentario.Add(comentario);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComentarioExists(comentario.UsuarioId, comentario.PublicacionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComentario", new { usuarioId = comentario.UsuarioId, publicacionId = comentario.PublicacionId }, comentario);
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Comentario>> DeleteComentario(int usuarioId, int publicacionId)
        {
            var comentario = await context.Comentario.FindAsync(usuarioId, publicacionId);
            if (comentario == null)
            {
                return NotFound();
            }

            context.Comentario.Remove(comentario);
            await context.SaveChangesAsync();

            return comentario;
        }

        private bool ComentarioExists(int usuarioId, int publicacionId)
        {
            return context.Comentario.Any(e => e.UsuarioId == usuarioId && e.PublicacionId == publicacionId);
        }
    }
}
