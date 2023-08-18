using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class CategoriaActividad
    {
        public int Id {get; set;}

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Icono { get; set; }
    
        [Required]
        public string? Descripcion { get; set; }

    }
}