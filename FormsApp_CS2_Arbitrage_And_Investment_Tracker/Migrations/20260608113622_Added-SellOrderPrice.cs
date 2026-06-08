using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedSellOrderPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SellOrderPice",
                table: "Entries",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellOrderPice",
                table: "Entries");
        }
    }
}
