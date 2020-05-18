using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rol
{
    public int Id {get; set;}

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; }

}
