using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class modelsupdateTimeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "OpenPuzzleAnswers",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "ClosePuzzlePossibilities",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "OpenPuzzleAnswers");

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "ClosePuzzlePossibilities");
        }
    }
}
