using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surveys.Backend.DataAccess.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"),
                column: "ConcurrencyStamp",
                value: "f6d2372f-bdfc-4708-ab71-5c0188760493");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"),
                column: "ConcurrencyStamp",
                value: "3f9f3508-c41c-4f06-8a57-7a6586091f3d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19f8648e-df27-4f75-9ae7-85de8617c60c", "AQAAAAEAACcQAAAAEJbvvQkpYoTutZqb1d8+XXBYOiLYnAg2bSPEo6Jvmx2t5aV7XVR8pp3zy+EvbTH0uw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"),
                column: "ConcurrencyStamp",
                value: "7f6a67ba-4476-4e3a-b083-894568a74108");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"),
                column: "ConcurrencyStamp",
                value: "60e9d83e-a12e-486a-86fa-ca5a00a30ba6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e791a2a4-a047-4bb8-ade4-bb057d64402b", "AQAAAAEAACcQAAAAEG7GjGscVhfXF8pAiPIYvEITHNxVf79m+Qz0Bjfwj+PJETeuYWGyHsfs/1MLrFoqBw==" });
        }
    }
}
