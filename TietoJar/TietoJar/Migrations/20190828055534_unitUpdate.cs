using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class unitUpdate : Migration
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountLogin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SurveyKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
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
                    SurveyId = table.Column<int>(nullable: false),
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
                        name: "FK_SurveyPuzzles_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClosePuzzlePossibilities",
                columns: table => new
                {
                    PuzzleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    SurveyPuzzleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosePuzzlePossibilities", x => x.PuzzleId);
                    table.ForeignKey(
                        name: "FK_ClosePuzzlePossibilities_SurveyPuzzles_SurveyPuzzleId",
                        column: x => x.SurveyPuzzleId,
                        principalTable: "SurveyPuzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenPuzzleAnswers",
                columns: table => new
                {
                    PuzzleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(maxLength: 2000, nullable: false),
                    SurveyPuzzleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenPuzzleAnswers", x => x.PuzzleId);
                    table.ForeignKey(
                        name: "FK_OpenPuzzleAnswers_SurveyPuzzles_SurveyPuzzleId",
                        column: x => x.SurveyPuzzleId,
                        principalTable: "SurveyPuzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_SurveyPuzzles_SurveyId",
                table: "SurveyPuzzles",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AccountLogin",
                table: "Surveys",
                column: "AccountLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosePuzzlePossibilities");

            migrationBuilder.DropTable(
                name: "OpenPuzzleAnswers");

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
