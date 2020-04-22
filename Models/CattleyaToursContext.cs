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
            builder.Entity<Pais>()
                .HasIndex(p => p.Nombre)
                .IsUnique();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<SitioTuristico> SitiosTuristicos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
    }
}