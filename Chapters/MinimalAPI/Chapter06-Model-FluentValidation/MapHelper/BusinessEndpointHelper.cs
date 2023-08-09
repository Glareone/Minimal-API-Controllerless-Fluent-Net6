namespace Chapter06_Model_FluentValidation.MapHelper;
using Chapter06_Model_FluentValidation.DTO;
using FluentValidation;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/people", async (Person person, IValidator<Person> validator) =>
        {
            var validationResult = await validator.ValidateAsync(person);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToDictionary();
                return Results.ValidationProblem(errors);
            }
            return Results.NoContent();
        })
            // for Swagger
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem();
    }
}


