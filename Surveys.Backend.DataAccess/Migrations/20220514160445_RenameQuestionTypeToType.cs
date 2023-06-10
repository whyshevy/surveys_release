using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surveys.Backend.DataAccess.Migrations
{
    public partial class RenameQuestionTypeToType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionType",
                table: "Questions",
                newName: "Type");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Questions",
                newName: "QuestionType");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"),
                column: "ConcurrencyStamp",
                value: "2f9da959-6137-4c2d-b277-510bc42c796a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"),
                column: "ConcurrencyStamp",
                value: "e571f407-b874-473d-8aca-45a62a6f5922");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b69acd4e-f324-4a89-bb30-8359a2ba578c", "AQAAAAEAACcQAAAAEIX+NweFmqOzvKExO/dk8qiAtOXy8yvOQolaQgeCTvWyCLFUXlJGEFxdYIMMW9n2kg==" });
        }
    }
}
