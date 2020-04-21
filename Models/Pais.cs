using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pais
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Nombre { get; set; }

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Bandera { get; set; }
}