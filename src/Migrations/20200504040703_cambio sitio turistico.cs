using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class cambiositioturistico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "SitiosTuristicos");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "SitiosTuristicos");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "SitiosTuristicos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "SitiosTuristicos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "SitiosTuristicos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "SitiosTuristicos");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "SitiosTuristicos");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "SitiosTuristicos");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "SitiosTuristicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ubicacion",
                table: "SitiosTuristicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
