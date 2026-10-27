using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrailKeeper.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditionalTrails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "Description", "DifficultyId", "DurationHours", "ElevationGainM", "IsLoop", "LengthKm", "Name", "RegionId", "StartPoint" },
                values: new object[,]
                {
                    { 2, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Steep marked route from Vihren Hut to the highest peak of Pirin, with a rocky final section.", 3, 6.0m, 950, false, 9.0m, "Vihren from Vihren Hut", 2, "Vihren Hut" },
                    { 3, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Short and popular walk from Aleko hut to the highest point of Vitosha above Sofia.", 1, 3.0m, 400, false, 6.0m, "Cherni Vrah from Aleko", 5, "Aleko Hut" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
