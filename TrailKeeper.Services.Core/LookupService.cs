using Microsoft.EntityFrameworkCore;
using TrailKeeper.Data;
using TrailKeeper.Services.Core.Contracts;
using TrailKeeper.Web.ViewModels.Shared;

namespace TrailKeeper.Services.Core;

public class LookupService : ILookupService
{
    private readonly TrailKeeperDbContext dbContext;

    public LookupService(TrailKeeperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<LookupItemViewModel>> GetRegionsAsync()
    {
        return await dbContext.Regions
            .AsNoTracking()
            .OrderBy(r => r.Name)
            .Select(r => new LookupItemViewModel { Id = r.Id, Name = r.Name })
            .ToListAsync();
    }

    public async Task<IEnumerable<LookupItemViewModel>> GetDifficultiesAsync()
    {
        return await dbContext.Difficulties
            .AsNoTracking()
            .OrderBy(d => d.Level)
            .Select(d => new LookupItemViewModel { Id = d.Id, Name = d.Name })
            .ToListAsync();
    }

    public Task<bool> RegionExistsAsync(int id)
        => dbContext.Regions.AnyAsync(r => r.Id == id);

    public Task<bool> DifficultyExistsAsync(int id)
        => dbContext.Difficulties.AnyAsync(d => d.Id == id);
}
