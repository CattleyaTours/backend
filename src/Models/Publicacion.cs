using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Publicacion
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Titulo { get; set; }

    [Required]
    [Column(TypeName = "varchar(800)")]
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

    public List<Actividad> Actividades { get; set; }
        
}