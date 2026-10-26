using System.ComponentModel.DataAnnotations;
using TrailKeeper.Web.ViewModels.Shared;
using static TrailKeeper.GCommon.ValidationConstants;

namespace TrailKeeper.Web.ViewModels.Trails;

public class TrailFormViewModel
{
    [Required(ErrorMessage = "Trail name is required.")]
    [StringLength(TrailNameMaxLength, MinimumLength = TrailNameMinLength,
        ErrorMessage = "Trail name must be between {2} and {1} characters.")]
    [Display(Name = "Trail name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(TrailDescriptionMaxLength, MinimumLength = TrailDescriptionMinLength,
        ErrorMessage = "Description must be between {2} and {1} characters.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Start point is required.")]
    [StringLength(StartPointMaxLength, MinimumLength = StartPointMinLength,
        ErrorMessage = "Start point must be between {2} and {1} characters.")]
    [Display(Name = "Start point")]
    public string StartPoint { get; set; } = null!;

    [Range(typeof(decimal), "0.1", "300",
        ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true,
        ErrorMessage = "Length must be between {1} and {2} km.")]
    [Display(Name = "Length (km)")]
    public decimal LengthKm { get; set; }

    [Range(ElevationGainMin, ElevationGainMax,
        ErrorMessage = "Elevation gain must be between {1} and {2} m.")]
    [Display(Name = "Elevation gain (m)")]
    public int ElevationGainM { get; set; }

    [Range(typeof(decimal), "0.5", "72",
        ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true,
        ErrorMessage = "Duration must be between {1} and {2} hours.")]
    [Display(Name = "Duration (hours)")]
    public decimal DurationHours { get; set; }

    [Display(Name = "Loop trail")]
    public bool IsLoop { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a region.")]
    [Display(Name = "Region")]
    public int RegionId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a difficulty.")]
    [Display(Name = "Difficulty")]
    public int DifficultyId { get; set; }

    public IEnumerable<LookupItemViewModel> Regions { get; set; } = new List<LookupItemViewModel>();

    public IEnumerable<LookupItemViewModel> Difficulties { get; set; } = new List<LookupItemViewModel>();
}
