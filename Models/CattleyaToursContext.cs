using System.Linq;
using Microsoft.EntityFrameworkCore;
using Seeders;

namespace backend.Models
{
    public class CattleyaToursContext : DbContext
    {
        public CattleyaToursContext(DbContextOptions<CattleyaToursContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<Usuario>()
                .HasIndex(u => u.Username)
                .IsUnique();
            builder.Entity<Reserva>()
                .HasKey(k => new {k.UsuarioId, k.PublicacionId});
            builder.SeedActividades();
            builder.SeedHabitaciones();
            builder.SeedRoles();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SitioTuristico> SitiosTuristicos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Archivo_SitioTuristico> Archivos_SitioTuristico { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<CategoriaActividad> CategoriasActividad { get; set; }
        public DbSet<TipoHabitacion> TiposHabitacion { get; set; }

        public DbSet<Actividad> Actividades{ get; set;}

        public DbSet<Reserva> Reserva { get; set; }

    }
}