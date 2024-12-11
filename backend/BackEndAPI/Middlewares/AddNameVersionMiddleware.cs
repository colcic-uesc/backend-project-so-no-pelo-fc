using System;

namespace BackEndAPI.Middlewares;

public class AddNameVersionMiddleware
{
    private readonly RequestDelegate _next;

    public AddNameVersionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Append("X-APP-Name", "Web's API");
        context.Response.Headers.Append("X-APP-API-Version", "0.1");

        await _next(context);
    }
}