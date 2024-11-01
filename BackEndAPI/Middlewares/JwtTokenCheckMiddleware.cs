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
        // this a dog shit solution, should have its own middlware
        if (context.Request.Path.Equals("/api/auth/login", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }

        if(!context.Request.Headers.ContainsKey("Authorization"))
        {
            SetAsUnauthorized(context, "Authorization Header not present.");
            return;
        }

        var authHeader = context.Request.Headers["Authorization"].ToString();
        
        if(!authHeader.StartsWith("Bearer: "))
        {
            SetAsUnauthorized(context, "Authorization Header has an invalid format.");
        }

        var token = authHeader.Substring("Bearer: ".Length).Trim();

        try 
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            
            if(!jwtHandler.CanReadToken(token))
            {
                SetAsUnauthorized(context, "Jwt has an invalid format.");
                return;
            }

            await _next(context);
        }
        catch (Exception ex)
        {
            SetAsUnauthorized(context, $"Error validating Jwt token: {ex.Message}");
        }

    }

    private async void SetAsUnauthorized(HttpContext context, string? message) {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync(message ?? "");
    }
}