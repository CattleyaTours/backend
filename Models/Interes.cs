using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Interes
{
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public int UsuarioId { get; set; }    

    [Required]
    public int PublicacionId { get; set; }    

    //relaciones
    public Usuario Usuario { get; set; }

    public Publicacion Publicacion { get; set; }
}

[NotMapped]
public class InteresDTO
{
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }  

    //relaciones
    public UsuarioDTO Usuario { get; set; }

}