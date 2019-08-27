using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpenPuzzleAnswers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SurveyPuzzles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyKey",
                keyValue: "123456789");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Login",
                keyValue: "kangorooAdmin1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Login", "Name", "Password" },
                values: new object[] { "kangorooAdmin1", "Kangaroo", "zaq1xsw2" });

            migrationBuilder.InsertData(
                table: "PuzzleTypes",
                columns: new[] { "Id", "HaveOpenAnswer", "Name" },
                values: new object[] { 1, true, "Stars" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyKey", "AccountLogin", "Name" },
                values: new object[] { "123456789", "kangorooAdmin1", "defaultSurvey" });

            migrationBuilder.InsertData(
                table: "SurveyPuzzles",
                columns: new[] { "Id", "Position", "PuzzleQuestion", "PuzzleTypeId", "SurveyKey" },
                values: new object[] { 1, 1, "Will it work?", 1, "123456789" });

            migrationBuilder.InsertData(
                table: "OpenPuzzleAnswers",
                columns: new[] { "Id", "Answer", "SurveyPuzzleId" },
                values: new object[] { 1, "Yes, of course", 1 });
        }
    }
}
