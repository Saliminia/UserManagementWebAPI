// Authentication middleware to validate tokens and authorize users

using System.IdentityModel.Tokens.Jwt;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null || !ValidateToken(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await _next(context);
    }

    private bool ValidateToken(string token)
    {
        // Token validation logic (e.g., using JwtSecurityTokenHandler)
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            // Add your token validation logic here (e.g., checking issuer, audience, expiration, etc.)
            return jwtToken != null;
        }
        catch
        {
            return false;
        }
    }
}
