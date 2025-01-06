using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Data.Migrations
{
    /// <inheritdoc />
    public partial class Docker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "ordering",
                table: "Orders",
                newName: "LastModifiedUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Orders",
                newName: "CreatedAtUTC");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "ordering",
                table: "OrderItems",
                newName: "LastModifiedUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "OrderItems",
                newName: "CreatedAtUTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedUTC",
                schema: "ordering",
                table: "Orders",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                schema: "ordering",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUTC",
                schema: "ordering",
                table: "OrderItems",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                schema: "ordering",
                table: "OrderItems",
                newName: "CreatedAt");
        }
    }
}
