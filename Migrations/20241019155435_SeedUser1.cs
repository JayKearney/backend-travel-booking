using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role", "Token" },
                values: new object[] { 1, "testuser@gmail.com", "testuser", "1234", "User", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
