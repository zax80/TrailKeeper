using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailKeeper.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ef12af2b-c21d-429b-8f25-01cd5d993437", 0, "b344526c-778a-47c8-9a41-646e84ef1e54", "demo@trailkeeper.com", true, false, null, "DEMO@TRAILKEEPER.COM", "DEMO@TRAILKEEPER.COM", "AQAAAAIAAYagAAAAEPjwYPbtsw0v5jjJfhj3e3lP31LZeo8va+zX4uQD4WU/1MnZzjCHuNZcb47ytQM+kw==", null, false, "8063f825-ff20-4aab-8306-d969872cf3fa", false, "demo@trailkeeper.com" });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: "ef12af2b-c21d-429b-8f25-01cd5d993437");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: "ef12af2b-c21d-429b-8f25-01cd5d993437");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatorId",
                value: "ef12af2b-c21d-429b-8f25-01cd5d993437");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatorId",
                value: "ef12af2b-c21d-429b-8f25-01cd5d993437");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatorId",
                value: "ef12af2b-c21d-429b-8f25-01cd5d993437");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatorId",
                value: "ef12af2b-c21d-429b-8f25-01cd5d993437");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef12af2b-c21d-429b-8f25-01cd5d993437");

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatorId",
                value: null);
        }
    }
}
