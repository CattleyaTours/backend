using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Nombres { get; set; }

    [Required]
    public string Telefono { get; set; }

    [Required]
    public string Nacionalidad { get; set; }   
}

[NotMapped]
public class UsuarioConToken
{
    public Usuario usuario { get; set; }

    public string token { get; set; }

}

[NotMapped]
public class UsuarioAuth
{
    public string Email { get; set; }

    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

}