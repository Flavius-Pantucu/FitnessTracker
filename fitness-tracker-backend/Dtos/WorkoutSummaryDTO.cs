namespace fitness_tracker.DTOS;

public record class WorkoutSummaryDTO(
    int Id,
    string Name,
    int Duration,
    DateTime Date,
    int Location
);
