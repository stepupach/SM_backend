using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeadRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "9d115126-e26a-48aa-830f-761a925a25a1", null, "User", "USER" },
                    { "afd9f5b9-8c73-4247-88a5-2c0060378756", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d115126-e26a-48aa-830f-761a925a25a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afd9f5b9-8c73-4247-88a5-2c0060378756");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ca9d287-2580-4019-a6d5-fca30ee7543e", null, "User", "USER" },
                    { "c0a225e4-e533-45d6-9c40-ab4f7ee9cb80", null, "Admin", "ADMIN" }
                });
        }
    }
}
