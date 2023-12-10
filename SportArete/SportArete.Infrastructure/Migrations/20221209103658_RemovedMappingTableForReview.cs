using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class RemovedMappingTableForReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => new { x.ReviewId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductReview_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReview_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "b2491c74-ecf2-47e4-a63b-da42306f3b88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "1af01a89-df1d-4f92-9702-59e7ebc8eead");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb48814d-388e-4dfc-a8a3-e1eb3cb9ee05", "AQAAAAEAACcQAAAAEGeAjlWUA57gUlkTytJ7RbU1lDcuayfRW/heOC1Hx1tTSdDalTiDqwdrEYSJ8mGTwA==", "03290c8f-6749-47fd-8e0c-b711373ee82a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a48e6bb-a3dd-4017-aaeb-d91dc04178ec", "AQAAAAEAACcQAAAAEC/zRWLMk1JNJncymm/HjSd8t/eiq/hXMEPPtlho2ksfxzJqLzx/MznfFwn7GJdUIg==", "f233cb2f-ced5-4d37-8ffe-d93b226bcadc" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                table: "ProductReview",
                column: "ProductId");
        }
    }
}
