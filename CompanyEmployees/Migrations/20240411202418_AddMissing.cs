using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AddMissing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ac8240a-8498-4869-bc86-60e5dc982d27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "562419f5-eed1-473b-bcc1-9f2dbab182b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d3e9e63-38bd-4f73-8bf9-ca069924f02e", null, "Manager", "MANAGER" },
                    { "f803857a-7988-4338-b50b-28c6a03f3043", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d3e9e63-38bd-4f73-8bf9-ca069924f02e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f803857a-7988-4338-b50b-28c6a03f3043");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ac8240a-8498-4869-bc86-60e5dc982d27", "ec511bd4-4853-426a-a2fc-751886560c9a", "Manager", "MANAGER" },
                    { "562419f5-eed1-473b-bcc1-9f2dbab182b4", "937e9988-9f49-4bab-a545-b422dde85016", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
