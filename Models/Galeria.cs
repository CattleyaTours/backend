using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

public class Galeria
{
    [Required]
    public int Id {get; set;}
    [Required]
    public string path{get; set;}
    
    //Relaciones 
    public Publicacion Publicacion {get; set;}
}
