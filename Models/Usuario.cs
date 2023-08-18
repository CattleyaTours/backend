using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;
using backend.Enums;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class Usuario
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Nombres { get; set; }

        [Required]
        public string? Telefono { get; set; }

        [Required]
        public string? Nacionalidad { get; set; }

        [Required]
        public Rol Rol { get; set; } = Rol.Usuario;

        [JsonIgnore]
        public List<Reserva>? Reservas { get; set; }

        [JsonIgnore]
        public List<Interes>? Intereses { get; set; }

        [JsonIgnore]
        public List<Comentario>? Comentarios { get; set; }
    }
}