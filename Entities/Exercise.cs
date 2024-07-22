namespace fitness_tracker.Entities;

public class Exercise
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Type { get; set; }

    public required string PrimaryGroup { get; set; }

    public required string SecondaryGroup { get; set; }
}
