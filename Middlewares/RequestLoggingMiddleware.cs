
using System.Diagnostics;
// Logging middleware to log HTTP requests and responses

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the HTTP method and request path
        var request = context.Request;
        Debug.WriteLine($"HTTP {request.Method} {request.Path}");

        // Call the next middleware in the pipeline
        await _next(context);

        // Log the response status code
        var response = context.Response;
        Debug.WriteLine($"Response Status Code: {response.StatusCode}");
    }
}

