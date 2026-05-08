using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedTheMarketPriceForEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MarketPrice",
                table: "Entries",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketPrice",
                table: "Entries");
        }
    }
}
