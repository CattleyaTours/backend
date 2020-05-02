using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class DeletePaisAndRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SitiosTuristicos_Regiones_RegionId",
                table: "SitiosTuristicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Pais_PaisId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PaisId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_SitiosTuristicos_RegionId",
                table: "SitiosTuristicos");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Usuarios",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ubicacion",
                table: "SitiosTuristicos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "SitiosTuristicos");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bandera = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PaisId",
                table: "Usuarios",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosTuristicos_RegionId",
                table: "SitiosTuristicos",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_Nombre",
                table: "Paises",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SitiosTuristicos_Regiones_RegionId",
                table: "SitiosTuristicos",
                column: "RegionId",
                principalTable: "Regiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Pais_PaisId",
                table: "Usuarios",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
