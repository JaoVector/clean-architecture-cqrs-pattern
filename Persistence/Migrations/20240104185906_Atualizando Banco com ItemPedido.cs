using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FollowMe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoBancocomItemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItemCarrinho",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    ItemPedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.ItemPedidoId);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "CodPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Produtos_CodProduto",
                        column: x => x.CodProduto,
                        principalTable: "Produtos",
                        principalColumn: "CodProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnderecoId",
                table: "Pedidos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_CodProduto",
                table: "ItensPedido",
                column: "CodProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Enderecos_EnderecoId",
                table: "Pedidos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Enderecos_EnderecoId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EnderecoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItemCarrinho");
        }
    }
}
