using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class DbRefactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QuestionsKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true),
                    AccountLogin = table.Column<string>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HasRating = table.Column<bool>(nullable: false),
                    IsBottom = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Accounts_AccountLogin",
                        column: x => x.AccountLogin,
                        principalTable: "Accounts",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuzzleAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(maxLength: 2000, nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuzzleAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuzzleAnswers_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_QuestionsKey",
                table: "Accounts",
                column: "QuestionsKey",
                unique: true,
                filter: "[QuestionsKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PuzzleAnswers_QuestionId",
                table: "PuzzleAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AccountLogin",
                table: "Question",
                column: "AccountLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuzzleAnswers");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
