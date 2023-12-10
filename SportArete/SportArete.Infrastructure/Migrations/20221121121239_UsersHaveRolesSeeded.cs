using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class UsersHaveRolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "f49f83bb-710d-4082-81fe-883671ced9ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "77c27340-61ce-4299-97ac-038a5351862a");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "07358494-247c-421c-8f7f-82c12be55276", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { "d9de7285-b674-454c-9889-5210abb8d347", "dea12856-c198-4129-b3f3-b893d8395082" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9119b2fe-ecf2-4613-b689-84ca5536ad23", "AQAAAAEAACcQAAAAEJs0rCCRUJaVp814dZ/O5JSnDqBUJI2VKEsG7oXCLhFEfTGoV2fwion93uvGlQM/+g==", "045f5eb7-eaff-4d74-bb01-c8644f1f2f62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e760d53-4410-4ae5-9b74-11e4fd243b7f", "AQAAAAEAACcQAAAAEHfiASJd1pxYyJUAPUJ0ivjYL8GjZRBoohQ9WyJGJ4aRdyuuXhhBGCb+1xIjTqQj3A==", "6fda0da0-a54c-462c-9260-c31067f4b1d8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07358494-247c-421c-8f7f-82c12be55276", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d9de7285-b674-454c-9889-5210abb8d347", "dea12856-c198-4129-b3f3-b893d8395082" });

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3448690-b499-42c9-bb04-f055133f74d6", "AQAAAAEAACcQAAAAEHBCfeaRhF28VXoxWE3FbSquhNUey8EX8ZoKwBiNdLpr9yhhQEqJ/uc4oXE/Qnz3gQ==", "607cf438-ed52-4086-9f12-019c641fe1d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6fa2e42-1bd6-4cb3-b4f1-7ee0a4da0fdb", "AQAAAAEAACcQAAAAEGvKXenaA5LlB4FL7va1SLk5N+aHOBQXX2PMtd9hWR2GzGxBeyTKuHWHsSYuuoThxw==", "60c47bc0-881d-4ddc-9d6b-7c2a9966bec0" });
        }
    }
}
