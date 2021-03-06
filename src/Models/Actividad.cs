using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Actividad
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; }

    [Required]
    public int TipoActividadId { get; set; }

    [Required]
    public int PublicacionId { get; set; }

    // Relaciones    

    public CategoriaActividad TipoActividad {get; set;}
}