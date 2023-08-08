namespace Chapter03_CORS_GlobalAPISettings.MapHelpers;
using Microsoft.AspNetCore.Cors;

public class CORSEndpointsHelper : IEndpointRouteHandler
{
    // CORS Also could be specified on Endpoint level
    // .RequireCors("MyCustomPolicy");
    // [EnableCors("Name")]
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cors", () => Results.Ok(new { CorsResultJson = true }));

        app.MapGet("/api/cors/extension", () => Results.Ok(new { CorsResultJson = true }))
            .RequireCors("My Defined CORS Policy");

        app.MapGet("/api/cors/annotation", [EnableCors("My Defined CORS Policy")] () =>
        {
            return Results.Ok(new { CorsResultJson = true });
        });
    }
}
