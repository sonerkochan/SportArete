using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class AddedReviewAndUpdatedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raiting = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderProduct");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "1d0407bd-7144-4084-8a16-3fa9836e5b62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "97fe42da-7001-43bf-a359-8304b8df0b07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e145867-9b50-481a-91c2-c3fc613c2c70", "AQAAAAEAACcQAAAAEDdg7RV/Bw+x6iK5BjrtGVfLd7kSxDFJgiKn6hzC1xMGeHyXI2eQTjGSPS78K9KKqg==", "03b07919-e299-4a99-be0d-df065db24c55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ab1e072-c1d2-4222-8e9d-df7a817225b6", "AQAAAAEAACcQAAAAEDJ+y1b7AoxfmvGaVWcPPv/F655gquTnCFxGzCXUgvkYo1SwaONHGQnLbsuho9+z0w==", "73308ee7-28f5-48f1-bf72-6629622457c5" });
        }
    }
}
