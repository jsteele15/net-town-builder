var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod(); 
    });
});

var app = builder.Build();
var count = 0;
app.UseCors();

app.MapGet("/api/message", () => new { text = "Hello from .NET!" });

app.MapPost("/api/score", (Score score) =>
{
    count++;
    return Results.Ok(new { status = "saved", total = count });;
});

app.Run();
record Score(int Value);