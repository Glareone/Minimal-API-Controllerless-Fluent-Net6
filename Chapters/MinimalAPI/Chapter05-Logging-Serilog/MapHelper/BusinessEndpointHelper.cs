namespace Chapter05_Logging_Serilog.MapHelper;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/serilog", (ILogger<CategoryFiltered> loggerCategory) =>
            {
                loggerCategory.LogInformation("I'm {@Person}", new
                    Person("Alex", "Glareone", new DateTime(1970, 11,
                        11)));
                return Results.Ok();
            })
            .WithName("GetFirstLog");
    }
}

internal record Person(string Name, string Surname, DateTime Birthdate);
internal record CategoryFiltered();
