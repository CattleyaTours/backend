using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

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

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await context.Comentario.FindAsync(id);

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
                Id = x.Id,
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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.Id)
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
                if (!ComentarioExists(id))
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            context.Comentario.Add(comentario);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { id = comentario.Id }, comentario);
        }

        // DELETE: api/Comentarios/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comentario>> DeleteComentario(int id)
        {
            var comentario = await context.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            context.Comentario.Remove(comentario);
            await context.SaveChangesAsync();

            return comentario;
        }

        private bool ComentarioExists(int id)
        {
            return context.Comentario.Any(e => e.Id == id);
        }
    }
}