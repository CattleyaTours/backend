using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class FinalChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Publicaciones");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Participa en actividades como creación de artesanías, taller de fotografía entre otras.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Prueba las delicias típicas de nuestra tierra, en sitios únicos y vive una experiencia inolvidable.", "Gastronomía" });

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: "Recorre los parques y reservas naturales más famosas de nuestro país en compañía de expertos.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: "Visita sitios únicos en el mundo como cascadas naturales, volcanes y nevados.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Experimenta el vértigo y la adrenalina practicando deportes extremos como rapel, parapente, paracaidismo, canotaje, ciclomontañismo, entre otros.", "Deportes extremos" });

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "Disfruta de atracciones mecánicas en los parques de diversiones más famosos del país.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Sal de la ciudad y pasa un fin de semana alejado del estrés acampando en sitios extraordinarios disfrutando de la naturaleza en su máximo esplendor.", "Glamping" });

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 8,
                column: "Descripcion",
                value: "Vive una noche inolvidable junto a tus amigos disfrutando la sorprendente vida nocturna que tenemos para ofrecerte.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 9,
                column: "Descripcion",
                value: "Disfruta la experiencia de alimentar y convivir con animales de la región, acompañado por los mejores guías.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 10,
                column: "Descripcion",
                value: "Realiza actividades originales y divertidas únicas de cada sitio.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Publicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Talleres de todo tipo, fotografia, artesanías típicas etc ...");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Prueba las delicias típicas de nuestra tierra, en sitios únicos y vive una experiencia única", "Gastronomia" });

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: "Visita los parques y reservas naturales mas famosas de nuestro país en compañía de expertos");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: "Visita sitios únicos en el mundo como cascadas naturales, volcanes, nevados y muchos otros sitios alejados de la ciudad");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Experimenta el vértigo y la adrenalina practicando deportes extremos como Rapel, Parapente ...", "Deportes Extremos" });

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "Además de la naturaleza disfruta de atracciones mecánicas en los parques de diversiones más famosos del país");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Sal de la ciudad y pasa un fin de semana alejado del estrés acampando en sitios maravillosos en los que podrás disfrutar de la naturaleza en su máximo esplendor.", "Acampar * Glamping" });

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 8,
                column: "Descripcion",
                value: "Sal de la rutina y disfruta de una noche de fiesta ya sea en chivas rumberas, fiestas en la playa u otros sitios.");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 9,
                column: "Descripcion",
                value: "Disfruta la experiencia de alimentar y convivir con caballos, vacas y otros animales");

            migrationBuilder.UpdateData(
                table: "CategoriasActividad",
                keyColumn: "Id",
                keyValue: 10,
                column: "Descripcion",
                value: "Actividades muy originales y divertidas unicas de cada sitio ...");
        }
    }
}
