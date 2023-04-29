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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
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
                    IdBodyPart = table.Column<int>(type: "int", nullable: false),
                    BodyPartName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BodyPart_pk", x => x.IdBodyPart);
                });

            migrationBuilder.CreateTable(
                name: "CoachCategory",
                columns: table => new
                {
                    IdCoachCategory = table.Column<int>(type: "int", nullable: false),
                    CoachCategoryName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CoachCategory_pk", x => x.IdCoachCategory);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevel",
                columns: table => new
                {
                    IdDifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevelName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DifficultyLevel_pk", x => x.IdDifficultyLevel);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    IdEquipment = table.Column<int>(type: "int", nullable: false),
                    EquipmentName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Equipment_pk", x => x.IdEquipment);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    IdPlace = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Place_pk", x => x.IdPlace);
                });

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    IdTarget = table.Column<int>(type: "int", nullable: false),
                    TargetName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Target_pk", x => x.IdTarget);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    IdClient = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_pk", x => x.IdClient);
                    table.ForeignKey(
                        name: "Client_AspNetUsers",
                        column: x => x.IdClient,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    IdCoach = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Coach_pk", x => x.IdCoach);
                    table.ForeignKey(
                        name: "Coach_AspNetUsers",
                        column: x => x.IdCoach,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    IdTemplate = table.Column<int>(type: "int", nullable: false),
                    TemplateName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    IdDifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    EstimatedTime = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    IsShared = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Template_pk", x => x.IdTemplate);
                    table.ForeignKey(
                        name: "Template_DifficultyLevel",
                        column: x => x.IdDifficultyLevel,
                        principalTable: "DifficultyLevel",
                        principalColumn: "IdDifficultyLevel");
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    IdExercise = table.Column<int>(type: "int", nullable: false),
                    ExerciseName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    IdBodyPart = table.Column<int>(type: "int", nullable: false),
                    IdTarget = table.Column<int>(type: "int", nullable: false),
                    IdEquipment = table.Column<int>(type: "int", nullable: false),
                    GifUrl = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Exercise_pk", x => x.IdExercise);
                    table.ForeignKey(
                        name: "Exercise_BodyPart",
                        column: x => x.IdBodyPart,
                        principalTable: "BodyPart",
                        principalColumn: "IdBodyPart");
                    table.ForeignKey(
                        name: "Exercise_Equipment",
                        column: x => x.IdEquipment,
                        principalTable: "Equipment",
                        principalColumn: "IdEquipment");
                    table.ForeignKey(
                        name: "Exercise_Target",
                        column: x => x.IdTarget,
                        principalTable: "Target",
                        principalColumn: "IdTarget");
                });

            migrationBuilder.CreateTable(
                name: "CoachHour",
                columns: table => new
                {
                    CoachHourId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdCoach = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IdClient = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CoachHour_pk", x => x.CoachHourId);
                    table.ForeignKey(
                        name: "CoachHour_Client",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "CoachHour_Coach",
                        column: x => x.IdCoach,
                        principalTable: "Coach",
                        principalColumn: "IdCoach");
                });

            migrationBuilder.CreateTable(
                name: "CoachType",
                columns: table => new
                {
                    IdCoachCategory = table.Column<int>(type: "int", nullable: false),
                    IdCoach = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CoachType_pk", x => new { x.IdCoachCategory, x.IdCoach });
                    table.ForeignKey(
                        name: "CoachType_Coach",
                        column: x => x.IdCoach,
                        principalTable: "Coach",
                        principalColumn: "IdCoach");
                    table.ForeignKey(
                        name: "CoachType_CoachCategory",
                        column: x => x.IdCoachCategory,
                        principalTable: "CoachCategory",
                        principalColumn: "IdCoachCategory");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteCoach",
                columns: table => new
                {
                    IdFavoriteCoach = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCoach = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FavoriteCoach_pk", x => new { x.IdFavoriteCoach, x.IdClient, x.IdCoach });
                    table.ForeignKey(
                        name: "FavoriteCoach_Client",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FavoriteCoach_Coach",
                        column: x => x.IdCoach,
                        principalTable: "Coach",
                        principalColumn: "IdCoach");
                });

            migrationBuilder.CreateTable(
                name: "GroupSession",
                columns: table => new
                {
                    IdGroupSession = table.Column<int>(type: "int", nullable: false),
                    SessionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Slots = table.Column<int>(type: "int", nullable: false),
                    SessionStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SessionEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    IdPlace = table.Column<int>(type: "int", nullable: false),
                    IdCoach = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GroupSession_pk", x => x.IdGroupSession);
                    table.ForeignKey(
                        name: "GroupSession_Coach",
                        column: x => x.IdCoach,
                        principalTable: "Coach",
                        principalColumn: "IdCoach");
                    table.ForeignKey(
                        name: "GroupSession_Place",
                        column: x => x.IdPlace,
                        principalTable: "Place",
                        principalColumn: "IdPlace");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "int", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "date", nullable: false),
                    TrainingName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    IdTemplate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Training_pk", x => x.IdTraining);
                    table.ForeignKey(
                        name: "Training_Template",
                        column: x => x.IdTemplate,
                        principalTable: "Template",
                        principalColumn: "IdTemplate");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteExercise",
                columns: table => new
                {
                    FavoriteExercise = table.Column<int>(type: "int", nullable: false),
                    IdExercise = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FavoriteExercise_pk", x => new { x.IdExercise, x.IdUser, x.FavoriteExercise });
                    table.ForeignKey(
                        name: "FavoriteExercise_AspNetUsers",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserExercise_Exercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "IdExercise");
                });

            migrationBuilder.CreateTable(
                name: "TemplateExercise",
                columns: table => new
                {
                    IdTemplateExercise = table.Column<int>(type: "int", nullable: false),
                    IdExercise = table.Column<int>(type: "int", nullable: false),
                    IdTemplate = table.Column<int>(type: "int", nullable: false),
                    NumberOfSets = table.Column<int>(type: "int", nullable: false),
                    NumberOfReps = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(160)", unicode: false, maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TemplateExercise_pk", x => new { x.IdExercise, x.IdTemplate, x.IdTemplateExercise });
                    table.ForeignKey(
                        name: "Table_9_Exercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "IdExercise");
                    table.ForeignKey(
                        name: "TemplateExercise_Template",
                        column: x => x.IdTemplate,
                        principalTable: "Template",
                        principalColumn: "IdTemplate");
                });

            migrationBuilder.CreateTable(
                name: "ClientGroupSession",
                columns: table => new
                {
                    IdGroupSession = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClientGroupSession_pk", x => new { x.IdGroupSession, x.IdClient });
                    table.ForeignKey(
                        name: "ClientGroupSession_Client",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "ClientGroupSession_GroupSession",
                        column: x => x.IdGroupSession,
                        principalTable: "GroupSession",
                        principalColumn: "IdGroupSession");
                });

            migrationBuilder.CreateTable(
                name: "UserTraining",
                columns: table => new
                {
                    IdUserTraining = table.Column<int>(type: "int", nullable: false),
                    IdTraining = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserTraining_pk", x => new { x.IdTraining, x.IdUser, x.IdUserTraining });
                    table.ForeignKey(
                        name: "UserTraining_AspNetUsers",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserTraining_Training",
                        column: x => x.IdTraining,
                        principalTable: "Training",
                        principalColumn: "IdTraining");
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
                name: "IX_CoachHour_IdClient",
                table: "CoachHour",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_CoachHour_IdCoach",
                table: "CoachHour",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_CoachType_IdCoach",
                table: "CoachType",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdBodyPart",
                table: "Exercise",
                column: "IdBodyPart");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdEquipment",
                table: "Exercise",
                column: "IdEquipment");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdTarget",
                table: "Exercise",
                column: "IdTarget");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCoach_IdClient",
                table: "FavoriteCoach",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCoach_IdCoach",
                table: "FavoriteCoach",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteExercise_IdUser",
                table: "FavoriteExercise",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSession_IdCoach",
                table: "GroupSession",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSession_IdPlace",
                table: "GroupSession",
                column: "IdPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Template_IdDifficultyLevel",
                table: "Template",
                column: "IdDifficultyLevel");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_IdTemplate",
                table: "TemplateExercise",
                column: "IdTemplate");

            migrationBuilder.CreateIndex(
                name: "IX_Training_IdTemplate",
                table: "Training",
                column: "IdTemplate");

            migrationBuilder.CreateIndex(
                name: "IX_UserTraining_IdUser",
                table: "UserTraining",
                column: "IdUser");
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
                name: "FavoriteCoach");

            migrationBuilder.DropTable(
                name: "FavoriteExercise");

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
