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
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Icono = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(800)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasActividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosReserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosReserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false),
                    Username = table.Column<string>(type: "varchar(30)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "varchar(3)", nullable: false),
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SitiosTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "varchar(800)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Region = table.Column<string>(type: "varchar(50)", nullable: false),
                    Departamento = table.Column<string>(type: "varchar(50)", nullable: false),
                    Municipio = table.Column<string>(type: "varchar(50)", nullable: false),
                    PropietarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitiosTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitiosTuristicos_Usuarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivos_SitioTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    info_file = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ext = table.Column<string>(type: "TEXT", nullable: false),
                    SitioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos_SitioTuristico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivos_SitioTuristico_SitiosTuristicos_SitioId",
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
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(800)", nullable: false),
                    PropietarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<int>(type: "INTEGER", nullable: false),
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
                        name: "FK_Publicaciones_Usuarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    TipoActividadId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_CategoriasActividad_TipoActividadId",
                        column: x => x.TipoActividadId,
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
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    Contenido = table.Column<string>(type: "varchar(500)", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interes",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interes", x => new { x.UsuarioId, x.PublicacionId });
                    table.ForeignKey(
                        name: "FK_Interes_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadoReservaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => new { x.UsuarioId, x.PublicacionId });
                    table.ForeignKey(
                        name: "FK_Reserva_EstadosReserva_EstadoReservaId",
                        column: x => x.EstadoReservaId,
                        principalTable: "EstadosReserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
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

            migrationBuilder.InsertData(
                table: "EstadosReserva",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "En espera" },
                    { 2, "Aceptado" },
                    { 3, "Rechazado" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Propietario" },
                    { 2, "Usuario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_PublicacionId",
                table: "Actividades",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_TipoActividadId",
                table: "Actividades",
                column: "TipoActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_SitioTuristico_SitioId",
                table: "Archivos_SitioTuristico",
                column: "SitioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PublicacionId",
                table: "Comentario",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioId",
                table: "Comentario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Interes_PublicacionId",
                table: "Interes",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PropietarioId",
                table: "Publicaciones",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_SitioId",
                table: "Publicaciones",
                column: "SitioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_EstadoReservaId",
                table: "Reserva",
                column: "EstadoReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PublicacionId",
                table: "Reserva",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosTuristicos_PropietarioId",
                table: "SitiosTuristicos",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Archivos_SitioTuristico");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Interes");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "CategoriasActividad");

            migrationBuilder.DropTable(
                name: "EstadosReserva");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "SitiosTuristicos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
