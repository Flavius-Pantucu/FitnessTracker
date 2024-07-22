namespace fitness_tracker.Entities;

public class Location
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Address { get; set; }

    public required string Schedule { get; set; }
}
