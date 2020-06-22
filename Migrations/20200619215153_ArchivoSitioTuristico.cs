using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class ArchivoSitioTuristico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivos_SitioTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info_file = table.Column<byte[]>(nullable: false),
                    ext = table.Column<string>(nullable: false),
                    SitioId = table.Column<int>(nullable: false)
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
