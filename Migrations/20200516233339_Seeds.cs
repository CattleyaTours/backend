using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoriasActividad",
                columns: new[] { "Id", "Descripcion", "Icono", "Nombre" },
                values: new object[,]
                {
                    { 1, "Talleres de todo tipo, fotografia, artesanías típicas etc ...", "fas fa-pencil-ruler", "Talleres" },
                    { 2, "Prueba las delicias típicas de nuestra tierra, en sitios únicos y vive una experiencia única", "fas fa-utensils", "Gastronomia" },
                    { 3, "Visita los parques y reservas naturales mas famosas de nuestro país en compañía de expertos", "fas fa-map-marked-alt", "Visitas guiadas" },
                    { 4, "Visita sitios únicos en el mundo como cascadas naturales, volcanes, nevados y muchos otros sitios alejados de la ciudad", "fas fa-hiking", "Maravillas naturales" },
                    { 5, "Experimenta el vértigo y la adrenalina practicando deportes extremos como Rapel, Parapente ...", "fas fa-biking", "Deportes Extremos" },
                    { 6, "Además de la naturaleza disfruta de atracciones mecánicas en los parques de diversiones más famosos del país", "fas fa-rocket", "Atracciones mecánicas" },
                    { 7, "Sal de la ciudad y pasa un fin de semana alejado del estrés acampando en sitios maravillosos en los que podrás disfrutar de la naturaleza en su máximo esplendor.", "fas fa-campground", "Acampar * Glamping" },
                    { 8, "Sal de la rutina y disfruta de una noche de fiesta ya sea en chivas rumberas, fiestas en la playa u otros sitios.", "fas fa-glass-cheers", "Rumba" },
                    { 9, "Disfruta la experiencia de alimentar y convivir con caballos, vacas y otros animales", "fas fa-paw", "Experiencias con animales" },
                    { 10, "Actividades muy originales y divertidas unicas de cada sitio ...", "fas fa-ellipsis-h", "Otros" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Propietario" },
                    { 2, "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "TiposHabitacion",
                columns: new[] { "Id", "CapacidadPersonas", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Secilla" },
                    { 2, 2, "Doble" },
                    { 3, 4, "Familiar" },
                    { 4, 8, "Multiple" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposHabitacion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposHabitacion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposHabitacion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposHabitacion",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
