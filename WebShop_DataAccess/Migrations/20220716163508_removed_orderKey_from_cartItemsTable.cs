using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_DataAccess.Migrations
{
    public partial class removed_orderKey_from_cartItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Items_OrderId",
                table: "Cart_Items");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Cart_Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Cart_Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_OrderId",
                table: "Cart_Items",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
