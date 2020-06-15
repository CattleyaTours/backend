using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Correcionfinalarchivo_sitio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Archivos_SitioTuristico",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ext",
                table: "Archivos_SitioTuristico",
                nullable: false,
                defaultValue: "");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos_SitioTuristico_SitiosTuristicos_SitioId",
                table: "Archivos_SitioTuristico");

            migrationBuilder.AlterColumn<int>(
                name: "SitioId",
                table: "Archivos_SitioTuristico",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos_SitioTuristico_SitiosTuristicos_SitioId",
                table: "Archivos_SitioTuristico",
                column: "SitioId",
                principalTable: "SitiosTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "name",
                table: "Archivos_SitioTuristico");
            
            migrationBuilder.DropColumn(
                name: "ext",
                table: "Archivos_SitioTuristico");

            migrationBuilder.DropForeignKey(
                name: "FK_Archivos_SitioTuristico_SitiosTuristicos_SitioId",
                table: "Archivos_SitioTuristico");

            migrationBuilder.AlterColumn<int>(
                name: "SitioId",
                table: "Archivos_SitioTuristico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos_SitioTuristico_SitiosTuristicos_SitioId",
                table: "Archivos_SitioTuristico",
                column: "SitioId",
                principalTable: "SitiosTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
