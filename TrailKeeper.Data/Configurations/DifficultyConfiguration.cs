using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailKeeper.Data.Models;

namespace TrailKeeper.Data.Configurations;

public class DifficultyConfiguration : IEntityTypeConfiguration<Difficulty>
{
    public void Configure(EntityTypeBuilder<Difficulty> entity)
    {
        entity.HasIndex(d => d.Name).IsUnique();

        entity.HasData(
            new Difficulty { Id = 1, Name = "Easy", Level = 1 },
            new Difficulty { Id = 2, Name = "Moderate", Level = 2 },
            new Difficulty { Id = 3, Name = "Hard", Level = 3 },
            new Difficulty { Id = 4, Name = "Expert", Level = 4 }
        );
    }
}