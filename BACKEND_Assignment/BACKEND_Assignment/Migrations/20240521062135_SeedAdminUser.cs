using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACKEND_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[] { 1, "$2a$11$uVcMcT20ZTH9995eUfVFf.gutZCAgazVWzKQGffgrFHp7/ymj5.ZK", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
