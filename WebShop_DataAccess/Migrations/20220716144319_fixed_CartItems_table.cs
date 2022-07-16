using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_DataAccess.Migrations
{
    public partial class fixed_CartItems_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Cart_Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Cart_Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Carts_CartId",
                table: "Cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Items_Orders_OrderId",
                table: "Cart_Items");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Cart_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Cart_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
