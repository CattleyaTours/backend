using backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Reserva : UsuarioPublicacion
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public EstadoReserva EstadoReserva { get; set; } = EstadoReserva.Espera;
    }
}