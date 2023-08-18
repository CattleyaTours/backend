using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;


namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ReservaController : ControllerBase
    {
        private readonly CattleyaToursContext _context;

        public ReservaController(CattleyaToursContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetReservasByPublicacion(int publicacionId, DateTime? fechaInicial, DateTime? fechaFinal)
        {
            var query = _context.Reservas.Include(x => x.Usuario).Where(x => x.PublicacionId == publicacionId).AsQueryable();

            if (fechaInicial.HasValue)
            {
                query = query.Where(x => x.FechaCreacion >= fechaInicial);
            }
            if (fechaFinal.HasValue)
            {
                query = query.Where(x => x.FechaCreacion <= fechaFinal);
            }

            var data = await query.ToListAsync();
            return Ok(data);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetReservasByUser(string username, DateTime? fechaInicial, DateTime? fechaFinal)
        {
            var query = _context.Reservas.Include(x => x.Publicacion).Where(x => x.Username == username).AsQueryable();

            if (fechaInicial.HasValue)
            {
                query = query.Where(x => x.FechaCreacion >= fechaInicial);
            }
            if (fechaFinal.HasValue)
            {
                query = query.Where(x => x.FechaCreacion <= fechaFinal);
            }

            var data = await query.ToListAsync();
            return Ok(data);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateReserva(Reserva reserva)
        {

            if (_context.Reservas.Any(x => reserva.Username == x.Username && reserva.PublicacionId == x.PublicacionId))
            {
                return Conflict();
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return Created("CreateInteres", reserva);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateReserva(Reserva reserva)
        {
            var oldReserva = await _context.Reservas.FindAsync(reserva.Username, reserva.PublicacionId);
            if (oldReserva == null)
            {
                return NotFound();
            }

            oldReserva.FechaCreacion = DateTime.Now;
            oldReserva.Fecha = reserva.Fecha;
            oldReserva.EstadoReserva = reserva.EstadoReserva;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteReserva(string username, int publicacionId)
        {
            var reserva = await _context.Reservas.FindAsync(username, publicacionId);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
