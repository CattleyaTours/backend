using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TipoHabitacion
{
    public int Id {get; set;}

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; }

    public int CapacidadPersonas {get; set;}
}
