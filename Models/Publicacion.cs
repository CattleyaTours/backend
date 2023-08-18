using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Publicacion
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public int Precio { get; set; }

        [ForeignKey(nameof(Propietario))]
        [Required]
        public string PropietarioUsername { get; set; } = string.Empty;
        [JsonIgnore]
        public Usuario? Propietario { get; set; }

        [ForeignKey(nameof(Sitio))]
        [Required]
        public int SitioId { get; set; }
        [JsonIgnore]
        public SitioTuristico? Sitio { get; set; }

        [JsonIgnore]
        public List<Actividad>? Actividades { get; set; }

        [JsonIgnore]
        public List<Reserva>? Reservas { get; set; }

        [JsonIgnore]
        public List<Interes>? Intereses { get; set; }

        [JsonIgnore]
        public List<Comentario>? Comentarios { get; set; }
    }
}