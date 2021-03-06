using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reserva
{
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public int UsuarioId { get; set; }    

    [Required]
    public int PublicacionId { get; set; }    
    
    [Required]
    public int EstadoReservaId { get; set; }

    //relaciones
    public EstadoReserva EstadoReserva { get; set; }

    public Usuario Usuario { get; set; }

    public Publicacion Publicacion { get; set; }
}

[NotMapped]
public class ReservaDTO
{
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }  

    //relaciones
    public EstadoReserva EstadoReserva { get; set; }

    public UsuarioDTO Usuario { get; set; }

}