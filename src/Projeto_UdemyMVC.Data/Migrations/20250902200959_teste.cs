using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistroVendaId",
                table: "PedidoItens",
                newName: "RegistroVendasId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_RegistroVendasId",
                table: "PedidoItens",
                column: "RegistroVendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_RegistroVendas_RegistroVendasId",
                table: "PedidoItens",
                column: "RegistroVendasId",
                principalTable: "RegistroVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_RegistroVendas_RegistroVendasId",
                table: "PedidoItens");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItens_RegistroVendasId",
                table: "PedidoItens");

            migrationBuilder.RenameColumn(
                name: "RegistroVendasId",
                table: "PedidoItens",
                newName: "RegistroVendaId");
        }
    }
}
