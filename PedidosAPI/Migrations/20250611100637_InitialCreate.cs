using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    pedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precioTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.pedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,8)", precision: 10, scale: 8, nullable: true),
                    tax = table.Column<decimal>(type: "decimal(10,8)", precision: 10, scale: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "LineaPedido",
                columns: table => new
                {
                    lineaPedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPedido = table.Column<int>(type: "int", nullable: true),
                    productoId = table.Column<int>(type: "int", nullable: true),
                    cantidadProductos = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    taxUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    precioTotalLinea = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    pedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaPedido", x => x.lineaPedidoId);
                    table.ForeignKey(
                        name: "FK_LineaPedido_Pedido_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "Pedido",
                        principalColumn: "pedidoId");
                    table.ForeignKey(
                        name: "FK_LineaPedido_Producto_productoId",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "productoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineaPedido_pedidoId",
                table: "LineaPedido",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaPedido_productoId",
                table: "LineaPedido",
                column: "productoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
