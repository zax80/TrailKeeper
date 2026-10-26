using System.ComponentModel.DataAnnotations;
using static TrailKeeper.GCommon.ValidationConstants;

public class Difficulty
{
    public int Id { get; set; }

    [Required]
    [MaxLength(DifficultyNameMaxLength)]
    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public ICollection<Trail> Trails { get; set; } = new HashSet<Trail>();
}