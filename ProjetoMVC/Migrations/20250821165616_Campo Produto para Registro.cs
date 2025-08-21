using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class CampoProdutoparaRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistroVendasId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_RegistroVendasId",
                table: "Produto",
                column: "RegistroVendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_RegistroVendas_RegistroVendasId",
                table: "Produto",
                column: "RegistroVendasId",
                principalTable: "RegistroVendas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_RegistroVendas_RegistroVendasId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_RegistroVendasId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "RegistroVendasId",
                table: "Produto");
        }
    }
}
