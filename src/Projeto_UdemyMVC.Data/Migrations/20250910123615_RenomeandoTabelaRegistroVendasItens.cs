using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoTabelaRegistroVendasItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_RegistroVendas_RegistroVendasId",
                table: "PedidoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItens",
                table: "PedidoItens");

            migrationBuilder.RenameTable(
                name: "PedidoItens",
                newName: "RegistroVendasItens");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_RegistroVendasId",
                table: "RegistroVendasItens",
                newName: "IX_RegistroVendasItens_RegistroVendasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroVendasItens",
                table: "RegistroVendasItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroVendasItens_RegistroVendas_RegistroVendasId",
                table: "RegistroVendasItens",
                column: "RegistroVendasId",
                principalTable: "RegistroVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroVendasItens_RegistroVendas_RegistroVendasId",
                table: "RegistroVendasItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistroVendasItens",
                table: "RegistroVendasItens");

            migrationBuilder.RenameTable(
                name: "RegistroVendasItens",
                newName: "PedidoItens");

            migrationBuilder.RenameIndex(
                name: "IX_RegistroVendasItens_RegistroVendasId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_RegistroVendasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItens",
                table: "PedidoItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_RegistroVendas_RegistroVendasId",
                table: "PedidoItens",
                column: "RegistroVendasId",
                principalTable: "RegistroVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
