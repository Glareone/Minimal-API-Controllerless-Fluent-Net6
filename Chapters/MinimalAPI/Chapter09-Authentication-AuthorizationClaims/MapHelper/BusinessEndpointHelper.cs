namespace Chapter09_Authentication_AuthorizationClaims.MapHelper;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        // ClaimsPrincipal is automatically filled by this information
        app.MapGet("/api/me", [Authorize] (ClaimsPrincipal user) => $"Logged username: {user.Identity?.Name}");

        app.MapGet("/api/attribute-protected", [Authorize] () => "This endpoint is protected using the Authorize attribute");
        
        app.MapGet("/api/method-protected", () => "This endpoint is protected using the RequireAuthorization method")
            .RequireAuthorization();
    }
}


