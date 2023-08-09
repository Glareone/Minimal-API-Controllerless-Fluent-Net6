using Chapter04_ExceptionHandling.ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Chapter04_ExceptionHandling.MapHelper;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/ok-result", () =>
            {
                throw new ArgumentNullException("Custom Parameter Name 123",
                    "Predefined Error: Endpoint throws error as excepted to test exception middleware handler");
            })
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithName("OkResult");

        app.MapGet("/internal-server-error", () =>
            {
                throw new ArgumentNullException("taggia-parameter",
                    "Taggia has an error");
            })
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .WithName("internal-server-error");

        app.MapGet("/not-implemented-exception", () =>
            {
                throw new NotImplementedException
                    ("This is an exception thrown from a Minimal API.");
            })
            .Produces<ProblemDetails>(StatusCodes.Status501NotImplemented)
            .WithName("NotImplementedExceptions");

        // Use Results.Problem to enrich IETF output.
        // Quite popular way to solve the problem
        app.MapGet("/problems", () =>
            {
                return Results.Problem(detail: "This will end up in the 'detail' field.");
            })
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("Problems");
        
        // Custom filled error output
        // you may fill default fields along with custom fields we define in OutOfCreditProblemDetails
        // which is inherited from ProblemDetails class
        app.MapGet("/custom-error", () =>
            {
                var problem = new OutOfCreditProblemDetails
                {
                    Type = "https://example.com/probs/out-of-credit",
                    Title = "You do not have enough credit.",
                    Detail = "Your current balance is 30, but that costs 50.",
                    Instance = "/account/12345/msgs/abc",
                    Balance = 30.0m,
                    Accounts = { "/account/12345", "/account/67890" }
                };
                return Results.Problem(problem);
            })
            .Produces<OutOfCreditProblemDetails>(StatusCodes.Status400BadRequest);
    }
}
