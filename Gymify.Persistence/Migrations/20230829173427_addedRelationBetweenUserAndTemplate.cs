using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedRelationBetweenUserAndTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserUid",
                table: "Template",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Template_UserUid",
                table: "Template",
                column: "UserUid");

            migrationBuilder.AddForeignKey(
                name: "Template_User",
                table: "Template",
                column: "UserUid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Template_User",
                table: "Template");

            migrationBuilder.DropIndex(
                name: "IX_Template_UserUid",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "UserUid",
                table: "Template");
        }
    }
}
