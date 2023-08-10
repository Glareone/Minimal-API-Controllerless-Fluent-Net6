namespace Chapter09_Authentication_AuthorizationClaims.AuthorizationRequirements;
using Microsoft.AspNetCore.Authorization;

// here is so-called "Policy Requirement" logic
// It's a collection of custom authorization rules which we provide for custom authorization logic

// A requirement class that implements the IAuthorizationRequirement interface and defines the requirement we want to manage
// A handler class that inherits from AuthorizationHandler and contains the logic to verify the requirement

// Exact this example: 
// The requirement contains the start and end times of the maintenance window.
// During this interval, we only want administrators to be able to operate.
public class MaintenanceTimeRequirement : IAuthorizationRequirement
{
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
}
