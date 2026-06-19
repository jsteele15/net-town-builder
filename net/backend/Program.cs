var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This is to give permission to the frontend to access the backend API from a different origin.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod(); 
    });
});

// Build the app
var app = builder.Build();
var count = 0;

// Initialize the game map and player cities
// The length of the list determins how many cities are in the game. 

var gameMap = new List<int>
{
    0,0,0,0,0
};

// The first part will be the players id, the value of 0 represents an open area, 1 is taken
var playerCities = new Dictionary<string, int>
{
    {"", 0},
    {"", 0},
    {"", 0},
    {"", 0},
    {"", 0},
    {"", 0},
};

app.UseCors();

app.MapGet("/api/message", () => new { text = "Hello from .NET!" });

app.MapPost("/api/score", (Score score) =>
{
    count++;
    return Results.Ok(new { status = "saved", total = count });;
});

app.Run();
record Score(int Value);