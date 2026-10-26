namespace TrailKeeper.GCommon;

public static class ValidationConstants
{
    // Trail
    public const int TrailNameMinLength = 3;
    public const int TrailNameMaxLength = 100;
    public const int TrailDescriptionMinLength = 20;
    public const int TrailDescriptionMaxLength = 2000;
    public const int StartPointMinLength = 3;
    public const int StartPointMaxLength = 100;
    public const double LengthKmMin = 0.1;
    public const double LengthKmMax = 300;
    public const int ElevationGainMin = 0;
    public const int ElevationGainMax = 5000;
    public const double DurationMin = 0.5;
    public const double DurationMax = 72;

    // Region
    public const int RegionNameMaxLength = 50;
    public const int RegionDescriptionMaxLength = 500;

    // Difficulty
    public const int DifficultyNameMaxLength = 30;
}