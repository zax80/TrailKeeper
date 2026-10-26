using System.ComponentModel.DataAnnotations;
using static TrailKeeper.GCommon.ValidationConstants;

namespace TrailKeeper.Data.Models;
public class Region
{
    public int Id { get; set; }

    [Required]
    [MaxLength(RegionNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(RegionDescriptionMaxLength)]
    public string? Description { get; set; }

    public ICollection<Trail> Trails { get; set; } = new HashSet<Trail>();
}