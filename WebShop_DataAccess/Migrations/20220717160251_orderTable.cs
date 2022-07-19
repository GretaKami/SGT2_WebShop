using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_DataAccess.Migrations
{
    public partial class orderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

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
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
