using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class EstadoReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "TiposHabitacion");

            migrationBuilder.AddColumn<int>(
                name: "EstadoReservaId",
                table: "Reserva",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadosReserva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosReserva", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EstadosReserva",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "En espera" });

            migrationBuilder.InsertData(
                table: "EstadosReserva",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Aceptado" });

            migrationBuilder.InsertData(
                table: "EstadosReserva",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Rechazado" });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_EstadoReservaId",
                table: "Reserva",
                column: "EstadoReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_EstadosReserva_EstadoReservaId",
                table: "Reserva",
                column: "EstadoReservaId",
                principalTable: "EstadosReserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interes_Usuarios_UsuarioId",
                table: "Interes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_EstadosReserva_EstadoReservaId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Usuarios_UsuarioId",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "EstadosReserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_EstadoReservaId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "EstadoReservaId",
                table: "Reserva");

            migrationBuilder.CreateTable(
                name: "TiposHabitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHabitacion", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TiposHabitacion",
                columns: new[] { "Id", "CapacidadPersonas", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Secilla" },
                    { 2, 2, "Doble" },
                    { 3, 4, "Familiar" },
                    { 4, 8, "Multiple" }
                });

        }
    }
}
