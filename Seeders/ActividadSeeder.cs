using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace Seeders
{
    public static class ActividadSeeder
    {
        public static void SeedActividades(this ModelBuilder builder)
        {
            builder.Entity<CategoriaActividad>().HasData(
                new
                {
                    Id = 1,
                    Nombre = "Talleres",
                    Icono = "fas fa-pencil-ruler",
                    Descripcion = "Participa en actividades como creación de artesanías, taller de fotografía entre otras."
                },
                new
                {
                    Id = 2,
                    Nombre = "Gastronomía",
                    Icono = "fas fa-utensils",
                    Descripcion = "Prueba las delicias típicas de nuestra tierra, en sitios únicos y vive una experiencia inolvidable."
                },
                new
                {
                    Id = 3,
                    Nombre = "Visitas guiadas",
                    Icono = "fas fa-map-marked-alt",
                    Descripcion = "Recorre los parques y reservas naturales más famosas de nuestro país en compañía de expertos."
                },
                new
                {
                    Id = 4,
                    Nombre = "Maravillas naturales",
                    Icono = "fas fa-hiking",
                    Descripcion = "Visita sitios únicos en el mundo como cascadas naturales, volcanes y nevados."
                },
                new
                {
                    Id = 5,
                    Nombre = "Deportes extremos",
                    Icono = "fas fa-biking",
                    Descripcion = "Experimenta el vértigo y la adrenalina practicando deportes extremos como rapel, parapente, paracaidismo, canotaje, ciclomontañismo, entre otros."
                },
                new
                {
                    Id = 6,
                    Nombre = "Atracciones mecánicas",
                    Icono = "fas fa-rocket",
                    Descripcion = "Disfruta de atracciones mecánicas en los parques de diversiones más famosos del país."
                },
                new
                {
                    Id = 7,
                    Nombre = "Glamping",
                    Icono = "fas fa-campground",
                    Descripcion = "Sal de la ciudad y pasa un fin de semana alejado del estrés acampando en sitios extraordinarios disfrutando de la naturaleza en su máximo esplendor."
                },
                new
                {
                    Id = 8,
                    Nombre = "Rumba",
                    Icono = "fas fa-glass-cheers",
                    Descripcion = "Vive una noche inolvidable junto a tus amigos disfrutando la sorprendente vida nocturna que tenemos para ofrecerte."
                },
                new
                {
                    Id = 9,
                    Nombre = "Experiencias con animales",
                    Icono = "fas fa-paw",
                    Descripcion = "Disfruta la experiencia de alimentar y convivir con animales de la región, acompañado por los mejores guías."
                },
                new
                {
                    Id = 10,
                    Nombre = "Otros",
                    Icono = "fas fa-ellipsis-h",
                    Descripcion = "Realiza actividades originales y divertidas únicas de cada sitio."
                }
            );
        }
    }
}




