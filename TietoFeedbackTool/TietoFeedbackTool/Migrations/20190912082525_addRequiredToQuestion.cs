using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class addRequiredToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Accounts_AccountLogin",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "AccountLogin",
                table: "Question",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Accounts_AccountLogin",
                table: "Question",
                column: "AccountLogin",
                principalTable: "Accounts",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Accounts_AccountLogin",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "AccountLogin",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Accounts_AccountLogin",
                table: "Question",
                column: "AccountLogin",
                principalTable: "Accounts",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
