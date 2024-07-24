using fitness_tracker.Data;
using fitness_tracker.DTOS;
using fitness_tracker.Entities;
using fitness_tracker.Mapping;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker.Controller;

public static class Controller
{
    public static RouteGroupBuilder MapLocationsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("locations").WithParameterValidation();

        group.MapGet("/", (FitnessTrackerContext dbContext) =>
        {
            return dbContext.Locations.ToList();
        });

        return group;
    }

    public static RouteGroupBuilder MapWorkoutsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("workouts").WithParameterValidation();

        //GET ALL WORKOUTS
        group.MapGet("/", async (FitnessTrackerContext dbContext) =>
        {
            return await dbContext.Workouts.Include(workout => workout.Location).ToListAsync();
        });

        //GET SPECIFIC WORKOUT    
        group.MapGet("/{id}", async (int id, FitnessTrackerContext dbContext) =>
        {
            Workout? workout = await dbContext.Workouts
                    .Include(workout => workout.Location)
                    .FirstOrDefaultAsync(workout => workout.Id == id);

            return workout is null ?
                 Results.NotFound() : Results.Ok(workout.ToDetailsDTO());
        })
        .WithName("GetWorkout");

        //ADD NEW WORKOUT
        group.MapPost("/", async (CreateWorkoutDTO newWorkout, FitnessTrackerContext dbContext) =>
        {
            Workout workout = newWorkout.ToEntity();

            dbContext.Workouts.Add(workout);

            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute("GetWorkout", new { id = workout.Id }, workout.ToSummaryDTO());
        });

        //UPDATE WORKOUT
        group.MapPut("/{id}", async (int id, UpdateWorkoutDTO updateWorkout, FitnessTrackerContext dbContext) =>
        {
            var workout = await dbContext.Workouts.FindAsync(id);

            if (workout is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(workout).
                    CurrentValues.
                    SetValues(updateWorkout.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, FitnessTrackerContext dbContext) =>
        {
            await dbContext.Workouts
                    .Where(workout => workout.Id == id)
                    .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
