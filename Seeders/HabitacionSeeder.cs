using Microsoft.EntityFrameworkCore;

namespace Seeders
{
    public static class HabitacionSeeder
    {
        public static void SeedHabitaciones(this ModelBuilder builder)
        {
            builder.Entity<TipoHabitacion>().HasData(
                new { Id = 1, Nombre = "Secilla", CapacidadPersonas = 1 },
                new { Id = 2, Nombre = "Doble", CapacidadPersonas = 2 },
                new { Id = 3, Nombre = "Familiar", CapacidadPersonas = 4 },
                new { Id = 4, Nombre = "Multiple", CapacidadPersonas = 8 }
            );
        }
    }
}