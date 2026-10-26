using Microsoft.EntityFrameworkCore;
using TrailKeeper.Data.Models;

public class TrailKeeperDbContext : DbContext
{
    public TrailKeeperDbContext(DbContextOptions<TrailKeeperDbContext> options)
        : base(options) { }

    public DbSet<Trail> Trails { get; set; } = null!;
    public DbSet<Region> Regions { get; set; } = null!;
    public DbSet<Difficulty> Difficulties { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(TrailKeeperDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
