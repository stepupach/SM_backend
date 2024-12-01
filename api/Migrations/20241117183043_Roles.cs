using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b01982d-e98b-41d7-a620-21bc9fe18077");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2a4f2ce-e4c3-43fc-b7f3-afc956c75744");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ca9d287-2580-4019-a6d5-fca30ee7543e", null, "User", "USER" },
                    { "c0a225e4-e533-45d6-9c40-ab4f7ee9cb80", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ca9d287-2580-4019-a6d5-fca30ee7543e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0a225e4-e533-45d6-9c40-ab4f7ee9cb80");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b01982d-e98b-41d7-a620-21bc9fe18077", null, "Admin", "ADMIN" },
                    { "a2a4f2ce-e4c3-43fc-b7f3-afc956c75744", null, "User", "USER" }
                });
        }
    }
}
