using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class SitioTuristico
    {
        public int Id { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Region { get; set; }

        [Required]
        public string? Departamento { get; set; }

        [Required]
        public string? Municipio { get; set; }

        [ForeignKey(nameof(Propietario))]
        [Required]
        public string? PropietarioUsername { get; set; }
        [JsonIgnore]
        public Usuario? Propietario { get; set; }

        [JsonIgnore]
        public List<ArchivoSitioTuristico>? Imagenes { get; set; }
    }
}
