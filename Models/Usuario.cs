using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Username { get; set; }

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Password { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nombres { get; set; }

    [Required]
    [Column(TypeName = "varchar(15)")]
    public string Telefono { get; set; }

    [Required]
    [Column(TypeName = "varchar(3)")]
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
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}