using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class SitiosTuristicosController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public SitiosTuristicosController(CattleyaToursContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetSitiosTuristicos(string? descripcion, string? nombre, string? region, string? departamento, string? municipio)
        {
            var data = await GetSitiosTuristicosFiltered(descripcion, nombre, region, departamento, municipio, null);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetSitioTuristico(int id)
        {
            var sitioTuristico = await _context.SitiosTuristicos
                .Include(x => x.Imagenes)
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(sitioTuristico);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetSitiosTuristicosByUser(string propietario, string? descripcion, string? nombre, string? region, string? departamento, string? municipio)
        {
            var data = await GetSitiosTuristicosFiltered(descripcion, nombre, region, departamento, municipio, propietario);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateSitioTuristico(SitioTuristico sitioTuristico)
        {
            var oldSitioTuristico = await _context.SitiosTuristicos.FindAsync(sitioTuristico.Id);
            if (oldSitioTuristico == null)
            {
                return NotFound();
            }

            oldSitioTuristico.Descripcion = sitioTuristico.Descripcion;
            oldSitioTuristico.Nombre = sitioTuristico.Nombre;
            oldSitioTuristico.Region = sitioTuristico.Region;
            oldSitioTuristico.Municipio = sitioTuristico.Municipio;
            oldSitioTuristico.Departamento = sitioTuristico.Departamento;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SitioTuristico>> CreateSitioTuristico(SitioTuristico sitioTuristico)
        {
            _context.SitiosTuristicos.Add(sitioTuristico);
            await _context.SaveChangesAsync();

            return Created("CreateSitioTuristico", new { id = sitioTuristico.Id });
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<SitioTuristico>> DeleteSitioTuristico(int id)
        {
            var sitioTuristico = await _context.SitiosTuristicos.FindAsync(id);
            if (sitioTuristico == null)
            {
                return NotFound();
            }

            _context.SitiosTuristicos.Remove(sitioTuristico);
            await _context.SaveChangesAsync();

            return sitioTuristico;
        }

        private async Task<List<SitioTuristico>> GetSitiosTuristicosFiltered(string? descripcion, string? nombre, string? region, string? departamento, string? municipio, string? propietario)
        {
            var query = _context.SitiosTuristicos.Include(x => x.Imagenes).AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(x => x.Nombre != null && x.Nombre.Contains(nombre));
            }

            if (!string.IsNullOrEmpty(descripcion))
            {
                query = query.Where(x => x.Descripcion != null && x.Descripcion.Contains(descripcion));
            }

            if (!string.IsNullOrEmpty(propietario))
            {
                query = query.Where(x => x.PropietarioUsername == propietario);
            }

            if (!string.IsNullOrEmpty(region))
            {
                query = query.Where(x => x.Region == region);
            }

            if (!string.IsNullOrEmpty(departamento))
            {
                query = query.Where(x => x.Departamento == departamento);
            }

            if (!string.IsNullOrEmpty(municipio))
            {
                query = query.Where(x => x.Municipio == municipio);
            }

            return await query.ToListAsync();
        }
    }
}
