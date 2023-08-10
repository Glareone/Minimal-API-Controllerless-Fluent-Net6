using FluentValidation;

namespace Chapter10_localization.MapHelper;
using Chapter10_localization.LocalizationResources;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/culture", () => Thread.CurrentThread.CurrentCulture.DisplayName);

        // Using localization resources
        // if you choose it they will return an answer registered in Messages.it.resx file
        // if you specify the language which is not supported or an send empty localization
        // you will receive parent culture, in our case - en (English)
        //
        // The request culture is it-IT: the system searches for Messages.it-IT.resx and then finds and uses Messages.it.resx.
        // The request culture is fr - FR: the system searches for Messages.fr - FR.resx, then Messages.fr.resx,
        // and(because neither are available) finally uses the default, Messages.resx.
        app.MapGet("/hello-world", () => Messages.HelloWorld);

        // Using Resx as pattern
        app.MapGet("/greeting-message-using-resx-pattern", (string name) => string.Format(Messages.GreetingMessage, name));

        // Use Fluent Validation with Resx
        app.MapPost("/people", async (Person person, IValidator<Person> validator) =>
        {
            var validationResult = await validator.
                ValidateAsync(person);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToDictionary();
                return Results.ValidationProblem(errors, title:
                    Messages.ValidationErrors);
            }
            return Results.NoContent();
        });
    }
}
