using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surveys.Backend.DataAccess.Migrations
{
    public partial class AddedRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[] { new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"), "0a027db0-207b-4aa4-8e8a-718cb8283c54", "Admin", "ADMIN", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[] { new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"), "38ec1856-a52d-4d19-afa6-46f275126976", "User", "USER", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"));
        }
    }
}
