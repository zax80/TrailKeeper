using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailKeeper.Data.Models;

namespace TrailKeeper.Data.Configurations;

public class TrailConfiguration : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> entity)
    {
        // decimal(6,2) и decimal(4,1) вместо decimal(18,2)
        entity.Property(t => t.LengthKm).HasPrecision(6, 2);
        entity.Property(t => t.DurationHours).HasPrecision(4, 1);

        // Регион с пътеки не може да се изтрие
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
            }
            // добави още 1–2 пътеки по същия начин, с Id = 2, 3
        );
    }
}
