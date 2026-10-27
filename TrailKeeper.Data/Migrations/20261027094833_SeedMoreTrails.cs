using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrailKeeper.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreTrails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "Description", "DifficultyId", "DurationHours", "ElevationGainM", "IsLoop", "LengthKm", "Name", "RegionId", "StartPoint" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Long forest and ridge route to the highest waterfall in the Balkans, passing Pleven Hut on the way.", 3, 7.0m, 1100, false, 16.0m, "Raiskoto Praskalo from Apriltsi", 3, "Apriltsi" },
                    { 5, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Easy family loop around the natural rock arches above the Erkyupryia gorge in the Rhodopes.", 1, 2.5m, 200, true, 5.0m, "Wonderful Bridges Loop", 4, "Wonderful Bridges Hut" },
                    { 6, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exposed knife-edge ridge between Vihren and Kutelo with fixed cables; for experienced hikers only.", 4, 8.0m, 1100, false, 14.0m, "Koncheto Ridge", 2, "Banderitsa Hut" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
