using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class RatingHasUserIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "7d057d0a-30ab-4598-864c-954505cdf523");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "1ac59e6d-f723-4b05-b23f-c24b758ca934");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5953ce20-b2a7-4da8-b4fe-c025e2158b70", "AQAAAAEAACcQAAAAECTJ1Bqpgn5nAFsGGfgvIUs+JI/i49FfvUQswYG+a7of5Oce0fOms04AY2cuY5+0mg==", "a671d38a-93c4-44d2-94dc-7b1d8928a2de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b06f773-67d4-4012-b6d3-8c687a030121", "AQAAAAEAACcQAAAAEInnehejGXfmZSqmO2MwY/4uxPEz70NS1n0atHoxMPr13jRJhP9k8u4VkbgN6zOPWg==", "f7dca795-aa98-4bb5-9474-9ce07d5bd520" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Review");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "9bbcc316-8631-4ae7-b8fd-c659b90dc80e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "347c783a-60f5-4acd-9b4a-f633439f9a67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3b5eee3-f34b-4d4e-977b-17abcca5e1bf", "AQAAAAEAACcQAAAAECW9BYhWSOezxCZTkgMdJYSAvVXVDAo4bTqu6rXYSZRzfP6PGmLv+CdOCArFGORklg==", "5dcf7998-1217-4ab3-b237-faa772bae3a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db21c86c-5283-4e76-8ece-8c7cda7a747b", "AQAAAAEAACcQAAAAEIPyeW0M5Z0LACRphXfJo1TJhlQ1P/7mnDLI3Toi64YQObO559CoLIQuraEqXBB1ng==", "11b591e0-dd7b-4151-adc9-341e9803274c" });
        }
    }
}
