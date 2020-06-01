using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddedextfieldtoArch_Sitio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Archivos_SitioTuristico");

            migrationBuilder.AddColumn<string>(
                name: "ext",
                table: "Archivos_SitioTuristico",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ext",
                table: "Archivos_SitioTuristico");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Archivos_SitioTuristico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
