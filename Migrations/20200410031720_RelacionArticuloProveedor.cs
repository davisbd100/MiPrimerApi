using Microsoft.EntityFrameworkCore.Migrations;

namespace MiPrimerApi.Migrations
{
    public partial class RelacionArticuloProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Articulos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_ProveedorId",
                table: "Articulos",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Proveedores_ProveedorId",
                table: "Articulos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Proveedores_ProveedorId",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_ProveedorId",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Articulos");
        }
    }
}
