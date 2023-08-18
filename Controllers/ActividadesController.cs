using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ActividadesController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public ActividadesController(CattleyaToursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetActividades(string? nombre, int? categoriaActividadId, int? publicacionId)
        {
            var query = _context.Actividades.AsQueryable();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(x => x.Nombre == nombre);
            }
            if (categoriaActividadId.HasValue)
            {
                query = query.Where(x => x.CategoriaActividadId == categoriaActividadId);
            }
            if (publicacionId.HasValue)
            {
                query = query.Where(x => x.PublicacionId == publicacionId);
            }

            var data = await query.ToListAsync();

            return Ok(data);
        }     

        [HttpGet]
        public async Task<ActionResult> GetActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(actividad);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateActividad(Actividad actividad)
        {
            var oldActividad = await _context.Actividades.FindAsync(actividad.Id);

            if (oldActividad == null)
            {
                return NotFound();
            }

            oldActividad.Nombre = actividad.Nombre;
            oldActividad.CategoriaActividadId = actividad.CategoriaActividadId;
            oldActividad.PublicacionId = actividad.PublicacionId;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateActividad(Actividad actividad)
        {
            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();

            return Created("CreateActividad", new { id = actividad.Id });
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
