using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyPart",
                columns: table => new
                {
                    BodyPartUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BodyPartName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BodyPart_pk", x => x.BodyPartUid);
                });

            migrationBuilder.CreateTable(
                name: "CoachCategory",
                columns: table => new
                {
                    CoachCategoryUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachCategoryName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CoachCategory_pk", x => x.CoachCategoryUid);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevel",
                columns: table => new
                {
                    DifficultyLevelUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyLevelName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DifficultyLevel_pk", x => x.DifficultyLevelUid);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Equipment_pk", x => x.EquipmentUid);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Place_pk", x => x.PlaceUid);
                });

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    TargetUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Target_pk", x => x.TargetUid);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_pk", x => x.ClientUid);
                    table.ForeignKey(
                        name: "Client_AspNetUsers",
                        column: x => x.ClientUid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Coach_pk", x => x.CoachUid);
                    table.ForeignKey(
                        name: "Coach_AspNetUsers",
                        column: x => x.CoachUid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    TemplateUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    DifficultyLevelUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimatedTime = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    IsShared = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Template_pk", x => x.TemplateUid);
                    table.ForeignKey(
                        name: "Template_DifficultyLevel",
                        column: x => x.DifficultyLevelUid,
                        principalTable: "DifficultyLevel",
                        principalColumn: "DifficultyLevelUid");
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    BodyPartUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GifUrl = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Exercise_pk", x => x.ExerciseUid);
                    table.ForeignKey(
                        name: "Exercise_BodyPart",
                        column: x => x.BodyPartUid,
                        principalTable: "BodyPart",
                        principalColumn: "BodyPartUid");
                    table.ForeignKey(
                        name: "Exercise_Equipment",
                        column: x => x.EquipmentUid,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentUid");
                    table.ForeignKey(
                        name: "Exercise_Target",
                        column: x => x.TargetUid,
                        principalTable: "Target",
                        principalColumn: "TargetUid");
                });

            migrationBuilder.CreateTable(
                name: "CoachHour",
                columns: table => new
                {
                    CoachHourUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CoachUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CoachHour_pk", x => x.CoachHourUid);
                    table.ForeignKey(
                        name: "CoachHour_Client",
                        column: x => x.ClientUid,
                        principalTable: "Client",
                        principalColumn: "ClientUid");
                    table.ForeignKey(
                        name: "CoachHour_Coach",
                        column: x => x.CoachUid,
                        principalTable: "Coach",
                        principalColumn: "CoachUid");
                });

            migrationBuilder.CreateTable(
                name: "CoachType",
                columns: table => new
                {
                    IdCoachCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCoach = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CoachType_pk", x => new { x.IdCoachCategory, x.IdCoach });
                    table.ForeignKey(
                        name: "CoachType_Coach",
                        column: x => x.IdCoach,
                        principalTable: "Coach",
                        principalColumn: "CoachUid");
                    table.ForeignKey(
                        name: "CoachType_CoachCategory",
                        column: x => x.IdCoachCategory,
                        principalTable: "CoachCategory",
                        principalColumn: "CoachCategoryUid");
                });

            migrationBuilder.CreateTable(
                name: "FavouriteCoach",
                columns: table => new
                {
                    FavouriteCoachUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FavouriteCoach_pk", x => new { x.FavouriteCoachUid, x.ClientUid, x.CoachUid });
                    table.ForeignKey(
                        name: "FavouriteCoach_Client",
                        column: x => x.ClientUid,
                        principalTable: "Client",
                        principalColumn: "ClientUid");
                    table.ForeignKey(
                        name: "FavouriteCoach_Coach",
                        column: x => x.CoachUid,
                        principalTable: "Coach",
                        principalColumn: "CoachUid");
                });

            migrationBuilder.CreateTable(
                name: "GroupSession",
                columns: table => new
                {
                    GroupSessionUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Slots = table.Column<int>(type: "int", nullable: false),
                    SessionStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SessionEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    PlaceUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GroupSession_pk", x => x.GroupSessionUid);
                    table.ForeignKey(
                        name: "GroupSession_Coach",
                        column: x => x.CoachUid,
                        principalTable: "Coach",
                        principalColumn: "CoachUid");
                    table.ForeignKey(
                        name: "GroupSession_Place",
                        column: x => x.PlaceUid,
                        principalTable: "Place",
                        principalColumn: "PlaceUid");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    TrainingUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "date", nullable: false),
                    TrainingName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    TemplateUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Training_pk", x => x.TrainingUid);
                    table.ForeignKey(
                        name: "Training_Template",
                        column: x => x.TemplateUid,
                        principalTable: "Template",
                        principalColumn: "TemplateUid");
                });

            migrationBuilder.CreateTable(
                name: "FavouriteExercise",
                columns: table => new
                {
                    FavouriteExercise = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FavouriteExercise_pk", x => new { x.FavouriteExercise, x.UserUid, x.ExerciseUid });
                    table.ForeignKey(
                        name: "FavouriteExercise_AspNetUsers",
                        column: x => x.UserUid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserExercise_Exercise",
                        column: x => x.ExerciseUid,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseUid");
                });

            migrationBuilder.CreateTable(
                name: "TemplateExercise",
                columns: table => new
                {
                    TemplateExerciseUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfSets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfReps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(160)", unicode: false, maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TemplateExercise_pk", x => new { x.TemplateExerciseUid, x.ExerciseUid, x.TemplateUid });
                    table.ForeignKey(
                        name: "TemplateExercise_Exercise",
                        column: x => x.ExerciseUid,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseUid");
                    table.ForeignKey(
                        name: "TemplateExercise_Template",
                        column: x => x.TemplateUid,
                        principalTable: "Template",
                        principalColumn: "TemplateUid");
                });

            migrationBuilder.CreateTable(
                name: "ClientGroupSession",
                columns: table => new
                {
                    IdGroupSession = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClientGroupSession_pk", x => new { x.IdGroupSession, x.IdClient });
                    table.ForeignKey(
                        name: "ClientGroupSession_Client",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "ClientUid");
                    table.ForeignKey(
                        name: "ClientGroupSession_GroupSession",
                        column: x => x.IdGroupSession,
                        principalTable: "GroupSession",
                        principalColumn: "GroupSessionUid");
                });

            migrationBuilder.CreateTable(
                name: "UserTraining",
                columns: table => new
                {
                    UserTrainingUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserTraining_pk", x => new { x.UserTrainingUid, x.UserUid, x.TrainingUid });
                    table.ForeignKey(
                        name: "UserTraining_AspNetUsers",
                        column: x => x.UserUid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserTraining_Training",
                        column: x => x.TrainingUid,
                        principalTable: "Training",
                        principalColumn: "TrainingUid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGroupSession_IdClient",
                table: "ClientGroupSession",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_CoachHour_ClientUid",
                table: "CoachHour",
                column: "ClientUid");

            migrationBuilder.CreateIndex(
                name: "IX_CoachHour_CoachUid",
                table: "CoachHour",
                column: "CoachUid");

            migrationBuilder.CreateIndex(
                name: "IX_CoachType_IdCoach",
                table: "CoachType",
                column: "IdCoach");

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

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteCoach_ClientUid",
                table: "FavouriteCoach",
                column: "ClientUid");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteCoach_CoachUid",
                table: "FavouriteCoach",
                column: "CoachUid");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteExercise_ExerciseUid",
                table: "FavouriteExercise",
                column: "ExerciseUid");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteExercise_UserUid",
                table: "FavouriteExercise",
                column: "UserUid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSession_CoachUid",
                table: "GroupSession",
                column: "CoachUid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSession_PlaceUid",
                table: "GroupSession",
                column: "PlaceUid");

            migrationBuilder.CreateIndex(
                name: "IX_Template_DifficultyLevelUid",
                table: "Template",
                column: "DifficultyLevelUid");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_ExerciseUid",
                table: "TemplateExercise",
                column: "ExerciseUid");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_TemplateUid",
                table: "TemplateExercise",
                column: "TemplateUid");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TemplateUid",
                table: "Training",
                column: "TemplateUid");

            migrationBuilder.CreateIndex(
                name: "IX_UserTraining_TrainingUid",
                table: "UserTraining",
                column: "TrainingUid");

            migrationBuilder.CreateIndex(
                name: "IX_UserTraining_UserUid",
                table: "UserTraining",
                column: "UserUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientGroupSession");

            migrationBuilder.DropTable(
                name: "CoachHour");

            migrationBuilder.DropTable(
                name: "CoachType");

            migrationBuilder.DropTable(
                name: "FavouriteCoach");

            migrationBuilder.DropTable(
                name: "FavouriteExercise");

            migrationBuilder.DropTable(
                name: "TemplateExercise");

            migrationBuilder.DropTable(
                name: "UserTraining");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GroupSession");

            migrationBuilder.DropTable(
                name: "CoachCategory");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "BodyPart");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DifficultyLevel");
        }
    }
}
