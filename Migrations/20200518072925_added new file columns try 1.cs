using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class addednewfilecolumnstry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ruta",
                table: "Archivos_SitioTuristico");

            migrationBuilder.AddColumn<byte[]>(
                name: "info_file",
                table: "Archivos_SitioTuristico",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "info_file",
                table: "Archivos_SitioTuristico");

            migrationBuilder.AddColumn<string>(
                name: "Ruta",
                table: "Archivos_SitioTuristico",
                type: "varchar(400)",
                nullable: false,
                defaultValue: "");
        }
    }
}
