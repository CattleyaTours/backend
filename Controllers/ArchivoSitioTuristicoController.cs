using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using Microsoft.AspNetCore.StaticFiles;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class Archivo_SitioTuristicoController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public Archivo_SitioTuristicoController(CattleyaToursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetArchivosSitioTuristico(bool random, int? count, int? sitioId, string? mimetype)
        {
            var query = _context.ArchivosSitioTuristico.AsQueryable();
            if (!string.IsNullOrWhiteSpace(mimetype))
            {
                query = query.Where(x => x.MimeType == mimetype);
            }
            if (sitioId.HasValue)
            {
                query = query.Where(x => x.SitioId == sitioId);
            }
            if (random)
            {
                var rnd = new Random();
                query = query.OrderBy(x => rnd.Next());
            }
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            var data = await query.ToListAsync();

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult> GetArchivoSitioTuristico(int id)
        {
            var archivoSitioTuristico = await _context.ArchivosSitioTuristico.FindAsync(id);

            if (archivoSitioTuristico == null)
            {
                return NotFound();
            }
            return File(archivoSitioTuristico.Bytes, archivoSitioTuristico.MimeType);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateArchivoSitioTuristico([FromForm] IFormFile file, [FromForm] int sitioId)
        {
            using (var uploadedFile = new MemoryStream())
            {
                await file.CopyToAsync(uploadedFile);

                new FileExtensionContentTypeProvider().TryGetContentType(file.FileName, out string? mimeType); ;

                if (string.IsNullOrEmpty(mimeType))
                {
                    return BadRequest("El tipo de archivo no es valido");

                }

                if (file.Length < 4194304)
                {
                    return BadRequest("El archivo es demasiado grande");
                }

                uploadedFile.Position = 0;
                var archivo = new ArchivoSitioTuristico()
                {
                    MimeType = mimeType,
                    Bytes = uploadedFile.ToArray(),
                    SitioId = sitioId
                };

                _context.ArchivosSitioTuristico.Add(archivo);
                await _context.SaveChangesAsync();

                return Created("CreateArchivoSitioTuristico", new { id = archivo.Id });
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteArchivoSitioTuristico(int id)
        {
            var archivoSitioTuristico = await _context.ArchivosSitioTuristico.FindAsync(id);
            if (archivoSitioTuristico == null)
            {
                return NotFound();
            }

            _context.ArchivosSitioTuristico.Remove(archivoSitioTuristico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}