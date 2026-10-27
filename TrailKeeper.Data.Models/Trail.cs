using System.ComponentModel.DataAnnotations;
using static TrailKeeper.GCommon.ValidationConstants;
using Microsoft.AspNetCore.Identity;

namespace TrailKeeper.Data.Models;
public class Trail
{
    public int Id { get; set; }

    [Required]
    [MaxLength(TrailNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(TrailDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(StartPointMaxLength)]
    public string StartPoint { get; set; } = null!;

    public decimal LengthKm { get; set; }
    public int ElevationGainM { get; set; }
    public decimal DurationHours { get; set; }
    public bool IsLoop { get; set; }
    public DateTime CreatedOn { get; set; }

    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;

    public int DifficultyId { get; set; }
    public Difficulty Difficulty { get; set; } = null!;

    public string? CreatorId { get; set; }

    public IdentityUser? Creator { get; set; }
}