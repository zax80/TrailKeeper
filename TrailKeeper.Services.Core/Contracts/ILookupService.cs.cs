using TrailKeeper.Web.ViewModels.Shared;

namespace TrailKeeper.Services.Core.Contracts;

public interface ILookupService
{
    Task<IEnumerable<LookupItemViewModel>> GetRegionsAsync();

    Task<IEnumerable<LookupItemViewModel>> GetDifficultiesAsync();

    Task<bool> RegionExistsAsync(int id);

    Task<bool> DifficultyExistsAsync(int id);
}
