namespace Chapter10_localization.MapHelper;

internal class DateTimeEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/date", (DateInput date) =>
            Results.Ok(new
            {
                Input = date.Value,
                DateKind = date.Value.Kind.ToString(),
                ServerDate = DateTime.Now
            }));
    }
}

internal record DateInput(DateTime Value);
