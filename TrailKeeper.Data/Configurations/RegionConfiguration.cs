using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailKeeper.Data.Models;

namespace TrailKeeper.Data.Configurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> entity)
    {
        entity.HasIndex(r => r.Name).IsUnique();

        entity.HasData(
            new Region { Id = 1, Name = "Rila", Description = "Highest range in the Balkans, glacial lakes and alpine ridges." },
            new Region { Id = 2, Name = "Pirin", Description = "Rocky marble and granite peaks, national park." },
            new Region { Id = 3, Name = "Central Balkan", Description = "Long main ridge of Stara Planina, waterfalls and beech forests." },
            new Region { Id = 4, Name = "Rhodopes", Description = "Rolling forested mountains, gorges and caves." },
            new Region { Id = 5, Name = "Vitosha", Description = "City mountain next to Sofia, easy access." }
        );
    }
}