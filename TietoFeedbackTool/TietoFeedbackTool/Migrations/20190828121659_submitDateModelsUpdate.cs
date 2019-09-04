using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class submitDateModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "PuzzleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    HaveOpenAnswer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuzzleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyKey = table.Column<string>(nullable: false),
                    AccountLogin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyKey);
                    table.ForeignKey(
                        name: "FK_Surveys_Accounts_AccountLogin",
                        column: x => x.AccountLogin,
                        principalTable: "Accounts",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyPuzzles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PuzzleTypeId = table.Column<int>(nullable: false),
                    SurveyKey = table.Column<string>(nullable: true),
                    PuzzleQuestion = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPuzzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyPuzzles_PuzzleTypes_PuzzleTypeId",
                        column: x => x.PuzzleTypeId,
                        principalTable: "PuzzleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyPuzzles_Surveys_SurveyKey",
                        column: x => x.SurveyKey,
                        principalTable: "Surveys",
                        principalColumn: "SurveyKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClosePuzzlePossibilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyPuzzleId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosePuzzlePossibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClosePuzzlePossibilities_SurveyPuzzles_SurveyPuzzleId",
                        column: x => x.SurveyPuzzleId,
                        principalTable: "SurveyPuzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenPuzzleAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyPuzzleId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(maxLength: 2000, nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenPuzzleAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenPuzzleAnswers_SurveyPuzzles_SurveyPuzzleId",
                        column: x => x.SurveyPuzzleId,
                        principalTable: "SurveyPuzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClosePuzzleAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClosePuzzlePossibilityId = table.Column<int>(nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosePuzzleAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClosePuzzleAnswers_ClosePuzzlePossibilities_ClosePuzzlePossibilityId",
                        column: x => x.ClosePuzzlePossibilityId,
                        principalTable: "ClosePuzzlePossibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClosePuzzleAnswers_ClosePuzzlePossibilityId",
                table: "ClosePuzzleAnswers",
                column: "ClosePuzzlePossibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosePuzzlePossibilities_SurveyPuzzleId",
                table: "ClosePuzzlePossibilities",
                column: "SurveyPuzzleId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenPuzzleAnswers_SurveyPuzzleId",
                table: "OpenPuzzleAnswers",
                column: "SurveyPuzzleId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPuzzles_PuzzleTypeId",
                table: "SurveyPuzzles",
                column: "PuzzleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPuzzles_SurveyKey",
                table: "SurveyPuzzles",
                column: "SurveyKey");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AccountLogin",
                table: "Surveys",
                column: "AccountLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosePuzzleAnswers");

            migrationBuilder.DropTable(
                name: "OpenPuzzleAnswers");

            migrationBuilder.DropTable(
                name: "ClosePuzzlePossibilities");

            migrationBuilder.DropTable(
                name: "SurveyPuzzles");

            migrationBuilder.DropTable(
                name: "PuzzleTypes");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
