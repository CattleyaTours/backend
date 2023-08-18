using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Icono = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasActividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nacionalidad = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "SitiosTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Municipio = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PropietarioUsername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitiosTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitiosTuristicos_Usuarios_PropietarioUsername",
                        column: x => x.PropietarioUsername,
                        principalTable: "Usuarios",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosSitioTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SitioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosSitioTuristico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivosSitioTuristico_SitiosTuristicos_SitioId",
                        column: x => x.SitioId,
                        principalTable: "SitiosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Precio = table.Column<int>(type: "INTEGER", nullable: false),
                    PropietarioUsername = table.Column<string>(type: "TEXT", nullable: false),
                    SitioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_SitiosTuristicos_SitioId",
                        column: x => x.SitioId,
                        principalTable: "SitiosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Usuarios_PropietarioUsername",
                        column: x => x.PropietarioUsername,
                        principalTable: "Usuarios",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CategoriaActividadId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_CategoriasActividad_CategoriaActividadId",
                        column: x => x.CategoriaActividadId,
                        principalTable: "CategoriasActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Contenido = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 8, 18, 10, 13, 34, 815, DateTimeKind.Local).AddTicks(3216)),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_Username",
                        column: x => x.Username,
                        principalTable: "Usuarios",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intereses",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 8, 18, 10, 13, 34, 815, DateTimeKind.Local).AddTicks(5851))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intereses", x => new { x.Username, x.PublicacionId });
                    table.ForeignKey(
                        name: "FK_Intereses_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intereses_Usuarios_Username",
                        column: x => x.Username,
                        principalTable: "Usuarios",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 8, 18, 10, 13, 34, 815, DateTimeKind.Local).AddTicks(8396))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => new { x.Username, x.PublicacionId });
                    table.ForeignKey(
                        name: "FK_Reservas_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_Username",
                        column: x => x.Username,
                        principalTable: "Usuarios",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriasActividad",
                columns: new[] { "Id", "Descripcion", "Icono", "Nombre" },
                values: new object[,]
                {
                    { 1, "Participa en actividades como creación de artesanías, taller de fotografía entre otras.", "fas fa-pencil-ruler", "Talleres" },
                    { 2, "Prueba las delicias típicas de nuestra tierra, en sitios únicos y vive una experiencia inolvidable.", "fas fa-utensils", "Gastronomía" },
                    { 3, "Recorre los parques y reservas naturales más famosas de nuestro país en compañía de expertos.", "fas fa-map-marked-alt", "Visitas guiadas" },
                    { 4, "Visita sitios únicos en el mundo como cascadas naturales, volcanes y nevados.", "fas fa-hiking", "Maravillas naturales" },
                    { 5, "Experimenta el vértigo y la adrenalina practicando deportes extremos como rapel, parapente, paracaidismo, canotaje, ciclomontañismo, entre otros.", "fas fa-biking", "Deportes extremos" },
                    { 6, "Disfruta de atracciones mecánicas en los parques de diversiones más famosos del país.", "fas fa-rocket", "Atracciones mecánicas" },
                    { 7, "Sal de la ciudad y pasa un fin de semana alejado del estrés acampando en sitios extraordinarios disfrutando de la naturaleza en su máximo esplendor.", "fas fa-campground", "Glamping" },
                    { 8, "Vive una noche inolvidable junto a tus amigos disfrutando la sorprendente vida nocturna que tenemos para ofrecerte.", "fas fa-glass-cheers", "Rumba" },
                    { 9, "Disfruta la experiencia de alimentar y convivir con animales de la región, acompañado por los mejores guías.", "fas fa-paw", "Experiencias con animales" },
                    { 10, "Realiza actividades originales y divertidas únicas de cada sitio.", "fas fa-ellipsis-h", "Otros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_CategoriaActividadId",
                table: "Actividades",
                column: "CategoriaActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_PublicacionId",
                table: "Actividades",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosSitioTuristico_SitioId",
                table: "ArchivosSitioTuristico",
                column: "SitioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacionId",
                table: "Comentarios",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Username",
                table: "Comentarios",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Intereses_PublicacionId",
                table: "Intereses",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PropietarioUsername",
                table: "Publicaciones",
                column: "PropietarioUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_SitioId",
                table: "Publicaciones",
                column: "SitioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PublicacionId",
                table: "Reservas",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosTuristicos_PropietarioUsername",
                table: "SitiosTuristicos",
                column: "PropietarioUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "ArchivosSitioTuristico");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Intereses");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "CategoriasActividad");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "SitiosTuristicos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
