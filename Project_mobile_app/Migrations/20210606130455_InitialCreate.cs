using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_mobile_app.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PlayingTime = table.Column<short>(type: "smallint", nullable: true),
                    Limit = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Introduction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Introduction_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    IsInitial = table.Column<bool>(type: "bit", nullable: false),
                    PartOfGameId = table.Column<int>(type: "int", nullable: false),
                    State1Requirement = table.Column<short>(type: "smallint", nullable: true),
                    State2Requirement = table.Column<short>(type: "smallint", nullable: true),
                    State3Requirement = table.Column<short>(type: "smallint", nullable: true),
                    State4Requirement = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stop_Game_PartOfGameId",
                        column: x => x.PartOfGameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ChoiceForTextQuestion_QuestionId = table.Column<int>(type: "int", nullable: true),
                    ChoiceForTextQuestion_Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseRegex = table.Column<bool>(type: "bit", nullable: true),
                    DiffUpperCase = table.Column<bool>(type: "bit", nullable: true),
                    DefaultChoice_QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_Question_DefaultChoice_QuestionId",
                        column: x => x.DefaultChoice_QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choice_Question_ChoiceForTextQuestion_QuestionId",
                        column: x => x.ChoiceForTextQuestion_QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Choice_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameUser",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUser", x => new { x.GamesId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_GameUser_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUser_User_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TimeInGames = table.Column<int>(type: "int", nullable: false),
                    NumberOfGamesPlayed = table.Column<short>(type: "smallint", nullable: false),
                    SuccesfullGames = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisplayObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroductionId = table.Column<int>(type: "int", nullable: true),
                    PositionInIntroduction = table.Column<short>(type: "smallint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OwnText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisplayObject_Introduction_IntroductionId",
                        column: x => x.IntroductionId,
                        principalTable: "Introduction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MapPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IntroductionId = table.Column<int>(type: "int", nullable: true),
                    PositionOfStopId = table.Column<int>(type: "int", nullable: true),
                    IsVisibleAsStopPosition = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapPositions_Introduction_IntroductionId",
                        column: x => x.IntroductionId,
                        principalTable: "Introduction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MapPositions_Stop_PositionOfStopId",
                        column: x => x.PositionOfStopId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PasswordGameRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordGameRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordGameRequirement_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionStop",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    StopsThatOpenThisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionStop", x => new { x.QuestionsId, x.StopsThatOpenThisId });
                    table.ForeignKey(
                        name: "FK_QuestionStop_Question_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionStop_Stop_StopsThatOpenThisId",
                        column: x => x.StopsThatOpenThisId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StopStop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopOpensThisId = table.Column<int>(type: "int", nullable: false),
                    OpensId = table.Column<int>(type: "int", nullable: false),
                    IfUnvisible = table.Column<byte>(type: "tinyint", nullable: false),
                    IfVisible = table.Column<byte>(type: "tinyint", nullable: false),
                    IfUnlocked = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StopStop_Stop_OpensId",
                        column: x => x.OpensId,
                        principalTable: "Stop",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StopStop_Stop_StopOpensThisId",
                        column: x => x.StopOpensThisId,
                        principalTable: "Stop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChoiceStop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceOpensThisId = table.Column<int>(type: "int", nullable: false),
                    OpensId = table.Column<int>(type: "int", nullable: false),
                    IfUnvisible = table.Column<byte>(type: "tinyint", nullable: false),
                    IfVisible = table.Column<byte>(type: "tinyint", nullable: false),
                    IfUnlocked = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChoiceStop_Choice_ChoiceOpensThisId",
                        column: x => x.ChoiceOpensThisId,
                        principalTable: "Choice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChoiceStop_Stop_OpensId",
                        column: x => x.OpensId,
                        principalTable: "Stop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoice",
                columns: table => new
                {
                    ChoicesThatOpensThisId = table.Column<int>(type: "int", nullable: false),
                    OpensQuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoice", x => new { x.ChoicesThatOpensThisId, x.OpensQuestionsId });
                    table.ForeignKey(
                        name: "FK_QuestionChoice_Choice_ChoicesThatOpensThisId",
                        column: x => x.ChoicesThatOpensThisId,
                        principalTable: "Choice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionChoice_Question_OpensQuestionsId",
                        column: x => x.OpensQuestionsId,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisplayObjectStopDisplayAfterDisplay",
                columns: table => new
                {
                    StopId = table.Column<int>(type: "int", nullable: false),
                    DisplayObjectId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayObjectStopDisplayAfterDisplay", x => new { x.StopId, x.DisplayObjectId });
                    table.ForeignKey(
                        name: "FK_DisplayObjectStopDisplayAfterDisplay_DisplayObject_DisplayObjectId",
                        column: x => x.DisplayObjectId,
                        principalTable: "DisplayObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisplayObjectStopDisplayAfterDisplay_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisplayObjectStopDisplayAfterUnlock",
                columns: table => new
                {
                    StopId = table.Column<int>(type: "int", nullable: false),
                    DisplayObjectId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayObjectStopDisplayAfterUnlock", x => new { x.StopId, x.DisplayObjectId });
                    table.ForeignKey(
                        name: "FK_DisplayObjectStopDisplayAfterUnlock_DisplayObject_DisplayObjectId",
                        column: x => x.DisplayObjectId,
                        principalTable: "DisplayObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisplayObjectStopDisplayAfterUnlock_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceMapPosition",
                columns: table => new
                {
                    ChoicesThatOpenThisId = table.Column<int>(type: "int", nullable: false),
                    OpensMapPositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceMapPosition", x => new { x.ChoicesThatOpenThisId, x.OpensMapPositionsId });
                    table.ForeignKey(
                        name: "FK_ChoiceMapPosition_Choice_ChoicesThatOpenThisId",
                        column: x => x.ChoicesThatOpenThisId,
                        principalTable: "Choice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceMapPosition_MapPositions_OpensMapPositionsId",
                        column: x => x.OpensMapPositionsId,
                        principalTable: "MapPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapPositionStop",
                columns: table => new
                {
                    PositionsDisplayAfterDisplayId = table.Column<int>(type: "int", nullable: false),
                    StopDisplayAfterDisplayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPositionStop", x => new { x.PositionsDisplayAfterDisplayId, x.StopDisplayAfterDisplayId });
                    table.ForeignKey(
                        name: "FK_MapPositionStop_MapPositions_PositionsDisplayAfterDisplayId",
                        column: x => x.PositionsDisplayAfterDisplayId,
                        principalTable: "MapPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapPositionStop_Stop_StopDisplayAfterDisplayId",
                        column: x => x.StopDisplayAfterDisplayId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapPositionStop1",
                columns: table => new
                {
                    PositionsDisplayAfterUnlockId = table.Column<int>(type: "int", nullable: false),
                    StopDisplayAfterUnlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPositionStop1", x => new { x.PositionsDisplayAfterUnlockId, x.StopDisplayAfterUnlockId });
                    table.ForeignKey(
                        name: "FK_MapPositionStop1_MapPositions_PositionsDisplayAfterUnlockId",
                        column: x => x.PositionsDisplayAfterUnlockId,
                        principalTable: "MapPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapPositionStop1_Stop_StopDisplayAfterUnlockId",
                        column: x => x.StopDisplayAfterUnlockId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UseRegex = table.Column<bool>(type: "bit", nullable: false),
                    DiffUpperCase = table.Column<bool>(type: "bit", nullable: false),
                    PasswordGameRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePasswords_PasswordGameRequirement_PasswordGameRequirementId",
                        column: x => x.PasswordGameRequirementId,
                        principalTable: "PasswordGameRequirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisplayObject_IntroductionId",
                table: "DisplayObject",
                column: "IntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_DisplayObjectStopDisplayAfterDisplay_DisplayObjectId",
                table: "DisplayObjectStopDisplayAfterDisplay",
                column: "DisplayObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DisplayObjectStopDisplayAfterUnlock_DisplayObjectId",
                table: "DisplayObjectStopDisplayAfterUnlock",
                column: "DisplayObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePasswords_PasswordGameRequirementId",
                table: "GamePasswords",
                column: "PasswordGameRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUser_OwnersId",
                table: "GameUser",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_DefaultChoice_QuestionId",
                table: "Choice",
                column: "DefaultChoice_QuestionId",
                unique: true,
                filter: "[DefaultChoice_QuestionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_ChoiceForTextQuestion_QuestionId",
                table: "Choice",
                column: "ChoiceForTextQuestion_QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionId",
                table: "Choice",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceMapPosition_OpensMapPositionsId",
                table: "ChoiceMapPosition",
                column: "OpensMapPositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceStop_ChoiceOpensThisId",
                table: "ChoiceStop",
                column: "ChoiceOpensThisId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceStop_OpensId",
                table: "ChoiceStop",
                column: "OpensId");

            migrationBuilder.CreateIndex(
                name: "IX_Introduction_GameId",
                table: "Introduction",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MapPositions_IntroductionId",
                table: "MapPositions",
                column: "IntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_MapPositions_PositionOfStopId",
                table: "MapPositions",
                column: "PositionOfStopId",
                unique: true,
                filter: "[PositionOfStopId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MapPositionStop_StopDisplayAfterDisplayId",
                table: "MapPositionStop",
                column: "StopDisplayAfterDisplayId");

            migrationBuilder.CreateIndex(
                name: "IX_MapPositionStop1_StopDisplayAfterUnlockId",
                table: "MapPositionStop1",
                column: "StopDisplayAfterUnlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordGameRequirement_StopId",
                table: "PasswordGameRequirement",
                column: "StopId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoice_OpensQuestionsId",
                table: "QuestionChoice",
                column: "OpensQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionStop_StopsThatOpenThisId",
                table: "QuestionStop",
                column: "StopsThatOpenThisId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stop_PartOfGameId",
                table: "Stop",
                column: "PartOfGameId");

            migrationBuilder.CreateIndex(
                name: "IX_StopStop_OpensId",
                table: "StopStop",
                column: "OpensId");

            migrationBuilder.CreateIndex(
                name: "IX_StopStop_StopOpensThisId",
                table: "StopStop",
                column: "StopOpensThisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "DisplayObjectStopDisplayAfterDisplay");

            migrationBuilder.DropTable(
                name: "DisplayObjectStopDisplayAfterUnlock");

            migrationBuilder.DropTable(
                name: "GamePasswords");

            migrationBuilder.DropTable(
                name: "GameUser");

            migrationBuilder.DropTable(
                name: "ChoiceMapPosition");

            migrationBuilder.DropTable(
                name: "ChoiceStop");

            migrationBuilder.DropTable(
                name: "MapPositionStop");

            migrationBuilder.DropTable(
                name: "MapPositionStop1");

            migrationBuilder.DropTable(
                name: "QuestionChoice");

            migrationBuilder.DropTable(
                name: "QuestionStop");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "StopStop");

            migrationBuilder.DropTable(
                name: "DisplayObject");

            migrationBuilder.DropTable(
                name: "PasswordGameRequirement");

            migrationBuilder.DropTable(
                name: "MapPositions");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Introduction");

            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
