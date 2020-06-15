using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public ReservaController(CattleyaToursContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
        {
            return await _context.Reserva.Include(x => x.Usuario).Include(x => x.Publicacion).ToListAsync();
        }

        // GET: api/Reserva/publicacion/5/usuario/3
        [HttpGet("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Reserva>> GetReserva(int usuarioId, int publicacionId)
        {
 
            var reserva = await _context.Reserva.FindAsync(usuarioId,publicacionId);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }
        
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservaByUserId(int id)
        {
            return await _context.Reserva.Include(x => x.Publicacion).Where(x => x.Usuario.Id == id).ToListAsync();
        }

        [HttpGet("publicacion/{id}")]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetReservaByPublicacionId(int id)
        {
            return  await _context.Reserva
            .Include(x => x.Usuario)
            .Where(x => x.Publicacion.Id == id)
            .Select( x => new ReservaDTO(){ 
                Id = x.Id,
                Fecha = x.Fecha,
                Usuario = new UsuarioDTO(){
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
        
        // PUT: api/Reserva/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
        }

        // DELETE: api/Reserva/5/publicacion/5/usuario/3
        [HttpDelete("publicacion/{publicacionId}/usuario/{usuarioId}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int usuarioId, int publicacionId)
        {
            var reserva = await _context.Reserva.FindAsync(usuarioId, publicacionId);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}
