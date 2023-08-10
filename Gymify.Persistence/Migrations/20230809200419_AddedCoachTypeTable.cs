using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoachTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CoachType_Coach",
                table: "CoachType");

            migrationBuilder.DropForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType");

            migrationBuilder.DropPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType");

            migrationBuilder.RenameColumn(
                name: "IdCoach",
                table: "CoachType",
                newName: "CoachCategoryUid");

            migrationBuilder.RenameColumn(
                name: "IdCoachCategory",
                table: "CoachType",
                newName: "CoachUid");

            migrationBuilder.RenameIndex(
                name: "IX_CoachType_IdCoach",
                table: "CoachType",
                newName: "IX_CoachType_CoachCategoryUid");

            migrationBuilder.AddColumn<Guid>(
                name: "CoachTypeUid",
                table: "CoachType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType",
                columns: new[] { "CoachTypeUid", "CoachUid", "CoachCategoryUid" });

            migrationBuilder.CreateIndex(
                name: "IX_CoachType_CoachUid",
                table: "CoachType",
                column: "CoachUid");

            migrationBuilder.AddForeignKey(
                name: "CoachType_Coach",
                table: "CoachType",
                column: "CoachUid",
                principalTable: "Coach",
                principalColumn: "CoachUid");

            migrationBuilder.AddForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType",
                column: "CoachCategoryUid",
                principalTable: "CoachCategory",
                principalColumn: "CoachCategoryUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CoachType_Coach",
                table: "CoachType");

            migrationBuilder.DropForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType");

            migrationBuilder.DropPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType");

            migrationBuilder.DropIndex(
                name: "IX_CoachType_CoachUid",
                table: "CoachType");

            migrationBuilder.DropColumn(
                name: "CoachTypeUid",
                table: "CoachType");

            migrationBuilder.RenameColumn(
                name: "CoachCategoryUid",
                table: "CoachType",
                newName: "IdCoach");

            migrationBuilder.RenameColumn(
                name: "CoachUid",
                table: "CoachType",
                newName: "IdCoachCategory");

            migrationBuilder.RenameIndex(
                name: "IX_CoachType_CoachCategoryUid",
                table: "CoachType",
                newName: "IX_CoachType_IdCoach");

            migrationBuilder.AddPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType",
                columns: new[] { "IdCoachCategory", "IdCoach" });

            migrationBuilder.AddForeignKey(
                name: "CoachType_Coach",
                table: "CoachType",
                column: "IdCoach",
                principalTable: "Coach",
                principalColumn: "CoachUid");

            migrationBuilder.AddForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType",
                column: "IdCoachCategory",
                principalTable: "CoachCategory",
                principalColumn: "CoachCategoryUid");
        }
    }
}
