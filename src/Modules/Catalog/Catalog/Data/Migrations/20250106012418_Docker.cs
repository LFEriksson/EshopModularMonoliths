using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Docker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "catalog",
                table: "products",
                newName: "LastModifiedUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "catalog",
                table: "products",
                newName: "CreatedAtUTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedUTC",
                schema: "catalog",
                table: "products",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUTC",
                schema: "catalog",
                table: "products",
                newName: "CreatedAt");
        }
    }
}
