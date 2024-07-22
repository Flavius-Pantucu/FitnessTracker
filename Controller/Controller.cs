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
        group.MapGet("/", (FitnessTrackerContext dbContext) =>
        {
            return dbContext.Workouts.Include(workout => workout.Location).ToList();
        });

        //GET SPECIFIC WORKOUT    
        group.MapGet("/{id}", (int id, FitnessTrackerContext dbContext) =>
        {
            Workout? workout = dbContext.Workouts
                    .Include(workout => workout.Location)
                    .FirstOrDefault(workout => workout.Id == id);

            return workout is null ?
                 Results.NotFound() : Results.Ok(workout.ToDetailsDTO());
        })
        .WithName("GetWorkout");

        //ADD NEW WORKOUT
        group.MapPost("/", (CreateWorkoutDTO newWorkout, FitnessTrackerContext dbContext) =>
        {
            Workout workout = newWorkout.ToEntity();

            dbContext.Workouts.Add(workout);

            dbContext.SaveChanges();

            return Results.CreatedAtRoute("GetWorkout", new { id = workout.Id }, workout.ToSummaryDTO());
        });

        //UPDATE WORKOUT
        group.MapPut("/{id}", (int id, UpdateWorkoutDTO updateWorkout, FitnessTrackerContext dbContext) =>
        {
            var workout = dbContext.Workouts.Find(id);

            if (workout is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(workout).
                    CurrentValues.
                    SetValues(updateWorkout.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id, FitnessTrackerContext dbContext) =>
        {
            dbContext.Workouts
                    .Where(workout => workout.Id == id)
                    .ExecuteDelete();

            return Results.NoContent();
        });

        return group;
    }
}
