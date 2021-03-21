using Microsoft.EntityFrameworkCore.Migrations;

namespace AmericaVirtual1.Migrations
{
    public partial class ActualizarTablasPaisesCiudades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Paises_IdPais",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_IdPais",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "PaisesId",
                table: "Ciudades",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisesId",
                table: "Ciudades",
                column: "PaisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Paises_PaisesId",
                table: "Ciudades",
                column: "PaisesId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Paises_PaisesId",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_PaisesId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "PaisesId",
                table: "Ciudades");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_IdPais",
                table: "Ciudades",
                column: "IdPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Paises_IdPais",
                table: "Ciudades",
                column: "IdPais",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
