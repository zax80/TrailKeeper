using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrailKeeper.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    StartPoint = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LengthKm = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    ElevationGainM = table.Column<int>(type: "int", nullable: false),
                    DurationHours = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: false),
                    IsLoop = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trails_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trails_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Easy" },
                    { 2, 2, "Moderate" },
                    { 3, 3, "Hard" },
                    { 4, 4, "Expert" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Highest range in the Balkans, glacial lakes and alpine ridges.", "Rila" },
                    { 2, "Rocky marble and granite peaks, national park.", "Pirin" },
                    { 3, "Long main ridge of Stara Planina, waterfalls and beech forests.", "Central Balkan" },
                    { 4, "Rolling forested mountains, gorges and caves.", "Rhodopes" },
                    { 5, "City mountain next to Sofia, easy access.", "Vitosha" }
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreatedOn", "Description", "DifficultyId", "DurationHours", "ElevationGainM", "IsLoop", "LengthKm", "Name", "RegionId", "StartPoint" },
                values: new object[] { 1, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic route past the seven glacial lakes of Rila with wide views from the ridge.", 2, 5.0m, 450, true, 12.0m, "Seven Rila Lakes", 1, "Rilski Ezera Hut" });

            migrationBuilder.CreateIndex(
                name: "IX_Difficulties_Name",
                table: "Difficulties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Name",
                table: "Regions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trails_DifficultyId",
                table: "Trails",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_RegionId",
                table: "Trails",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
