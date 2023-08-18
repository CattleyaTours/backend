using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CategoriasActividadController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public CategoriasActividadController(CattleyaToursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoriasActividad()
        {
            var categorias = await _context.CategoriasActividad.ToListAsync();
            return Ok(categorias);
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoriaActividad(int id)
        {
            var categoriaActividad = await _context.CategoriasActividad.FindAsync(id);

            if (categoriaActividad == null)
            {
                return NotFound();
            }

            return Ok(categoriaActividad);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateCategoriaActividad(CategoriaActividad categoriaActividad)
        {
            var oldCategoriaActividad = await _context.CategoriasActividad.FindAsync(categoriaActividad.Id);
            if (oldCategoriaActividad == null)
            {
                return NotFound();
            }

            oldCategoriaActividad.Nombre = categoriaActividad.Nombre;
            oldCategoriaActividad.Icono = categoriaActividad.Icono;
            oldCategoriaActividad.Descripcion = categoriaActividad.Descripcion;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateCategoriaActividad(CategoriaActividad categoriaActividad)
        {
            _context.CategoriasActividad.Add(categoriaActividad);
            await _context.SaveChangesAsync();

            return Created("GetCategoriaActividad", new { id = categoriaActividad.Id });
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteCategoriaActividad(int id)
        {
            var categoriaActividad = await _context.CategoriasActividad.FindAsync(id);
            if (categoriaActividad == null)
            {
                return NotFound();
            }

            _context.CategoriasActividad.Remove(categoriaActividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
