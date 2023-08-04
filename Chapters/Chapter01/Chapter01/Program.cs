using System.Security.Claims;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// for implicit attributes cast example
builder.Services.AddScoped<PeopleService>();

// Configure JsonOptions like we did in Controller using AddJsonOptions() after AddControllers();
// JsonOptions comes from Microsoft.AspNetCore.Http.Json, not from Microsoft.AspNetCore.Mvc
// JsonOptions from Microsoft.AspNetCore.Mvc is valid only for controllers, not for minimalAPI
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.
    JsonOptions>(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.IgnoreReadOnlyProperties
        = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Default methods available out of the box
app.MapGet("/hello-get", () => " [GET] Hello Get");
app.MapPost("/hello-post", () => " [POST] Hello POST");
app.MapPut("/hello-put", () => " [PUT] Hello PUT");
app.MapDelete("/hello-delete", () => " [DELETE] Hello PUT");

// PATCH and HEAD using MapMethods
app.MapMethods("/hello-patch", new[] { HttpMethods.Patch }, () => "[PATCH] Hello Patch");
app.MapMethods("/hello-head", new[] { HttpMethods.Head }, () => "[HEAD] Hello Head");

// Lambda
var helloLambdaHandler = () => "[Lambda] Hello Lambda";
app.MapGet("/hello-lambda", () => helloLambdaHandler);

// Instance Method
var instanceHandler = new InstanceHandler();
app.MapGet("/hello-instance-handler", instanceHandler.Hello);

// Route with type checks
app.MapGet("/users/{username}/products/{productId}",
    (string username, int productId) 
        => $"The Username is {username} and the product Id is {productId}");

// Route with constraints
app.MapGet("/users/{id:int}", (int id) => $"the userID is int and value is {id}");
app.MapGet("/users/{id:guid}", (Guid id) => $"the userID is GUID and value is {id}");

// Implicit attributes cast
app.MapPut("/people/{id:int}", (int id, bool notify, Person person, PeopleService peopleService) => { });

// Explicit Attributes for parameters
app.MapGet("/search", ([FromQuery(Name = "q")] string searchText) => { });

// PageIndex and ItemsPerPage are mandatory to be declared in query
app.MapGet("/people", (int pageIndex, int itemsPerPage) => { });

// Nullable query parameter
app.MapGet("/people", (string? orderBy) => $"Results ordered by {orderBy}");

// Optional Parameters in lambda are not available
//app.MapGet("/people", (int pageIndex = 0, int itemsPerPage = 50) => { });

// Context, Response, ClaimsPrincipal for minimalAPI
app.MapGet("/products", (HttpContext context, HttpRequest req, HttpResponse res, ClaimsPrincipal user) => { });

// Results.OK, Results.BadRequest, Results.NotFound
app.MapGet("/ok", () => Results.Ok(new Person("Aleksei", "Glareone")));
app.MapGet("/not-found", () => Results.NotFound());
app.MapPost("/bad-request", () => Results.BadRequest(new { ErrorMessage = "Unable to complete the request" }));

app.Run();

// Instance Class
class InstanceHandler
{
    public string Hello() => "Hello Instance handler";
}

public class PeopleService { }
public record Person(string FirstName, string LastName);