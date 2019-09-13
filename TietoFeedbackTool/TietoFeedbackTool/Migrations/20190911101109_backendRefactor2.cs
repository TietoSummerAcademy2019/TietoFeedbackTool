using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class backendRefactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionKey",
                table: "Accounts",
                newName: "QuestionsKey");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_QuestionKey",
                table: "Accounts",
                newName: "IX_Accounts_QuestionsKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionsKey",
                table: "Accounts",
                newName: "QuestionKey");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_QuestionsKey",
                table: "Accounts",
                newName: "IX_Accounts_QuestionKey");
        }
    }
}
