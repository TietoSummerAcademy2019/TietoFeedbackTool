using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosePuzzlePossibilities_SurveyPuzzles_SurveySurveyPuzzleId",
                table: "ClosePuzzlePossibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenPuzzleAnswers_SurveyPuzzles_SurveySurveyPuzzleId",
                table: "OpenPuzzleAnswers");

            migrationBuilder.DropIndex(
                name: "IX_OpenPuzzleAnswers_SurveySurveyPuzzleId",
                table: "OpenPuzzleAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ClosePuzzlePossibilities_SurveySurveyPuzzleId",
                table: "ClosePuzzlePossibilities");

            migrationBuilder.DropColumn(
                name: "SurveySurveyPuzzleId",
                table: "OpenPuzzleAnswers");

            migrationBuilder.DropColumn(
                name: "SurveySurveyPuzzleId",
                table: "ClosePuzzlePossibilities");

            migrationBuilder.CreateIndex(
                name: "IX_OpenPuzzleAnswers_SurveyPuzzleId",
                table: "OpenPuzzleAnswers",
                column: "SurveyPuzzleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosePuzzlePossibilities_SurveyPuzzleId",
                table: "ClosePuzzlePossibilities",
                column: "SurveyPuzzleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosePuzzlePossibilities_SurveyPuzzles_SurveyPuzzleId",
                table: "ClosePuzzlePossibilities",
                column: "SurveyPuzzleId",
                principalTable: "SurveyPuzzles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenPuzzleAnswers_SurveyPuzzles_SurveyPuzzleId",
                table: "OpenPuzzleAnswers",
                column: "SurveyPuzzleId",
                principalTable: "SurveyPuzzles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosePuzzlePossibilities_SurveyPuzzles_SurveyPuzzleId",
                table: "ClosePuzzlePossibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenPuzzleAnswers_SurveyPuzzles_SurveyPuzzleId",
                table: "OpenPuzzleAnswers");

            migrationBuilder.DropIndex(
                name: "IX_OpenPuzzleAnswers_SurveyPuzzleId",
                table: "OpenPuzzleAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ClosePuzzlePossibilities_SurveyPuzzleId",
                table: "ClosePuzzlePossibilities");

            migrationBuilder.AddColumn<int>(
                name: "SurveySurveyPuzzleId",
                table: "OpenPuzzleAnswers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveySurveyPuzzleId",
                table: "ClosePuzzlePossibilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenPuzzleAnswers_SurveySurveyPuzzleId",
                table: "OpenPuzzleAnswers",
                column: "SurveySurveyPuzzleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosePuzzlePossibilities_SurveySurveyPuzzleId",
                table: "ClosePuzzlePossibilities",
                column: "SurveySurveyPuzzleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosePuzzlePossibilities_SurveyPuzzles_SurveySurveyPuzzleId",
                table: "ClosePuzzlePossibilities",
                column: "SurveySurveyPuzzleId",
                principalTable: "SurveyPuzzles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenPuzzleAnswers_SurveyPuzzles_SurveySurveyPuzzleId",
                table: "OpenPuzzleAnswers",
                column: "SurveySurveyPuzzleId",
                principalTable: "SurveyPuzzles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
