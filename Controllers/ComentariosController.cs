using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ComentariosController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public ComentariosController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult> GetComentarios(string? username, int? publicacionId, DateTime? fechaInicial, DateTime? fechaFinal, string? contenido)
        {
            var query = _context.Comentarios.AsQueryable();

            if (!string.IsNullOrEmpty(username))
            {
                query = query.Include(x => x.Publicacion).Where(x => x.Username == username);
            }
            if (publicacionId.HasValue)
            {
                query = query.Include(x => x.Usuario).Where(x => x.PublicacionId == publicacionId);
            }
            if (fechaInicial.HasValue)
            {
                query = query.Where(x => x.FechaCreacion >= fechaInicial);
            }
            if (fechaFinal.HasValue)
            {
                query = query.Where(x => x.FechaCreacion <= fechaFinal);
            }
            if(!string.IsNullOrEmpty(contenido))
            {
                query = query.Where(x => x.Contenido.Contains(contenido));
            }

            var comentarios = await query.ToListAsync();
            return Ok(comentarios);
        }

        [HttpGet]
        public async Task<ActionResult> GetComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateComentario(Comentario comentario)
        {
            var oldComentario = await _context.Comentarios.FindAsync(comentario.Id);

            if (oldComentario == null)
            {
                return NotFound();
            }

            oldComentario.FechaCreacion = DateTime.Now;
            oldComentario.Contenido = comentario.Contenido;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostComentario(Comentario comentario)
        {
            comentario.FechaCreacion = DateTime.Now;
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return Created("GetComentario", new { id = comentario.Id });
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}