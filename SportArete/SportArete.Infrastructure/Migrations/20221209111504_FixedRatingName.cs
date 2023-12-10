using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class FixedRatingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Raiting",
                table: "Reviews",
                newName: "Rating");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Reviews",
                newName: "Raiting");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "6ce9da9e-9ed2-40d5-93bc-e5f9ee0920d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "11dcbe34-5a11-4a83-99e2-01675fb92816");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75415996-6c97-4509-9032-cc4157afcb8a", "AQAAAAEAACcQAAAAEOLM3OaY3KsxUrKlrnZcfgw9HEBQsqotLq3fBXJ91fYI+/gvDa98JDeuL7wAVVEVUg==", "ae77dc0a-91b2-4892-9dc2-f3e042bd750b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28733893-3a00-4f47-b8b6-5b1d27e2d5ff", "AQAAAAEAACcQAAAAEHEnRCKdcqdk+79K602z40aB/Randn8U+pLEpJokw/KcfpLLI7gSxJVtVhGrou36xQ==", "ebb968ea-9283-4ad9-8c28-1bf1f96a1b52" });
        }
    }
}
