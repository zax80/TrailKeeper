using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailKeeper.Data.Models;

namespace TrailKeeper.Data.Configurations;

public class TrailConfiguration : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> entity)
    {
        entity.Property(t => t.LengthKm).HasPrecision(6, 2);
        entity.Property(t => t.DurationHours).HasPrecision(4, 1);

        // A region or difficulty that still has trails cannot be deleted
        entity.HasOne(t => t.Region)
              .WithMany(r => r.Trails)
              .HasForeignKey(t => t.RegionId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(t => t.Difficulty)
              .WithMany(d => d.Trails)
              .HasForeignKey(t => t.DifficultyId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(t => t.Creator)
              .WithMany()
              .HasForeignKey(t => t.CreatorId)
              .OnDelete(DeleteBehavior.Restrict);


        entity.HasData(
            new Trail
            {
                Id = 1,
                Name = "Seven Rila Lakes",
                Description = "Classic route past the seven glacial lakes of Rila with wide views from the ridge.",
                StartPoint = "Rilski Ezera Hut",
                LengthKm = 12.0m,
                ElevationGainM = 450,
                DurationHours = 5.0m,
                IsLoop = true,
                CreatedOn = new DateTime(2026, 10, 1),
                RegionId = 1,
                DifficultyId = 2
            },
            new Trail
            {
                Id = 2,
                Name = "Vihren from Vihren Hut",
                Description = "Steep marked route from Vihren Hut to the highest peak of Pirin, with a rocky final section.",
                StartPoint = "Vihren Hut",
                LengthKm = 9.0m,
                ElevationGainM = 950,
                DurationHours = 6.0m,
                IsLoop = false,
                CreatedOn = new DateTime(2026, 10, 2),
                RegionId = 2,
                DifficultyId = 3
            },
            new Trail
            {
                Id = 3,
                Name = "Cherni Vrah from Aleko",
                Description = "Short and popular walk from Aleko hut to the highest point of Vitosha above Sofia.",
                StartPoint = "Aleko Hut",
                LengthKm = 6.0m,
                ElevationGainM = 400,
                DurationHours = 3.0m,
                IsLoop = false,
                CreatedOn = new DateTime(2026, 10, 3),
                RegionId = 5,
                DifficultyId = 1
            },
            new Trail
            {
                Id = 4,
                Name = "Raiskoto Praskalo from Apriltsi",
                Description = "Long forest and ridge route to the highest waterfall in the Balkans, passing Pleven Hut on the way.",
                StartPoint = "Apriltsi",
                LengthKm = 16.0m,
                ElevationGainM = 1100,
                DurationHours = 7.0m,
                IsLoop = false,
                CreatedOn = new DateTime(2026, 10, 4),
                RegionId = 3,
                DifficultyId = 3
            },
            new Trail
            {
                Id = 5,
                Name = "Wonderful Bridges Loop",
                Description = "Easy family loop around the natural rock arches above the Erkyupryia gorge in the Rhodopes.",
                StartPoint = "Wonderful Bridges Hut",
                LengthKm = 5.0m,
                ElevationGainM = 200,
                DurationHours = 2.5m,
                IsLoop = true,
                CreatedOn = new DateTime(2026, 10, 5),
                RegionId = 4,
                DifficultyId = 1
            },
            new Trail
            {
                Id = 6,
                Name = "Koncheto Ridge",
                Description = "Exposed knife-edge ridge between Vihren and Kutelo with fixed cables; for experienced hikers only.",
                StartPoint = "Banderitsa Hut",
                LengthKm = 14.0m,
                ElevationGainM = 1100,
                DurationHours = 8.0m,
                IsLoop = false,
                CreatedOn = new DateTime(2026, 10, 6),
                RegionId = 2,
                DifficultyId = 4
            }
        );
    }
}
