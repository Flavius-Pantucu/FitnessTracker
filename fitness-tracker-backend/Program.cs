using fitness_tracker.Data;
using fitness_tracker.Controller;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FitnessTrackerDB");
builder.Services.AddSqlite<FitnessTrackerContext>(connectionString);

var app = builder.Build();

app.MapWorkoutsEndpoints();
app.MapLocationsEndpoints();

await app.MigrateDbAsync();

app.Run();
