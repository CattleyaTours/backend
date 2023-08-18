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
            builder.Entity<Actividad>().Property(c => c.Nombre).HasMaxLength(50);

            builder.Entity<ArchivoSitioTuristico>().Property(c => c.MimeType).HasMaxLength(50);

            builder.Entity<CategoriaActividad>().Property(c => c.Nombre).HasMaxLength(50);
            builder.Entity<CategoriaActividad>().Property(c => c.Icono).HasMaxLength(50);
            builder.Entity<CategoriaActividad>().Property(c => c.Descripcion).HasMaxLength(500);

            builder.Entity<Comentario>().HasKey(x => x.Id);
            builder.Entity<Comentario>().Property(c => c.Contenido).HasMaxLength(500);
            builder.Entity<Comentario>().Property(c => c.FechaCreacion).HasDefaultValue(DateTime.Now);

            builder.Entity<Interes>().HasKey(k => new { k.Username, k.PublicacionId });
            builder.Entity<Interes>().Property(c => c.FechaCreacion).HasDefaultValue(DateTime.Now);

            builder.Entity<Publicacion>().Property(c => c.Titulo).HasMaxLength(100);
            builder.Entity<Publicacion>().Property(c => c.Descripcion).HasMaxLength(500);

            builder.Entity<Reserva>().HasKey(k => new { k.Username, k.PublicacionId });
            builder.Entity<Reserva>().Property(c => c.FechaCreacion).HasDefaultValue(DateTime.Now);

            builder.Entity<SitioTuristico>().Property(c => c.Descripcion).HasMaxLength(500);
            builder.Entity<SitioTuristico>().Property(c => c.Nombre).HasMaxLength(50);
            builder.Entity<SitioTuristico>().Property(c => c.Departamento).HasMaxLength(50);
            builder.Entity<SitioTuristico>().Property(c => c.Region).HasMaxLength(50);
            builder.Entity<SitioTuristico>().Property(c => c.Municipio).HasMaxLength(50);

            builder.Entity<Usuario>().Property(c => c.Nombres).HasMaxLength(50);
            builder.Entity<Usuario>().Property(c => c.Email).HasMaxLength(50);
            builder.Entity<Usuario>().Property(c => c.Password).HasMaxLength(50);
            builder.Entity<Usuario>().Property(c => c.Telefono).HasMaxLength(50);
            builder.Entity<Usuario>().Property(c => c.Nacionalidad).HasMaxLength(3);
            builder.Entity<Usuario>().Property(c => c.Username).HasMaxLength(50);
            builder.Entity<Usuario>().HasKey(u => u.Username);
            builder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();

            builder.SeedActividades();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SitioTuristico> SitiosTuristicos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<ArchivoSitioTuristico> ArchivosSitioTuristico { get; set; }
        public DbSet<CategoriaActividad> CategoriasActividad { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Interes> Intereses { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

    }
}