using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ShoppingCartsProducts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartsProducts_ShoppingCartId",
                table: "ShoppingCartsProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts",
                columns: new[] { "ShoppingCartId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartsProducts_ShoppingCartId",
                table: "ShoppingCartsProducts",
                column: "ShoppingCartId");
        }
    }
}
