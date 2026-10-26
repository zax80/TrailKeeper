using TrailKeeper.Web.ViewModels.Trails;

namespace TrailKeeper.Services.Core.Contracts;

public interface ITrailService
{
    Task<IEnumerable<TrailListItemViewModel>> GetAllAsync();

    Task<IEnumerable<TrailListItemViewModel>> GetLatestAsync(int count);

    Task<TrailDetailsViewModel?> GetDetailsAsync(int id);

    Task<TrailFormViewModel?> GetForEditAsync(int id);

    Task<TrailDeleteViewModel?> GetForDeleteAsync(int id);

    Task CreateAsync(TrailFormViewModel model);

    Task<bool> UpdateAsync(int id, TrailFormViewModel model);

    Task<bool> DeleteAsync(int id);
}