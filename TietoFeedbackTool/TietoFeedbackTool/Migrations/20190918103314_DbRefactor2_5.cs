using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class DbRefactor2_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RatingType",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingType",
                table: "Question");
        }
    }
}
