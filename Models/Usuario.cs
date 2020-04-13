using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int Id { get; set; }
    [Required]
    public string Nombres { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Telefono { get; set; }
    [Required]
    public string Nacionalidad { get; set; }   
    [Required]
    public string Nombre_Usuario { get; set; }
    [Required]
    public string Contrasena {get; set;}
}