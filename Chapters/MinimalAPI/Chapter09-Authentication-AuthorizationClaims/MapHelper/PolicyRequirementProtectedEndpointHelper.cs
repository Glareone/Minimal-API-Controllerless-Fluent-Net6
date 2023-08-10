namespace Chapter09_Authentication_AuthorizationClaims.MapHelper;
using Microsoft.AspNetCore.Authorization;

public class PolicyRequirementProtectedEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        // policy-requirement claims.
        // declared in MaintenanceTimeRequirement class
        // handled in MaintenanceTimeAuthorizationHandler
        // in AddAuthorization we declare "TimeAccessPolicy" name
        app.MapGet("/api/policy-requirement-protected-known-as-custom-policy", [Authorize(Policy = "TimedAccessPolicy")] () => 
            Results.Ok("TimedAccessPolicy. Access granted in maintenance window because either we have admin role or we are user in maintenance window"))
            .Produces(statusCode: StatusCodes.Status200OK);

    }
}
