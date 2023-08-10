using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MadeCoachDesciprtionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Coach",
                type: "varchar(300)",
                unicode: false,
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldUnicode: false,
                oldMaxLength: 300);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Coach",
                type: "varchar(300)",
                unicode: false,
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldUnicode: false,
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
