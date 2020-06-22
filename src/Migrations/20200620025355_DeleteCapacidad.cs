using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class DeleteCapacidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "SitiosTuristicos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "SitiosTuristicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
