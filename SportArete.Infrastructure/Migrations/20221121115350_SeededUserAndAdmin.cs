using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class SeededUserAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "8b009164-5a46-493e-8c8b-54dbb1e48cae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "4826bb47-5f2a-469f-88b2-1e1ed08c4b8a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "a3448690-b499-42c9-bb04-f055133f74d6", "soner2001@mail.com", false, false, null, "SONER2001@MAIL.COM", "SONER", "AQAAAAEAACcQAAAAEHBCfeaRhF28VXoxWE3FbSquhNUey8EX8ZoKwBiNdLpr9yhhQEqJ/uc4oXE/Qnz3gQ==", null, false, "607cf438-ed52-4086-9f12-019c641fe1d5", false, "Soner" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "b6fa2e42-1bd6-4cb3-b4f1-7ee0a4da0fdb", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEGvKXenaA5LlB4FL7va1SLk5N+aHOBQXX2PMtd9hWR2GzGxBeyTKuHWHsSYuuoThxw==", null, false, "60c47bc0-881d-4ddc-9d6b-7c2a9966bec0", false, "Admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "c26d6f36-d670-4df8-a01d-512105e6c2ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "ca645afa-5c98-4172-b1cb-aed4c3c81f11");
        }
    }
}
