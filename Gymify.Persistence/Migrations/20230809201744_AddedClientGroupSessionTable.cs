using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedClientGroupSessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ClientGroupSession_pk",
                table: "ClientGroupSession");

            migrationBuilder.RenameColumn(
                name: "FavouriteExercise",
                table: "FavouriteExercise",
                newName: "FavouriteExerciseUid");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "ClientGroupSession",
                newName: "ClientUid");

            migrationBuilder.RenameColumn(
                name: "IdGroupSession",
                table: "ClientGroupSession",
                newName: "GroupSessionUid");

            migrationBuilder.RenameIndex(
                name: "IX_ClientGroupSession_IdClient",
                table: "ClientGroupSession",
                newName: "IX_ClientGroupSession_ClientUid");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientGroupSessionUid",
                table: "ClientGroupSession",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "ClientGroupSession_pk",
                table: "ClientGroupSession",
                columns: new[] { "ClientGroupSessionUid", "GroupSessionUid", "ClientUid" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupSession_GroupSessionUid",
                table: "ClientGroupSession",
                column: "GroupSessionUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ClientGroupSession_pk",
                table: "ClientGroupSession");

            migrationBuilder.DropIndex(
                name: "IX_ClientGroupSession_GroupSessionUid",
                table: "ClientGroupSession");

            migrationBuilder.DropColumn(
                name: "ClientGroupSessionUid",
                table: "ClientGroupSession");

            migrationBuilder.RenameColumn(
                name: "FavouriteExerciseUid",
                table: "FavouriteExercise",
                newName: "FavouriteExercise");

            migrationBuilder.RenameColumn(
                name: "ClientUid",
                table: "ClientGroupSession",
                newName: "IdClient");

            migrationBuilder.RenameColumn(
                name: "GroupSessionUid",
                table: "ClientGroupSession",
                newName: "IdGroupSession");

            migrationBuilder.RenameIndex(
                name: "IX_ClientGroupSession_ClientUid",
                table: "ClientGroupSession",
                newName: "IX_ClientGroupSession_IdClient");

            migrationBuilder.AddPrimaryKey(
                name: "ClientGroupSession_pk",
                table: "ClientGroupSession",
                columns: new[] { "IdGroupSession", "IdClient" });
        }
    }
}
