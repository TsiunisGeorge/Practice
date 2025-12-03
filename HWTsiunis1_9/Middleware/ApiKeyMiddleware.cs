namespace HwVar_1And9.Middleware;

public class ApiKeyMiddleware(RequestDelegate next)
{
    private const string HeaderName = "X-API-Key";

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(HeaderName, out var apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Forbidden: Missing X-API-Key header");
            return;
        }

        await next(context);
    }
}