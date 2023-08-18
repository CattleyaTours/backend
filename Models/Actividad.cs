using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Actividad
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [ForeignKey(nameof(CategoriaActividad))]
        [Required]
        public int CategoriaActividadId { get; set; }
        [JsonIgnore]
        public CategoriaActividad? CategoriaActividad {get; set;}

        [ForeignKey(nameof(Publicacion))]
        [Required]
        public int PublicacionId { get; set; }
        [JsonIgnore]
        public Publicacion? Publicacion { get; set; }

    }
}