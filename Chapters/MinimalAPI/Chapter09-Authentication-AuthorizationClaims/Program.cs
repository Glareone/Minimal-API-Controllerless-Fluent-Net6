using System.Reflection;
using System.Text;
using Chapter09_Authentication_AuthorizationClaims;
using Chapter09_Authentication_AuthorizationClaims.AuthorizationRequirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Name = HeaderNames.Authorization,
            Description = "Insert the token with the 'Bearer ' prefix"
        });

    options.AddSecurityRequirement(new
        OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id =
                            JwtBearerDefaults.AuthenticationScheme
                    }
                },
                Array.Empty<string>()
            }
        });
});

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("my-string-as-security-key-which-should-be-at-least-32bytes-or-16symbols-for-.net")),
            ValidIssuer = "https://chapter09-Authentication.com/predefined-id",
            ValidAudience = "https://chapter09-API-users"
        };
    });

// in this example we use policy-based claims
// and custom policy-requirement claims we use in MaintenanceTimeRequirement & MaintenanceTimeAuthorizationHandler classes
// policy-based claim we assigned in login endpoint logic
// time access policy we check in our custom requirements logic
builder.Services.AddAuthorization(options =>
{
    // Default policy which is applied to all endpoints
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireClaim("tenant-id").Build();
    options.DefaultPolicy = policy;

    // A fallback policy, on the other hand, is the policy that is applied when there is no authorization information on the endpoints.
    // It is useful, for example, when we want all our endpoints to be automatically protected,
    // even if we forget to specify the Authorize attribute or just don’t want to repeat the attribute for each handler.
    //
    // We have said that the default policy requires that the user be authenticated,
    // so the result of this code is that now, all the endpoints automatically need authentication, even if we don’t explicitly protect them.
    //
    // Now all endpoints are protected by default even without declared [Authorize] attribute
    // It means we need to say which endpoints allow anonymous access using [AllowAnonymous]
    options.FallbackPolicy = options.DefaultPolicy;

    // for policy-based authorization
    options.AddPolicy("Tenant42", policy =>
    {
        policy.RequireClaim("tenant-id", "42");
    });

    // for policy-requirement authorization used in MaintenanceTimeRequirement & MaintenanceTimeRequirementHandler
    // [Authorize(Policy = TimedAccessPolicy)]
    options.AddPolicy("TimedAccessPolicy", policy =>
    {
        policy.Requirements.Add(new
            MaintenanceTimeRequirement
            {
                // Maintenance is available from 12AM till 4AM
                StartTime = new TimeOnly(0, 0, 0),
                EndTime = new TimeOnly(4, 0, 0)
            });
    });
});

// policy-requirement claims logic
// we add policy TimedAccessPolicy abowe for it 
// we have MaintenanceTimeRequirement & Handler classes to handle it
builder.Services.AddScoped<IAuthorizationHandler, MaintenanceTimeAuthorizationHandler>();

var app = builder.Build();

// Map All Endpoints
app.MapAllEndpoints(Assembly.GetExecutingAssembly());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.Run();

