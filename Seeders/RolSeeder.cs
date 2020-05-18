using Microsoft.EntityFrameworkCore;

namespace Seeders
{
    public static class RolSeeder
    {
        public static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<Rol>().HasData(
                new {Id=1, Nombre="Propietario"},
                new {Id=2, Nombre="Usuario"}
            );
        }
    }
}