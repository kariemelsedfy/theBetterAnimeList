using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();
builder.Services.AddHttpClient<OAuthService>();

// Add CORS to allow Angular frontend (localhost:4200 during dev)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5001") // Update if needed
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Register your MyAnimeList service with HttpClient
builder.Services.AddHttpClient<MyAnimeListService>();

// Build the app
var app = builder.Build();

// Enable CORS before routing
app.UseCors();

app.UseRouting();
app.UseAuthorization();

// Map controllers like /api/anime/top
app.MapControllers();

app.Run();