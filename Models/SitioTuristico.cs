using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SitioTuristico
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Descripcion { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Nombre { get; set; }

    [Required]
    public int Capacidad { get;  set; }

    [Required]
    public int RegionId { get;  set; }
    
    [Required]
    public int PropietarioId { get;  set; }
    
    [Required]
    public int Ubicacion { get; set; }

    // Relaciones    
    public Usuario Propietario { get; set; }
    
}