using Microsoft.Net.Http.Headers;

namespace Chapter10_localization.OperationFilter;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;


public class AcceptLanguageHeaderOperationFilter : IOperationFilter
{
    private readonly IList<IOpenApiAny>? supportedLanguages;

    public AcceptLanguageHeaderOperationFilter(IOptions<RequestLocalizationOptions> requestLocalizationOptions)
    {
        supportedLanguages =
            requestLocalizationOptions.Value.
                SupportedCultures?.Select(c => new OpenApiString(c.TwoLetterISOLanguageName)).
                Cast<IOpenApiAny>().ToList();
    }

    public void Apply(OpenApiOperation operation,
        OperationFilterContext context)
    {
        // Fill up the Swagger Culture list
        if (supportedLanguages?.Any() ?? false)
        {
            operation.Parameters ??= new
                List<OpenApiParameter>();
            operation.Parameters.Add(new
                OpenApiParameter
                {
                    Name = HeaderNames.AcceptLanguage,
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Enum = supportedLanguages,
                        Default = supportedLanguages.
                            First()
                    }
                });
        }
    }
}
