using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class UsuarioPublicacion
    {
        [Required]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(Usuario))]
        [Required]
        public string Username { get; set; } = string.Empty;
        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        [ForeignKey(nameof(Publicacion))]
        [Required]
        public int PublicacionId { get; set; }
        [JsonIgnore]
        public Publicacion? Publicacion { get; set; }
    }
}