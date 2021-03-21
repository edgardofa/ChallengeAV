using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmericaVirtual1.Migrations
{
    public partial class InicialDatosClima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatosClima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCiudad = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TemperaturaC = table.Column<int>(type: "INTEGER", nullable: false),
                    IndicadorClima = table.Column<int>(type: "INTEGER", nullable: false),
                    Humedad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precipitaciones = table.Column<int>(type: "INTEGER", nullable: false),
                    Vientos = table.Column<int>(type: "INTEGER", nullable: false),
                    CiudadesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosClima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosClima_Ciudades_CiudadesId",
                        column: x => x.CiudadesId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosClima_CiudadesId",
                table: "DatosClima",
                column: "CiudadesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosClima");
        }
    }
}
