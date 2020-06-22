using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Archivo_SitioTuristicoController : ControllerBase
    {
        private readonly CattleyaToursContext _context;
        private readonly ILogger<Archivo_SitioTuristicoController> logger;

        public Archivo_SitioTuristicoController(CattleyaToursContext context, ILogger<Archivo_SitioTuristicoController> _logger)
        {
            _context = context;
            logger = _logger;
        }

        // GET: api/Archivos_SitioTuristico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivo_SitioTuristico>>> GetArchivos_SitioTuristico()
        {
            return await _context.Archivos_SitioTuristico.ToListAsync();
        }

        // GET: api/Archivos_SitioTuristico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivo_SitioTuristico>> GetArchivo_SitioTuristico(int id)
        {
            var archivo_SitioTuristico = await _context.Archivos_SitioTuristico.FindAsync(id);

            if (archivo_SitioTuristico == null)
            {
                return NotFound();
            }
            return File(archivo_SitioTuristico.info_file, GetMimeTypes()[archivo_SitioTuristico.ext]); ;
        }

        // GET: api/Archivos_SitioTuristico/sitio/5/random
        [HttpGet("sitio/{id}/random")]
        public async Task<ActionResult<Archivo_SitioTuristico>> GetArchivo_SitioTuristicoRandomBySitio(int id)
        {
            var archivos_SitioTuristico = await _context.Archivos_SitioTuristico.Where(x => x.SitioId == id).ToListAsync();
            if (archivos_SitioTuristico.Count < 1)
            {
                return NotFound();
            }

            Random rnd = new Random();
            int r = rnd.Next(archivos_SitioTuristico.Count);
            var archivo_SitioTuristico = archivos_SitioTuristico.ElementAt(r);

            return File(archivo_SitioTuristico.info_file, GetMimeTypes()[archivo_SitioTuristico.ext]); ;
        }

        // GET: api/Archivos_SitioTuristico/sitio/5/random
        [HttpGet("sitio/{id}/imagenes")]
        public async Task<ActionResult<int>> GetArchivos_SitioTuristico(int id)
        {
            var archivos_SitioTuristico = await _context.Archivos_SitioTuristico.Where(x => x.SitioId == id).ToListAsync();
            if (archivos_SitioTuristico.Count < 1)
            {
                return NotFound();
            }

            return archivos_SitioTuristico.Count ;
        }

        // GET: api/Archivos_SitioTuristico/sitio/5/1
        [HttpGet("sitio/{id}/{num}")]
        public async Task<ActionResult<Archivo_SitioTuristico>> GetArchivo_SitioTuristicoRandomByNum(int id, int num)
        {
            var archivos_SitioTuristico = await _context.Archivos_SitioTuristico.Where(x => x.SitioId == id).ToListAsync();
            if (archivos_SitioTuristico.Count < 1)
            {
                return NotFound();
            }

            var archivo_SitioTuristico = archivos_SitioTuristico.ElementAt(num);

            return File(archivo_SitioTuristico.info_file, GetMimeTypes()[archivo_SitioTuristico.ext]); ;
        }

        // PUT: api/Archivos_SitioTuristico/1
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo_SitioTuristico(int id, Archivo_SitioTuristico archivo_SitioTuristico)
        {
            if (id != archivo_SitioTuristico.Id)
            {
                return BadRequest();
            }

            _context.Entry(archivo_SitioTuristico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Archivo_SitioTuristicoExists(id))
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

        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>{
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".ico", "image/x-icon"},
            {".svg", "image/svg+xml"},
            {".gif", "image/gif"},
            };
        }

        // POST: api/Archivo_SitioTuristico
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Archivo_SitioTuristico>> PostArchivo_SitioTuristico([FromForm] IFormFile file, [FromForm] int sitioID)
        {

            using (var uploadedFile = new MemoryStream())
            {

                await file.CopyToAsync(uploadedFile);

                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (file.Length < 4194304 && GetMimeTypes().ContainsKey(ext))
                {
                    uploadedFile.Position = 0;
                    var archivo = new Archivo_SitioTuristico()
                    {
                        ext = ext,
                        info_file = uploadedFile.ToArray(),
                        SitioId = sitioID
                    };
                    _context.Archivos_SitioTuristico.Add(archivo);
                    await _context.SaveChangesAsync();
                    return Created("PostArchivo_SitioTuristico", new { id = archivo.Id });
                }
                else
                {
                    if (!GetMimeTypes().ContainsKey(ext))
                    {
                        return BadRequest("El tipo de archivo no es valido");
                    }
                    else
                    {
                        return BadRequest("El archivo es demasiado grande");
                    }
                }
            }
        }


        // DELETE: api/Archivo_SitioTuristico/1
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Archivo_SitioTuristico>> DeleteArchivo_SitioTuristico(int id)
        {
            var archivo_SitioTuristico = await _context.Archivos_SitioTuristico.FindAsync(id);
            if (archivo_SitioTuristico == null)
            {
                return NotFound();
            }

            _context.Archivos_SitioTuristico.Remove(archivo_SitioTuristico);
            await _context.SaveChangesAsync();

            return archivo_SitioTuristico;
        }

        private bool Archivo_SitioTuristicoExists(int id)
        {
            return _context.Archivos_SitioTuristico.Any(e => e.Id == id);
        }
    }
}