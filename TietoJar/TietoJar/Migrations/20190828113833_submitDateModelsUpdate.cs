using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class submitDateModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "ClosePuzzlePossibilities");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosePuzzleAnswers");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "ClosePuzzlePossibilities",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
