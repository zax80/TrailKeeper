using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static TrailKeeper.GCommon.ApplicationConstants;

namespace TrailKeeper.Data.Configurations;

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    private const string DemoEmail = "demo@trailkeeper.com";

    public void Configure(EntityTypeBuilder<IdentityUser> entity)
    {
        // Password: Demo123. The hash is precomputed so the seed stays the same between migrations.
        entity.HasData(new IdentityUser
        {
            Id = DemoUserId,
            UserName = DemoEmail,
            NormalizedUserName = DemoEmail.ToUpperInvariant(),
            Email = DemoEmail,
            NormalizedEmail = DemoEmail.ToUpperInvariant(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEPjwYPbtsw0v5jjJfhj3e3lP31LZeo8va+zX4uQD4WU/1MnZzjCHuNZcb47ytQM+kw==",
            SecurityStamp = "8063f825-ff20-4aab-8306-d969872cf3fa",
            ConcurrencyStamp = "b344526c-778a-47c8-9a41-646e84ef1e54"
        });
    }
}