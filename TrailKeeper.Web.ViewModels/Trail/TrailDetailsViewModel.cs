namespace TrailKeeper.Web.ViewModels.Trails;

public class TrailDetailsViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string StartPoint { get; set; } = null!;

    public decimal LengthKm { get; set; }

    public int ElevationGainM { get; set; }

    public decimal DurationHours { get; set; }

    public bool IsLoop { get; set; }

    public string RegionName { get; set; } = null!;

    public string DifficultyName { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}