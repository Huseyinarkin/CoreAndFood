using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAndFood.Migrations
{
    public partial class mm3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "PAssword", "Role", "UserName" },
                values: new object[] { 1, "a", "1", "a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
