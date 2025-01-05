using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.Data.Migrations
{
    /// <inheritdoc />
    public partial class UtcUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessedOn",
                schema: "basket",
                table: "OutboxMessages",
                newName: "ProcessedOnUTC");

            migrationBuilder.RenameColumn(
                name: "OccuredOn",
                schema: "basket",
                table: "OutboxMessages",
                newName: "OccuredOnUTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessedOnUTC",
                schema: "basket",
                table: "OutboxMessages",
                newName: "ProcessedOn");

            migrationBuilder.RenameColumn(
                name: "OccuredOnUTC",
                schema: "basket",
                table: "OutboxMessages",
                newName: "OccuredOn");
        }
    }
}
