using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Propietario
{
    public int Id { get; set; }
    
    [Required]
    public string Nombres { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Telefono { get; set; }

    // Relaciones 
    public List<SitioTuristico> SitiosTuristicos { get; set; }
    
    public List<Publicacion> Publicaciones { get; set; }

}