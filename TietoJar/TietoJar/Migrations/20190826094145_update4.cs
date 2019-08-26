using Microsoft.EntityFrameworkCore.Migrations;

namespace TietoJar.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Login", "Name", "Password" },
                values: new object[] { "kangorooAdmin1", "Kangaroo", "zaq1xsw2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Login",
                keyValue: "kangorooAdmin1");
        }
    }
}
