using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Migrations
{
    public partial class updateProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2439952b-5cb2-4e6f-8f03-dcbcb675409e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cacaa187-00c9-4a82-87e5-756005607307");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0fc21fc-b0b7-4344-bdf3-a9b8e8b83a2b", "11391355-215e-4c2c-a86a-7d44639dd8f0", "Administrator ", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eca597ff-1e78-4e8f-a314-74303fea508f", "e32e3bb1-279e-4cd6-85b8-3f723a98385c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0fc21fc-b0b7-4344-bdf3-a9b8e8b83a2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca597ff-1e78-4e8f-a314-74303fea508f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2439952b-5cb2-4e6f-8f03-dcbcb675409e", "034d8d14-18df-4701-bbad-7036a7aec81b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cacaa187-00c9-4a82-87e5-756005607307", "c6257871-0508-48fd-be85-6fb7aba9c945", "Administrator ", "ADMINISTRATOR" });
        }
    }
}
