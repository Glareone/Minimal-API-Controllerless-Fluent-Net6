namespace Chapter09_Authentication_AuthorizationClaims.MapHelper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

public class AnonymousEndpoints: IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", [AllowAnonymous] (LoginRequest request) => HandleLogin(request))
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK, typeof(AccessTokenResponse))
            .WithTags("Anonymous Login Endpoint").WithMetadata("Generate JWT for defined Username and Password");


        // using AllowAnonymous instead of attribute
        app.MapPost("/api/auth/login-with-allowanonymous", HandleLogin)
            .Produces(StatusCodes.Status200OK, typeof(AccessTokenResponse))
            .Produces(statusCode: StatusCodes.Status400BadRequest)
            .AllowAnonymous();
    }

    private IResult HandleLogin(LoginRequest request)
    {
        if (request.Username == "Glareone" && request.Password ==
            "Pa$$w0rd")
        {
            // Claims for Authorization
            var claims = new List<Claim>
            {
                // Role-based claims.
                // Pay attention: Role names are case sensitive
                new(ClaimTypes.Name, request.Username),
                new(ClaimTypes.Role, "Administrator"),
                new(ClaimTypes.Role, "User"),
                    
                // Policy-based claim. Will be used in AddAuthorization section and Authorize
                new("tenant-id", "42")
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
    }
}


internal record LoginRequest(string Username, string Password);

internal record AccessTokenResponse(string AccessToken);
