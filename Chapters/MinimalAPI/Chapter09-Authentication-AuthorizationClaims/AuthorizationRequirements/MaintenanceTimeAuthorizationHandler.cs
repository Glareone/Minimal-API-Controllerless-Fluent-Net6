namespace Chapter09_Authentication_AuthorizationClaims.AuthorizationRequirements;
using Microsoft.AspNetCore.Authorization;

// here is so-called "Policy Requirement" logic
// It's a collection of custom authorization rules which we provide for custom authorization logic

// A requirement class that implements the IAuthorizationRequirement interface and defines the requirement we want to manage
// A handler class that inherits from AuthorizationHandler and contains the logic to verify the requirement

// In MaintenanceTimeRequirement class we have custom fields we want to check manually.
// These fields refer to stand and end time of maintenance
// In MaintenanceTimeAuthorizationHandler class we check these fields
public class MaintenanceTimeAuthorizationHandler : AuthorizationHandler<MaintenanceTimeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MaintenanceTimeRequirement requirement)
    {
        var isAuthorized = true;
        if (!context.User.IsInRole("Administrator"))
        {
            var time = TimeOnly.FromDateTime(DateTime.Now);
            if (time >= requirement.StartTime && time <
                requirement.EndTime)
            {
                isAuthorized = false;
            }
        }
        if (isAuthorized)
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
