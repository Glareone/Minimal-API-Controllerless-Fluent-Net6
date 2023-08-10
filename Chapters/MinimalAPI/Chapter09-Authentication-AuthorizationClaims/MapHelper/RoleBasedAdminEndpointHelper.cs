using System.Security.Claims;

namespace Chapter09_Authentication_AuthorizationClaims.MapHelper;
using Microsoft.AspNetCore.Authorization;

public class RoleBasedAdminEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        // Role names are case sensitive. They come from token Claims
        //
        app.MapGet("/api/admin-attribute-protected", [Authorize(Roles = "Administrator")] () => Results.Ok("Admin visited endpoint"));
        app.MapGet("/api/admin-method-protected", () => Results.Ok("Admin visited endpoint"))
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Administrator" });

        app.MapGet("/api/role-check", [Authorize] (ClaimsPrincipal user) =>
        {
            if (user.IsInRole("Administrator"))
            {
                return "User is an Administrator";
            }
            return "This is a normal user";
        });
    }
}
