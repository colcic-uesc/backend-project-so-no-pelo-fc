using System;
using System.IdentityModel.Tokens.Jwt;

namespace BackEndAPI.Middlewares;

public class JwtTokenCheckMiddleware
{
    private readonly RequestDelegate _next;

    public JwtTokenCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Skip login path
        if (context.Request.Path.Equals("/api/auth/login", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }

        // Check if Authorization header exists
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            await SetAsUnauthorized(context, "Authorization Header not present.");
            return;
        }

        var authHeader = context.Request.Headers["Authorization"].ToString();

        // Validate the format of Authorization header
        if (!authHeader.StartsWith("Bearer: "))
        {
            await SetAsUnauthorized(context, "Authorization Header has an invalid format.");
            return;
        }

        var token = authHeader.Substring("Bearer: ".Length).Trim();

        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            // Check if the token is readable
            if (!jwtHandler.CanReadToken(token))
            {
                await SetAsUnauthorized(context, "Jwt has an invalid format.");
                return;
            }

            await _next(context); // Only call _next if the token is valid
        }
        catch (Exception ex)
        {
            await SetAsUnauthorized(context, $"Error validating Jwt token: {ex.Message}");
        }
    }

    private async Task SetAsUnauthorized(HttpContext context, string message)
    {
        // Prevent further processing and set status to 401
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync(message ?? "");
    }
}
