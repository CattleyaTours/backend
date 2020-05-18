using Microsoft.EntityFrameworkCore;

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
                    Descripcion = "Talleres de todo tipo, fotografia, artesanías típicas etc ..."
                },
                new
                {
                    Id = 2,
                    Nombre = "Gastronomia",
                    Icono = "fas fa-utensils",
                    Descripcion = "Prueba las delicias típicas de nuestra tierra, en sitios únicos y vive una experiencia única"
                },
                new
                {
                    Id = 3,
                    Nombre = "Visitas guiadas",
                    Icono = "fas fa-map-marked-alt",
                    Descripcion = "Visita los parques y reservas naturales mas famosas de nuestro país en compañía de expertos"
                },
                new
                {
                    Id = 4,
                    Nombre = "Maravillas naturales",
                    Icono = "fas fa-hiking",
                    Descripcion = "Visita sitios únicos en el mundo como cascadas naturales, volcanes, nevados y muchos otros sitios alejados de la ciudad"
                },
                new
                {
                    Id = 5,
                    Nombre = "Deportes Extremos",
                    Icono = "fas fa-biking",
                    Descripcion = "Experimenta el vértigo y la adrenalina practicando deportes extremos como Rapel, Parapente ..."
                },
                new
                {
                    Id = 6,
                    Nombre = "Atracciones mecánicas",
                    Icono = "fas fa-rocket",
                    Descripcion = "Además de la naturaleza disfruta de atracciones mecánicas en los parques de diversiones más famosos del país"
                },
                new
                {
                    Id = 7,
                    Nombre = "Acampar * Glamping",
                    Icono = "fas fa-campground",
                    Descripcion = "Sal de la ciudad y pasa un fin de semana alejado del estrés acampando en sitios maravillosos en los que podrás disfrutar de la naturaleza en su máximo esplendor."
                },
                new
                {
                    Id = 8,
                    Nombre = "Rumba",
                    Icono = "fas fa-glass-cheers",
                    Descripcion = "Sal de la rutina y disfruta de una noche de fiesta ya sea en chivas rumberas, fiestas en la playa u otros sitios."
                },
                new
                {
                    Id = 9,
                    Nombre = "Experiencias con animales",
                    Icono = "fas fa-paw",
                    Descripcion = "Disfruta la experiencia de alimentar y convivir con caballos, vacas y otros animales"
                },
                new
                {
                    Id = 10,
                    Nombre = "Otros",
                    Icono = "fas fa-ellipsis-h",
                    Descripcion = "Actividades muy originales y divertidas unicas de cada sitio ..."
                }
            );
       }
    }
}