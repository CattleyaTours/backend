using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using System.IO;
using Microsoft.Extensions.Hosting;

//Microsoft.Extensions.Hosting.IHostEnvironment
namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaleriaController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public GaleriaController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/Galeria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galeria>>> GetGaleria()
        {
            return await _context.Galeria.ToListAsync();
        }

        private IHostEnvironment _env;
        public GaleriaController(IHostEnvironment env)
        {
            _env  = env;
        }

        public IActionResult SingleFile(IFormFile file)
        {   
            var dir = _env.ContentRootPath;

            using(var fileStream = new FileStream(Path.Combine(dir,"file.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return Ok();
            //return ActionResult("html");
        }

        // GET: api/Galeria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galeria>> GetGaleria(int id)
        {
            var galeria = await _context.Galeria.FindAsync(id);

            if (galeria == null)
            {
                return NotFound();
            }

            return galeria;
        }

        // PUT: api/Galeria/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGaleria(int id, Galeria galeria)
        {
            if (id != galeria.Id)
            {
                return BadRequest();
            }

            _context.Entry(galeria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaleriaExists(id))
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

        // POST: api/Galeria
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Galeria>> PostGaleria(Galeria galeria)
        {
            _context.Galeria.Add(galeria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGaleria", new { id = galeria.Id }, galeria);
        }

        // DELETE: api/Galeria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Galeria>> DeleteGaleria(int id)
        {
            var galeria = await _context.Galeria.FindAsync(id);
            if (galeria == null)
            {
                return NotFound();
            }

            _context.Galeria.Remove(galeria);
            await _context.SaveChangesAsync();

            return galeria;
        }

        private bool GaleriaExists(int id)
        {
            return _context.Galeria.Any(e => e.Id == id);
        } 
    }
}
