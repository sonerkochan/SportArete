using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class AddedLogoToBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoImageData",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "1e59eeae-29a6-433c-bed0-d2048be365b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "edb52f25-4656-4be0-b7ce-3ac7ac4b50f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91813a75-c8f4-4f4d-a2e9-b6951b87af70", "AQAAAAEAACcQAAAAEHxADTxtHQ6vmq6MV82nY08dZBE0cAvKZ0PvqMHkdOfCsKBEGV5gG/zKAYk4/p/SuA==", "0f52eff1-72dc-4306-9cd3-d5080b068e07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a9de9f3-d644-42cf-bc48-bb89c2129333", "AQAAAAEAACcQAAAAEDvkwvXsCV+awIS2/LSOUTlzfoRnNMTIt1cdbX4PXYclXOlZ04e74js9eLs8D7Ip7Q==", "094a4705-d4c0-4557-bf56-dd08642c1a7a" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoImageData",
                value: "https://1000logos.net/wp-content/uploads/2021/11/Nike-Logo.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoImageData",
                value: "https://upload.wikimedia.org/wikipedia/commons/2/20/Adidas_Logo.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoImageData",
                value: "https://upload.wikimedia.org/wikipedia/commons/8/88/Puma-Logo.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoImageData",
                value: "https://1000logos.net/wp-content/uploads/2021/04/Under-Armour-logo.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "LogoImageData",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/Asics_Logo.svg/2560px-Asics_Logo.svg.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoImageData",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07358494-247c-421c-8f7f-82c12be55276",
                column: "ConcurrencyStamp",
                value: "8a321635-fb4d-4f91-87d5-ad8ca78bea2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9de7285-b674-454c-9889-5210abb8d347",
                column: "ConcurrencyStamp",
                value: "9c9a2466-d4f5-4294-8e53-53b87f84d15e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dde28e05-938e-45d4-b556-663f218980af", "AQAAAAEAACcQAAAAENL9bienBqv00E98CkUK5Xxn0fxA65dGF2a3upYT/45SQ1MePeGL9dpO2lMQCBooQA==", "a4263395-8350-4783-8725-75f7fe3c947e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "973cae5e-c21b-487e-968c-983d20c5c3da", "AQAAAAEAACcQAAAAECCKnLY1tXpMB8sRxTziu22H3UAacOaA4WihzBxfy3ruEK9BxGj1vAtxZkrQ+7ROfg==", "a5758966-c52b-4314-bf4f-abbddfcd4c7f" });
        }
    }
}
