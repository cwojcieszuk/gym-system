using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUidsToIntsInExercisesDicts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Exercise_BodyPart",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "Exercise_Equipment",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "Exercise_Target",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "Target_pk",
                table: "Target");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_BodyPartUid",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_EquipmentUid",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_TargetUid",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "Equipment_pk",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "BodyPart_pk",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "TargetUid",
                table: "Target");

            migrationBuilder.DropColumn(
                name: "BodyPartUid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "EquipmentUid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TargetUid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "EquipmentUid",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "BodyPartUid",
                table: "BodyPart");

            migrationBuilder.AddColumn<int>(
                name: "TargetId",
                table: "Target",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodyPartId",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetId",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodyPartId",
                table: "BodyPart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "Target_pk",
                table: "Target",
                column: "TargetId");

            migrationBuilder.AddPrimaryKey(
                name: "Equipment_pk",
                table: "Equipment",
                column: "EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "BodyPart_pk",
                table: "BodyPart",
                column: "BodyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_BodyPartId",
                table: "Exercise",
                column: "BodyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_EquipmentId",
                table: "Exercise",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TargetId",
                table: "Exercise",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "Exercise_BodyPart",
                table: "Exercise",
                column: "BodyPartId",
                principalTable: "BodyPart",
                principalColumn: "BodyPartId");

            migrationBuilder.AddForeignKey(
                name: "Exercise_Equipment",
                table: "Exercise",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "Exercise_Target",
                table: "Exercise",
                column: "TargetId",
                principalTable: "Target",
                principalColumn: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Exercise_BodyPart",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "Exercise_Equipment",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "Exercise_Target",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "Target_pk",
                table: "Target");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_BodyPartId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_EquipmentId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_TargetId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "Equipment_pk",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "BodyPart_pk",
                table: "BodyPart");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Target");

            migrationBuilder.DropColumn(
                name: "BodyPartId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "BodyPartId",
                table: "BodyPart");

            migrationBuilder.AddColumn<Guid>(
                name: "TargetUid",
                table: "Target",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BodyPartUid",
                table: "Exercise",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentUid",
                table: "Exercise",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TargetUid",
                table: "Exercise",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentUid",
                table: "Equipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BodyPartUid",
                table: "BodyPart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "Target_pk",
                table: "Target",
                column: "TargetUid");

            migrationBuilder.AddPrimaryKey(
                name: "Equipment_pk",
                table: "Equipment",
                column: "EquipmentUid");

            migrationBuilder.AddPrimaryKey(
                name: "BodyPart_pk",
                table: "BodyPart",
                column: "BodyPartUid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_BodyPartUid",
                table: "Exercise",
                column: "BodyPartUid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_EquipmentUid",
                table: "Exercise",
                column: "EquipmentUid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TargetUid",
                table: "Exercise",
                column: "TargetUid");

            migrationBuilder.AddForeignKey(
                name: "Exercise_BodyPart",
                table: "Exercise",
                column: "BodyPartUid",
                principalTable: "BodyPart",
                principalColumn: "BodyPartUid");

            migrationBuilder.AddForeignKey(
                name: "Exercise_Equipment",
                table: "Exercise",
                column: "EquipmentUid",
                principalTable: "Equipment",
                principalColumn: "EquipmentUid");

            migrationBuilder.AddForeignKey(
                name: "Exercise_Target",
                table: "Exercise",
                column: "TargetUid",
                principalTable: "Target",
                principalColumn: "TargetUid");
        }
    }
}
