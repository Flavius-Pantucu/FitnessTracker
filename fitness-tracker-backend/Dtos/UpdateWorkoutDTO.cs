using System.ComponentModel.DataAnnotations;

namespace fitness_tracker.DTOS;

public record class UpdateWorkoutDTO(
    [Required][StringLength(50)] string Name,
    [Required][Range(1, 600)] int Duration,
    [Required] DateTime Date,
    [Required] int LocationId
);
