using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Region
{
    public int Id { get; set; }
    
    [Required]    
    public string Nombre { get; set; }
    
    [Required]
    public string Descripcion { get; set; }

    // Relaciones
    internal List<SitioTuristico> SitiosTuristicos { get; set; }
    
}