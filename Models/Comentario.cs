using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comentario
{
    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    [Column(TypeName = "varchar(500)")]
    public string Contenido { get; set; }

    [Required]
    public int UsuarioId { get; set; }    

    [Required]
    public int PublicacionId { get; set; }    

    //relaciones
    public Usuario Usuario { get; set; }

    public Publicacion Publicacion { get; set; }
}

[NotMapped]
public class ComentarioDTO
{
    [Required]
    public DateTime Fecha { get; set; }  

    [Required]
    [Column(TypeName = "varchar(500)")]
    public string Contenido { get; set; }

    public UsuarioDTO Usuario { get; set; }
}