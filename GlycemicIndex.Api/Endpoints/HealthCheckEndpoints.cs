using GlycemicIndex.Infrastructure;

namespace GlycemicIndex.Api.Endpoints;

public static class HealthCheckEndpoints
{
    public static void MapHealthCheckEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/healthcheck/ping", (DbContextGI dbContext) =>
            {
                var result = dbContext.Database.CanConnect();
                return Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow, db = result });
            })
            .WithName("HealthCheckPing")
            .WithOpenApi();
    }
}