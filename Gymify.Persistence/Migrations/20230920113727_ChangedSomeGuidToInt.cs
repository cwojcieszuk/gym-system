using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSomeGuidToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType");

            migrationBuilder.DropForeignKey(
                name: "GroupSession_Place",
                table: "GroupSession");

            migrationBuilder.DropForeignKey(
                name: "Template_DifficultyLevel",
                table: "Template");

            migrationBuilder.DropIndex(
                name: "IX_Template_DifficultyLevelUid",
                table: "Template");

            migrationBuilder.DropPrimaryKey(
                name: "Place_pk",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_GroupSession_PlaceUid",
                table: "GroupSession");

            migrationBuilder.DropPrimaryKey(
                name: "DifficultyLevel_pk",
                table: "DifficultyLevel");

            migrationBuilder.DropPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType");

            migrationBuilder.DropIndex(
                name: "IX_CoachType_CoachCategoryUid",
                table: "CoachType");

            migrationBuilder.DropPrimaryKey(
                name: "CoachCategory_pk",
                table: "CoachCategory");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelUid",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "PlaceUid",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "PlaceUid",
                table: "GroupSession");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelUid",
                table: "DifficultyLevel");

            migrationBuilder.DropColumn(
                name: "CoachCategoryUid",
                table: "CoachType");

            migrationBuilder.DropColumn(
                name: "CoachCategoryUid",
                table: "CoachCategory");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyLevelId",
                table: "Template",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Place",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "GroupSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyLevelId",
                table: "DifficultyLevel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoachCategoryId",
                table: "CoachType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoachCategoryId",
                table: "CoachCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "Place_pk",
                table: "Place",
                column: "PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "DifficultyLevel_pk",
                table: "DifficultyLevel",
                column: "DifficultyLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType",
                columns: new[] { "CoachTypeUid", "CoachUid", "CoachCategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "CoachCategory_pk",
                table: "CoachCategory",
                column: "CoachCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_DifficultyLevelId",
                table: "Template",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSession_PlaceId",
                table: "GroupSession",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachType_CoachCategoryId",
                table: "CoachType",
                column: "CoachCategoryId");

            migrationBuilder.AddForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType",
                column: "CoachCategoryId",
                principalTable: "CoachCategory",
                principalColumn: "CoachCategoryId");

            migrationBuilder.AddForeignKey(
                name: "GroupSession_Place",
                table: "GroupSession",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "Template_DifficultyLevel",
                table: "Template",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevel",
                principalColumn: "DifficultyLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType");

            migrationBuilder.DropForeignKey(
                name: "GroupSession_Place",
                table: "GroupSession");

            migrationBuilder.DropForeignKey(
                name: "Template_DifficultyLevel",
                table: "Template");

            migrationBuilder.DropIndex(
                name: "IX_Template_DifficultyLevelId",
                table: "Template");

            migrationBuilder.DropPrimaryKey(
                name: "Place_pk",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_GroupSession_PlaceId",
                table: "GroupSession");

            migrationBuilder.DropPrimaryKey(
                name: "DifficultyLevel_pk",
                table: "DifficultyLevel");

            migrationBuilder.DropPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType");

            migrationBuilder.DropIndex(
                name: "IX_CoachType_CoachCategoryId",
                table: "CoachType");

            migrationBuilder.DropPrimaryKey(
                name: "CoachCategory_pk",
                table: "CoachCategory");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "GroupSession");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "DifficultyLevel");

            migrationBuilder.DropColumn(
                name: "CoachCategoryId",
                table: "CoachType");

            migrationBuilder.DropColumn(
                name: "CoachCategoryId",
                table: "CoachCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "DifficultyLevelUid",
                table: "Template",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceUid",
                table: "Place",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceUid",
                table: "GroupSession",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DifficultyLevelUid",
                table: "DifficultyLevel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoachCategoryUid",
                table: "CoachType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoachCategoryUid",
                table: "CoachCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "Place_pk",
                table: "Place",
                column: "PlaceUid");

            migrationBuilder.AddPrimaryKey(
                name: "DifficultyLevel_pk",
                table: "DifficultyLevel",
                column: "DifficultyLevelUid");

            migrationBuilder.AddPrimaryKey(
                name: "CoachType_pk",
                table: "CoachType",
                columns: new[] { "CoachTypeUid", "CoachUid", "CoachCategoryUid" });

            migrationBuilder.AddPrimaryKey(
                name: "CoachCategory_pk",
                table: "CoachCategory",
                column: "CoachCategoryUid");

            migrationBuilder.CreateIndex(
                name: "IX_Template_DifficultyLevelUid",
                table: "Template",
                column: "DifficultyLevelUid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSession_PlaceUid",
                table: "GroupSession",
                column: "PlaceUid");

            migrationBuilder.CreateIndex(
                name: "IX_CoachType_CoachCategoryUid",
                table: "CoachType",
                column: "CoachCategoryUid");

            migrationBuilder.AddForeignKey(
                name: "CoachType_CoachCategory",
                table: "CoachType",
                column: "CoachCategoryUid",
                principalTable: "CoachCategory",
                principalColumn: "CoachCategoryUid");

            migrationBuilder.AddForeignKey(
                name: "GroupSession_Place",
                table: "GroupSession",
                column: "PlaceUid",
                principalTable: "Place",
                principalColumn: "PlaceUid");

            migrationBuilder.AddForeignKey(
                name: "Template_DifficultyLevel",
                table: "Template",
                column: "DifficultyLevelUid",
                principalTable: "DifficultyLevel",
                principalColumn: "DifficultyLevelUid");
        }
    }
}
