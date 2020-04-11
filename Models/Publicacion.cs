using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Publicacion
{
    public int Id { get; set; }
    
    [Required]
    public DateTime Fecha { get; set; }
    
    [Required]
    public string Descripcion { get; set; }

    [Required]
    public int PropietarioId { get; set; }

    [Required]
    public int SitioId { get; set; }
    
    // Relaciones
    public Propietario Propietario { get; set; }

    public SitioTuristico Sitio { get; set; }
        
}