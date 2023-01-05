using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameDataApp.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quest",
                columns: new[] { "Id", "Description", "Name", "Reward" },
                values: new object[,]
                {
                    { 1, "This is the first quesst!", "First quest", "Money" },
                    { 2, "This is the second quest!", "Second quest", "Fame" }
                });
        }
    }
}
