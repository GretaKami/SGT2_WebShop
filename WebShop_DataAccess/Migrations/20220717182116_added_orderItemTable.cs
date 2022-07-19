using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_DataAccess.Migrations
{
    public partial class added_orderItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Items_OrderId",
                table: "Cart_Items");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Cart_Items");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Cart_Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_OrderId",
                table: "Order_Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_ProductId",
                table: "Order_Items",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Cart_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Cart_Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_OrderId",
                table: "Cart_Items",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
