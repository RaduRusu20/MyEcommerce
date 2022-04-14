using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ShoppingCartsProducts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ShoppingCartsProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartsProducts_ShoppingCartId",
                table: "ShoppingCartsProducts",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartsProducts_ShoppingCartId",
                table: "ShoppingCartsProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingCartsProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartsProducts",
                table: "ShoppingCartsProducts",
                columns: new[] { "ShoppingCartId", "ProductId" });
        }
    }
}
