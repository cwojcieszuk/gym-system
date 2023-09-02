using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedGifUrlTypeToBytes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GifUrl",
                table: "Exercise");

            migrationBuilder.AddColumn<byte[]>(
                name: "ExerciseGif",
                table: "Exercise",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseGif",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "GifUrl",
                table: "Exercise",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
