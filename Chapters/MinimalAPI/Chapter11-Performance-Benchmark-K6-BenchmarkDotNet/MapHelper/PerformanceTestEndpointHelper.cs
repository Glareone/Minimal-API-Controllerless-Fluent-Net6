namespace Chapter11_Performance_Benchmark_K6_BenchmarkDotNet.MapHelper;
using Chapter11_Performance_Benchmark_K6_BenchmarkDotnet;

public class PerformanceTestEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("text-plain", () => Results.Content("response"))
            .Produces(StatusCodes.Status200OK, typeof(string))
            .WithName("GetTextPlain");

        app.MapPost("validations", (ValidationData validation) => Results.Ok(validation))
            .Produces(StatusCodes.Status200OK, typeof(ValidationData))
            .WithName("PostValidationData");
        
        app.MapGet("jsons", () =>
            {
                var response = new[]
                {
                    new PersonData { Name = "Andrea", Surname = "Tosato", BirthDate = new DateTime(2022, 01, 01) },
                    new PersonData { Name = "Emanuele", Surname = "Bartolesi", BirthDate = new DateTime(2022, 01, 01) },
                    new PersonData { Name = "Marco", Surname = "Minerva", BirthDate = new DateTime(2022, 01, 01) }
                };
                return Results.Ok(response);
            })
            .Produces<IEnumerable<PersonData>>(StatusCodes.Status200OK)
            .WithName("GetJsonData");
    }
}

internal class ValidationData
{
    public int Id { get; set; }

    public string Description { get; set; }
}

internal class PersonData
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
}
