using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surveys.Backend.DataAccess.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"), "b69acd4e-f324-4a89-bb30-8359a2ba578c", "admin@admin.com", "Admin name", null, null, "AQAAAAEAACcQAAAAEIX+NweFmqOzvKExO/dk8qiAtOXy8yvOQolaQgeCTvWyCLFUXlJGEFxdYIMMW9n2kg==", null, null });

            migrationBuilder.InsertData(
                table: "Questionnaires",
                columns: new[] { "Id", "CreatedById", "Description", "Title", "UpdatedById" },
                values: new object[] { new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"), new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"), "Questionnaire description", "Questionnaire title", new Guid("670c28b5-0731-4334-866b-0fb107bf7a31") });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "IsRequired", "Order", "QuestionType", "QuestionnaireId", "Title" },
                values: new object[] { new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab"), "Text Question description", true, 1, 0, new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"), "Question title 1" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "IsRequired", "Order", "QuestionType", "QuestionnaireId", "Title" },
                values: new object[] { new Guid("cb22e35c-5360-4f91-b66b-f139fdfaf3f7"), "Text Question description", true, 2, 1, new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"), "Question title 2" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "Order", "QuestionId" },
                values: new object[] { new Guid("3d55bb8d-d042-4cc4-9423-994e21141308"), "Option content 1", 1, new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab") });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "Order", "QuestionId" },
                values: new object[] { new Guid("ab39b4ae-8f88-4604-b4ba-911d59b61cb9"), "Option content 3", 3, new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab") });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "Order", "QuestionId" },
                values: new object[] { new Guid("bd56f9e1-6b78-4a30-858b-f18ff91b967f"), "Option content 2", 2, new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("3d55bb8d-d042-4cc4-9423-994e21141308"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("ab39b4ae-8f88-4604-b4ba-911d59b61cb9"));

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: new Guid("bd56f9e1-6b78-4a30-858b-f18ff91b967f"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("cb22e35c-5360-4f91-b66b-f139fdfaf3f7"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("03ec14a4-586c-4f84-9a46-ecb36af457ab"));

            migrationBuilder.DeleteData(
                table: "Questionnaires",
                keyColumn: "Id",
                keyValue: new Guid("48bd6426-f2bc-4c04-a15d-25eb88d6fb67"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("670c28b5-0731-4334-866b-0fb107bf7a31"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3e4ba5e7-073e-4805-bb2d-e14986a97a0a"),
                column: "ConcurrencyStamp",
                value: "0a027db0-207b-4aa4-8e8a-718cb8283c54");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8"),
                column: "ConcurrencyStamp",
                value: "38ec1856-a52d-4d19-afa6-46f275126976");
        }
    }
}
