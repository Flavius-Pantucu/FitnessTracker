using fitness_tracker.Entities;

namespace fitness_tracker.Entities;

public class Set
{
    public int Id { get; set; }


    public required string Type { get; set; }

    public required int SetNumber { get; set; }

    public required string Repetitions { get; set; }

    public required string Weight { get; set; }

    public int ExerciseId { get; set; }

    public Exercise? Exercise { get; set; }
}
