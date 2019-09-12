using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class keyGenerator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_QuestionsKey",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionsKey",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_QuestionsKey",
                table: "Accounts",
                column: "QuestionsKey",
                unique: true,
                filter: "[QuestionsKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_QuestionsKey",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionsKey",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_QuestionsKey",
                table: "Accounts",
                column: "QuestionsKey",
                unique: true);
        }
    }
}
