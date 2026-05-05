using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedReturnValuesAndHoldDaysForTheEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DailyReturn",
                table: "Entries",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoldDays",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Return",
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
                name: "DailyReturn",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "HoldDays",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Return",
                table: "Entries");
        }
    }
}
