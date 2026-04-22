using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class SkinConditionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SkinCondition",
                table: "SkinInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SkinCondition",
                table: "SkinInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
