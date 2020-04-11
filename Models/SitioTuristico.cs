using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SitioTuristico
{
    public int Id { get; set; }

    [Required]
    public string Descripcion { get; set; }
    
    [Required]
    public int Capacidad { get;  set; }

    [Required]
    public int RegionId { get;  set; }
    
    [Required]
    public int PropietarioId { get;  set; }

    // Relaciones    
    public Region Region { get; set; }

    public Propietario Propietario { get; set; }
    
    public List<Publicacion> Publicaciones { get; set; }

}