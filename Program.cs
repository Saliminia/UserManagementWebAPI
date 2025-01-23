
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMemoryCache(); // Added memory cache service for caching

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Use (async (context, next) => {
    var tokenService = new TokenService();
    var token = tokenService.GenerateToken();
    await next();
    Console.WriteLine($"\nActive Token is: \n{token}");
});

app.UseRouting();

// Use the error-handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

// Use the authentication middleware
app.UseMiddleware<AuthenticationMiddleware>();

// Use the logging middleware
app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();


