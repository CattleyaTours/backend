using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SitioTuristico
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(800)")]
    public string Descripcion { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; }

    [Required]
    public int Capacidad { get;  set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Region { get;  set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Departamento { get;  set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Municipio { get;  set; }
    
    [Required]
    public int PropietarioId { get;  set; }

    // Relaciones    
    public Usuario Propietario { get; set; }
    
}