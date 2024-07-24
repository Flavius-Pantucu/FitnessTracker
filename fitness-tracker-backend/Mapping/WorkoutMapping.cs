using fitness_tracker.DTOS;
using fitness_tracker.Entities;

namespace fitness_tracker.Mapping;

public static class WorkoutMapping
{
    public static Workout ToEntity(this CreateWorkoutDTO workout)
    {
        return new()
        {
            Name = workout.Name,
            Duration = workout.Duration,
            Date = workout.Date,
            LocationId = workout.LocationId
        };
    }

    public static Workout ToEntity(this UpdateWorkoutDTO workout, int id)
    {
        return new()
        {
            Id = id,
            Name = workout.Name,
            Duration = workout.Duration,
            Date = workout.Date,
            LocationId = workout.LocationId
        };
    }

    public static WorkoutDetailsDTO ToDetailsDTO(this Workout workout)
    {
        return new(
            workout.Id,
            workout.Name,
            workout.Duration,
            workout.Date,
            workout.Location!
        );
    }

    public static WorkoutSummaryDTO ToSummaryDTO(this Workout workout)
    {
        return new(
            workout.Id,
            workout.Name,
            workout.Duration,
            workout.Date,
            workout.LocationId
        );
    }
}
