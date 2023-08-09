namespace Chapter05_Logging.MapHelper;
using Chapter05_Logging.Alerts;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/first-log", (ILogger<CategoryFiltered> loggerCategory, ILogger<MyCategoryAlert> loggerAlertCategory) =>
            {
                loggerCategory.LogInformation("I'm information { MyName}", "My Name Information");
                loggerCategory.LogDebug("I'm debug {MyName}",
                    "My Name Debug");
                
                loggerCategory.LogInformation("I'm debug {Data}", new PayloadData("CategoryRoot", "Debug"));
                
                loggerAlertCategory.LogInformation("I'm information { MyName}", "Alert Information");
                
                loggerAlertCategory.LogDebug("I'm debug {MyName}",
                    "Alert Debug");

                var p = new PayloadData("AlertCategory", "Debug");
                loggerAlertCategory.LogDebug("I'm debug {Data}", p);
                return Results.Ok();
            })
            .WithName("GetFirstLog");
    }
}

public record PayloadData(string AlertCategory, string Debug);
