using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Publicacion
{
    public int Id { get; set; }
    
    [Required]
    public DateTime Fecha { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Titulo { get; set; }

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Descripcion { get; set; }

    [Required]
    public int PropietarioId { get; set; }

    [Required]
    public int Precio { get; set; }

    [Required]
    public int SitioId { get; set; }
    
    // Relaciones
    public Usuario Propietario { get; set; }

    public SitioTuristico Sitio { get; set; }
        
}