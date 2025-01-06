using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.Data.Migrations
{
    /// <inheritdoc />
    public partial class Docker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "basket",
                table: "ShoppingCarts",
                newName: "LastModifiedUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "basket",
                table: "ShoppingCarts",
                newName: "CreatedAtUTC");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "basket",
                table: "ShoppingCartItems",
                newName: "LastModifiedUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "basket",
                table: "ShoppingCartItems",
                newName: "CreatedAtUTC");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "basket",
                table: "OutboxMessages",
                newName: "LastModifiedUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "basket",
                table: "OutboxMessages",
                newName: "CreatedAtUTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedUTC",
                schema: "basket",
                table: "ShoppingCarts",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                schema: "basket",
                table: "ShoppingCarts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUTC",
                schema: "basket",
                table: "ShoppingCartItems",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                schema: "basket",
                table: "ShoppingCartItems",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUTC",
                schema: "basket",
                table: "OutboxMessages",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                schema: "basket",
                table: "OutboxMessages",
                newName: "CreatedAt");
        }
    }
}
