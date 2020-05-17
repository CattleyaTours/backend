using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CategoriaActividad
{
    public int Id {get; set;}

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]

    public string Icono { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(800)")]
    public string Descripcion { get; set; }

}