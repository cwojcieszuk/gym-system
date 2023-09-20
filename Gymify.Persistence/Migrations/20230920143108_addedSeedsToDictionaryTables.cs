using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedsToDictionaryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BodyPart",
                columns: new[] { "BodyPartId", "BodyPartName" },
                values: new object[,]
                {
                    { 0, "Waist" },
                    { 1, "Upper legs" },
                    { 2, "Back" },
                    { 3, "Lower legs" },
                    { 4, "Chest" },
                    { 5, "Upper arms" },
                    { 6, "Cardio" },
                    { 7, "Shoulders" },
                    { 8, "Lower arms" },
                    { 9, "Neck" }
                });

            migrationBuilder.InsertData(
                table: "CoachCategory",
                columns: new[] { "CoachCategoryId", "CoachCategoryName" },
                values: new object[,]
                {
                    { 0, "Fitness" },
                    { 1, "Group fitness instructor" },
                    { 2, "Cross fit trainer" },
                    { 3, "Rehabilitation" },
                    { 4, "Core Strengthening" },
                    { 5, "Bodybuilding" },
                    { 6, "Weight loss" },
                    { 7, "Cardiovascular" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "EquipmentId", "EquipmentName" },
                values: new object[,]
                {
                    { 0, "Body weight" },
                    { 1, "Cable" },
                    { 2, "Leverage machine" },
                    { 3, "Assisted" },
                    { 4, "Medicine ball" },
                    { 5, "Stability ball" },
                    { 6, "Band" },
                    { 7, "Barbell" },
                    { 8, "Rope" },
                    { 9, "Dumbell" },
                    { 10, "Ez barbell" },
                    { 11, "Sled machine" },
                    { 12, "Upper body ergometer" },
                    { 13, "Kettlebell" },
                    { 14, "Olympic barbell" },
                    { 15, "Weighted" },
                    { 16, "Bosu ball" },
                    { 17, "Resistance band" },
                    { 18, "Roller" },
                    { 19, "Skierg machine" },
                    { 20, "Hammer" },
                    { 21, "Smith machine" },
                    { 22, "Wheel roller" },
                    { 23, "Stationary bike" },
                    { 24, "Tire" },
                    { 25, "Trap bar" },
                    { 26, "Elliptical machine" },
                    { 27, "Stepmill machine" }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "PlaceId", "PlaceName" },
                values: new object[,]
                {
                    { 0, "Cardio area" },
                    { 1, "Weightlifting zone" },
                    { 2, "Free weights zone" },
                    { 3, "Weightlifting section" },
                    { 4, "Stretching zone" },
                    { 5, "Group fitness studio" },
                    { 6, "Martial arts area" },
                    { 7, "Locker room" },
                    { 8, "Sauna" },
                    { 9, "Massage and recovery center" }
                });

            migrationBuilder.InsertData(
                table: "Target",
                columns: new[] { "TargetId", "TargetName" },
                values: new object[,]
                {
                    { 0, "Abs" },
                    { 1, "Quads" },
                    { 2, "Lats" },
                    { 3, "Calves" },
                    { 4, "Pectorals" },
                    { 5, "Glutes" },
                    { 6, "Hamstrings" },
                    { 7, "Adductors" },
                    { 8, "Triceps" },
                    { 9, "Cardiovascular system" },
                    { 10, "Spine" },
                    { 11, "Upper back" },
                    { 12, "Biceps" },
                    { 13, "Delts" },
                    { 14, "Forearms" },
                    { 15, "Traps" },
                    { 16, "Serratus anterior" },
                    { 17, "Abductors" },
                    { 18, "Levator scapulae" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BodyPart",
                keyColumn: "BodyPartId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CoachCategory",
                keyColumn: "CoachCategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Place",
                keyColumn: "PlaceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Target",
                keyColumn: "TargetId",
                keyValue: 18);
        }
    }
}
