using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class additionPedidoItensId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "PedidoItensId",
                table: "RegistroVendas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoItensId",
                table: "RegistroVendas");

            migrationBuilder.AddColumn<long>(
                name: "RegistroVendasId",
                table: "Produto",
                type: "bigint",
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
    }
}
