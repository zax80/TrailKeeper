using Microsoft.EntityFrameworkCore;
using TrailKeeper.Data;
using TrailKeeper.Data.Models;
using TrailKeeper.Services.Core.Contracts;
using TrailKeeper.Web.ViewModels.Trails;

namespace TrailKeeper.Services.Core;

public class TrailService : ITrailService
{
    private readonly TrailKeeperDbContext dbContext;

    public TrailService(TrailKeeperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<TrailListItemViewModel>> GetAllAsync()
    {
        return await dbContext.Trails
            .AsNoTracking()
            .OrderBy(t => t.Name)
            .Select(t => new TrailListItemViewModel
            {
                Id = t.Id,
                Name = t.Name,
                RegionName = t.Region.Name,
                DifficultyName = t.Difficulty.Name,
                LengthKm = t.LengthKm,
                DurationHours = t.DurationHours,
                CreatorId = t.CreatorId
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<TrailListItemViewModel>> GetLatestAsync(int count)
    {
        return await dbContext.Trails
            .AsNoTracking()
            .OrderByDescending(t => t.CreatedOn)
            .Take(count)
            .Select(t => new TrailListItemViewModel
            {
                Id = t.Id,
                Name = t.Name,
                RegionName = t.Region.Name,
                DifficultyName = t.Difficulty.Name,
                LengthKm = t.LengthKm,
                DurationHours = t.DurationHours,
                CreatorId = t.CreatorId
            })
            .ToListAsync();
    }

    public async Task<TrailDetailsViewModel?> GetDetailsAsync(int id)
    {
        return await dbContext.Trails
            .AsNoTracking()
            .Where(t => t.Id == id)
            .Select(t => new TrailDetailsViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                StartPoint = t.StartPoint,
                LengthKm = t.LengthKm,
                ElevationGainM = t.ElevationGainM,
                DurationHours = t.DurationHours,
                IsLoop = t.IsLoop,
                RegionName = t.Region.Name,
                DifficultyName = t.Difficulty.Name,
                CreatedOn = t.CreatedOn,
                CreatorId = t.CreatorId,
                CreatorName = t.Creator != null ? t.Creator.UserName! : "Unknown"
            })
            .FirstOrDefaultAsync();
    }

    public async Task<TrailFormViewModel?> GetForEditAsync(int id)
    {
        return await dbContext.Trails
            .AsNoTracking()
            .Where(t => t.Id == id)
            .Select(t => new TrailFormViewModel
            {
                Name = t.Name,
                Description = t.Description,
                StartPoint = t.StartPoint,
                LengthKm = t.LengthKm,
                ElevationGainM = t.ElevationGainM,
                DurationHours = t.DurationHours,
                IsLoop = t.IsLoop,
                RegionId = t.RegionId,
                DifficultyId = t.DifficultyId
            })
            .FirstOrDefaultAsync();
    }

    public async Task<TrailDeleteViewModel?> GetForDeleteAsync(int id)
    {
        return await dbContext.Trails
            .AsNoTracking()
            .Where(t => t.Id == id)
            .Select(t => new TrailDeleteViewModel
            {
                Id = t.Id,
                Name = t.Name,
                RegionName = t.Region.Name
            })
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(TrailFormViewModel model, string userId)
    {
        var trail = new Trail
        {
            Name = model.Name,
            Description = model.Description,
            StartPoint = model.StartPoint,
            LengthKm = model.LengthKm,
            ElevationGainM = model.ElevationGainM,
            DurationHours = model.DurationHours,
            IsLoop = model.IsLoop,
            RegionId = model.RegionId,
            DifficultyId = model.DifficultyId,
            CreatedOn = DateTime.UtcNow,
            CreatorId = userId
        };

        await dbContext.Trails.AddAsync(trail);
        await dbContext.SaveChangesAsync();
    }

    public Task<bool> IsCreatorAsync(int id, string userId)
    => dbContext.Trails.AnyAsync(t => t.Id == id && t.CreatorId == userId);

    public async Task<bool> UpdateAsync(int id, TrailFormViewModel model)
    {
        var trail = await dbContext.Trails.FindAsync(id);
        if (trail == null)
        {
            return false;
        }

        trail.Name = model.Name;
        trail.Description = model.Description;
        trail.StartPoint = model.StartPoint;
        trail.LengthKm = model.LengthKm;
        trail.ElevationGainM = model.ElevationGainM;
        trail.DurationHours = model.DurationHours;
        trail.IsLoop = model.IsLoop;
        trail.RegionId = model.RegionId;
        trail.DifficultyId = model.DifficultyId;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var trail = await dbContext.Trails.FindAsync(id);
        if (trail == null)
        {
            return false;
        }

        dbContext.Trails.Remove(trail);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
