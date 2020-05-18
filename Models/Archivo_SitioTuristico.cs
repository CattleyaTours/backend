using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

public class Archivo_SitioTuristico
{
    public int Id { get; set; }

    [Required]
    public byte[] info_file { get; set; }
 
    // Relaciones
    public SitioTuristico Sitio { get; set; }
        
}