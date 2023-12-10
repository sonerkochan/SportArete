using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class UsersHaveActiveAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "13e2f6fe-aab5-47ac-a115-e986cf3d0c9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "e0330c6d-739f-4774-a077-3be1809933e3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e4408c8-795f-4acf-b4ec-cc1207221612", true, "AQAAAAEAACcQAAAAEIp8lKji/8fSqrJnzCTDNj/Q/2vymGpdvaTxqIHtzPMtsUuRsS4/c+k4V6zSjmP/3Q==", "df7163b1-7b73-43bd-ad5f-4652e3461106" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "710a06bd-9532-4f89-ab8c-c7359283608e", true, "AQAAAAEAACcQAAAAECQjO86YrtfXVWgsq6zYV/KDRoR/06g81URIqM3FhPD6uigf9vzKKJpXFBu88tlv6g==", "479a8112-70ba-420a-a943-a0acede9e15e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "484ce6f9-9b0a-4800-8e0e-4a8c17d32063");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "97fada93-d29b-46fc-9ca2-05f33800c78b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20bb97b0-d5a8-4e4e-91c1-d290df490ab7", "AQAAAAEAACcQAAAAEKCA3oX2/g8hgve8P/wqeF3OehFBy6LhDeEQJL5Vn/fyRRFkvATX9yzjcu6JLgYy1A==", "e097a797-abc8-482d-910c-601664c61b4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34aa0039-7618-43ad-9708-86bcdfeda8a6", "AQAAAAEAACcQAAAAEJvppcLW+uG1jozLDFIq1JMX7Zgf0UkeyJNpzwTvG0QBtonvQSYGw+Qoqh5kj+smIw==", "0dea8044-aacb-4eaf-82df-3a55c2883338" });
        }
    }
}
