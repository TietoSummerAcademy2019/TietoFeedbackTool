using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class ModifiedAccountAndSurveys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Accounts_AccountId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_AccountId",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountLogin",
                table: "Surveys",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AccountLogin",
                table: "Surveys",
                column: "AccountLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Accounts_AccountLogin",
                table: "Surveys",
                column: "AccountLogin",
                principalTable: "Accounts",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Accounts_AccountLogin",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_AccountLogin",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountLogin",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Accounts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AccountId",
                table: "Surveys",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Accounts_AccountId",
                table: "Surveys",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
