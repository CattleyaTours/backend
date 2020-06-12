using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class cambieenactividadid_sitioporid_pub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_SitiosTuristicos_SitioTuristicoId",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "SitioTuristicoId",
                table: "Actividades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PublicacionId",
                table: "Actividades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_SitiosTuristicos_SitioTuristicoId",
                table: "Actividades",
                column: "SitioTuristicoId",
                principalTable: "SitiosTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_SitiosTuristicos_SitioTuristicoId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "PublicacionId",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "SitioTuristicoId",
                table: "Actividades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_SitiosTuristicos_SitioTuristicoId",
                table: "Actividades",
                column: "SitioTuristicoId",
                principalTable: "SitiosTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
