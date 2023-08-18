using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class PublicacionesController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public PublicacionesController(CattleyaToursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetPublicaciones(string? titulo, string? descripcion, int? precioMinimo, int? precioMaximo, string? propietario, int? sitioId, string? region, int? categoriaActividadId)
        {
            var query = _context.Publicaciones.AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
            {
                query = query.Where(x => x.Titulo.Contains(titulo));
            }

            if (!string.IsNullOrEmpty(descripcion))
            {
                query = query.Where(x => x.Descripcion.Contains(descripcion));
            }

            if (!string.IsNullOrEmpty(propietario))
            {
                query = query.Where(x => x.PropietarioUsername == propietario);
            }

            if (!string.IsNullOrEmpty(region))
            {
                query = query.Include(x => x.Sitio).Where(x => x.Sitio != null && x.Sitio.Region == region);
            }

            if (precioMinimo.HasValue)
            {
                query = query.Where(x => x.Precio >= precioMinimo.Value);                
            }

            if (precioMaximo.HasValue)
            {
                query = query.Where(x => x.Precio <= precioMaximo.Value);
            }

            if (sitioId.HasValue)
            {
                query = query.Where(x => x.SitioId == sitioId);
            }

            if (categoriaActividadId.HasValue)
            {
                query = query.Include(x => x.Actividades).Where(x => x.Actividades != null && x.Actividades.Any(y => y.CategoriaActividadId == categoriaActividadId));
            }

            var data = await query.ToListAsync();

            return Ok(data);
        }        

        [HttpGet]
        public async Task<ActionResult> GetPublicacion(int id)
        {
            var publicacion = await _context.Publicaciones
                .Include(x => x.Actividades)
                .ThenInclude(x=>x.CategoriaActividad)
                .Include(x=>x.Propietario)
                .Include(x=>x.Sitio)
                .FirstAsync(x => x.Id == id);

            if (publicacion == null)
            {
                return NotFound();
            }

            return Ok(publicacion);
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdatePublicacion(Publicacion publicacion)
        {
            var oldPublicacion = await _context.Publicaciones.FindAsync(publicacion.Id);
            if (oldPublicacion == null)
            {
                return NotFound();
            }

            oldPublicacion.Descripcion = publicacion.Descripcion;
            oldPublicacion.Titulo = publicacion.Titulo;
            oldPublicacion.Precio = publicacion.Precio;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreatePublicacion(Publicacion publicacion)
        {
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();

            return Created("CreatePublicacion", new { id = publicacion.Id });
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeletePublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
