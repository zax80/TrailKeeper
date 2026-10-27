namespace TrailKeeper.Web.ViewModels.Trails;

public class TrailListItemViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string RegionName { get; set; } = null!;

    public string DifficultyName { get; set; } = null!;

    public decimal LengthKm { get; set; }

    public decimal DurationHours { get; set; }

    public string? CreatorId { get; set; }
}
