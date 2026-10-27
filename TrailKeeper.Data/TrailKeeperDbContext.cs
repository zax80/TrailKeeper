using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrailKeeper.Data.Models;

namespace TrailKeeper.Data;

public class TrailKeeperDbContext : IdentityDbContext
{
    public TrailKeeperDbContext(DbContextOptions<TrailKeeperDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trail> Trails { get; set; } = null!;

    public DbSet<Region> Regions { get; set; } = null!;

    public DbSet<Difficulty> Difficulties { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TrailKeeperDbContext).Assembly);
    }
}