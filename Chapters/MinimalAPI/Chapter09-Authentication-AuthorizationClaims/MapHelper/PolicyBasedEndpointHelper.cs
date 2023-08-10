namespace Chapter09_Authentication_AuthorizationClaims.MapHelper;
using Microsoft.AspNetCore.Authorization;

public class PolicyBasedEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        // all endpoints are policy-based protected using Authorize attribute
        // or .RequireAuthorization() declaration
        app.MapGet("/api/policy-attribute-protected", [Authorize(Policy = "Tenant42")] () => Results.Ok("Confirm that user has claim 'Tenant-id' and its value is 42"));
        app.MapGet("/api/policy-method-protected", () => Results.Ok("Confirm that user has claim 'Tenant-id' and its value is 42"))
            .Produces(StatusCodes.Status200OK)
            .RequireAuthorization("Tenant42");
    }
}
