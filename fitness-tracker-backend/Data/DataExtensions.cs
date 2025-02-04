﻿using Microsoft.EntityFrameworkCore;

namespace fitness_tracker.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<FitnessTrackerContext>();
        await dbContext.Database.MigrateAsync();
    }
}
