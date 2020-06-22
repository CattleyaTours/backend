using Microsoft.EntityFrameworkCore;

namespace Seeders
{
    public static class EstadosReservaSeeder
    {
        public static void SeedEstadosReserva(this ModelBuilder builder)
        {
            builder.Entity<EstadoReserva>().HasData(
                new {Id=1, Nombre="En espera"},
                new {Id=2, Nombre="Aceptado"},
                new {Id=3, Nombre="Rechazado"}
            );
        }
    }
}