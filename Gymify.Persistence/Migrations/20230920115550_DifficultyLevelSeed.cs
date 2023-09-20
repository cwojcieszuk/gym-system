using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DifficultyLevelSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DifficultyLevel",
                columns: new[] { "DifficultyLevelId", "DifficultyLevelName" },
                values: new object[,]
                {
                    { 0, "Easy" },
                    { 1, "Medium" },
                    { 2, "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultyLevel",
                keyColumn: "DifficultyLevelId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "DifficultyLevel",
                keyColumn: "DifficultyLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DifficultyLevel",
                keyColumn: "DifficultyLevelId",
                keyValue: 2);
        }
    }
}
