using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SitioTuristico> SitiosTuristicos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<CategoriaActividad> CategoriasActividad { get; set; }
        public DbSet<TipoHabitacion> TiposHabitacion { get; set; }
    }
}