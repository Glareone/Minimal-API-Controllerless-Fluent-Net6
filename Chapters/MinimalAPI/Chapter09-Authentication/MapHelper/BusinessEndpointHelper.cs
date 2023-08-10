using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Chapter09_Authentication.MapHelper;
using Microsoft.AspNetCore.Authorization;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", (LoginRequest request) =>
        {
            if (request.Username == "Glareone" && request.Password ==
                "Pa$$w0rd")
            {
                var claims = new List<Claim>()
                {
                    new(ClaimTypes.Name, request.Username)
                };
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-string-as-security-key-which-should-be-at-least-32bytes-or-16symbols-for-.net"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: "https://chapter09-Authentication.com/predefined-id",
                    audience: "https://chapter09-API-users",
                    claims: claims, expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials);
                var accessToken = new JwtSecurityTokenHandler()
                    .WriteToken(jwtSecurityToken);
                return Results.Ok(new AccessTokenResponse(accessToken));
            }

            return Results.BadRequest();
        })
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK, typeof(AccessTokenResponse))
            .WithTags("Generate JWT for defined Username and Password");

        // ClaimsPrincipal is automatically filled by this information
        app.MapGet("/api/me", [Authorize] (ClaimsPrincipal user) => $"Logged username: {user.Identity?.Name}");

        app.MapGet("/api/attribute-protected", [Authorize] () => "This endpoint is protected using the Authorize attribute");
        
        app.MapGet("/api/method-protected", () => "This endpoint is protected using the RequireAuthorization method")
            .RequireAuthorization();
    }
}

public record LoginRequest(string Username, string Password);

public record AccessTokenResponse(string AccessToken);


