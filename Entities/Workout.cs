namespace fitness_tracker.Entities;

public class Workout
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required int Duration { get; set; }

    public required DateTime Date { get; set; }

    public required int LocationId { get; set; }

    public Location? Location { get; set; }
}
