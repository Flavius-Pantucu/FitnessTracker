using fitness_tracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker.Data;

public class FitnessTrackerContext(DbContextOptions<FitnessTrackerContext> options) : DbContext(options)
{
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<Set> Sets => Set<Set>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Workout> Workouts => Set<Workout>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(
            new { Id = 1, Name = "Gorilla ElectroPutere", Address = "Craiova ElectroPutere Mall", Schedule = "7:00 - 23:00" },
            new { Id = 2, Name = "Gorilla 1 Mai", Address = "Craiova 1 Mai", Schedule = "6:00 - 24:00" },
            new { Id = 3, Name = "Gorilla Centru", Address = "Craiova Centru", Schedule = "8:00 - 24:00" }
        );
    }
}