using fitness_tracker.Entities;

namespace fitness_tracker.DTOS;

public record class WorkoutDetailsDTO
(
    int Id,
    string Name,
    int Duration,
    DateTime Date,
    Location Location
);
