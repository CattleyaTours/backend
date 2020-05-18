using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class creacionArchivo_SitioTuristico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivos_SitioTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "varchar(400)", nullable: false),
                    SitioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos_SitioTuristico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivos_SitioTuristico_SitiosTuristicos_SitioId",
                        column: x => x.SitioId,
                        principalTable: "SitiosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_SitioTuristico_SitioId",
                table: "Archivos_SitioTuristico",
                column: "SitioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos_SitioTuristico");
        }
    }
}
