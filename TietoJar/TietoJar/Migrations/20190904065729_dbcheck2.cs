using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class dbcheck2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmitDate",
                table: "OpenPuzzleAnswers",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmitDate",
                table: "OpenPuzzleAnswers",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");
        }
    }
}
