using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoFeedbackTool.Migrations
{
    public partial class DbRefactor2_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Question",
                newName: "DomainName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DomainName",
                table: "Question",
                newName: "Name");
        }
    }
}
