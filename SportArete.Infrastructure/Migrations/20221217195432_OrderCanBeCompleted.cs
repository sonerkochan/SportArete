using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportArete.Infrastructure.Migrations
{
    public partial class OrderCanBeCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsComplete",
                table: "Orders",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsComplete",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e4408c8-795f-4acf-b4ec-cc1207221612", "AQAAAAEAACcQAAAAEIp8lKji/8fSqrJnzCTDNj/Q/2vymGpdvaTxqIHtzPMtsUuRsS4/c+k4V6zSjmP/3Q==", "df7163b1-7b73-43bd-ad5f-4652e3461106" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "710a06bd-9532-4f89-ab8c-c7359283608e", "AQAAAAEAACcQAAAAECQjO86YrtfXVWgsq6zYV/KDRoR/06g81URIqM3FhPD6uigf9vzKKJpXFBu88tlv6g==", "479a8112-70ba-420a-a943-a0acede9e15e" });
        }
    }
}
