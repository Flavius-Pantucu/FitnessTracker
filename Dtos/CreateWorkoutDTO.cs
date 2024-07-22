using System.ComponentModel.DataAnnotations;

namespace fitness_tracker.DTOS;

public record class CreateWorkoutDTO(
    [Required][StringLength(50)] string Name,
    [Required][Range(1, 600)] int Duration,
    [Required] DateTime Date,
    [Required] int LocationId
);
