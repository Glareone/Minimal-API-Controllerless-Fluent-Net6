using Chapter03_CORS_GlobalAPISettings.Options;
using Microsoft.Extensions.Options;

namespace Chapter03_CORS_GlobalAPISettings.MapHelpers;
using Chapter03_CORS_GlobalAPISettings.Configuration;

public class ConfigurationHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/read/configurations", (IConfiguration configuration) =>
        {
            var customObject = configuration.GetSection(nameof(MyCustomObject)).Get<MyCustomObject>();
            return Results.Ok(customObject);
        });

        app.MapGet("/read/options", (IOptions<OptionBasic> optionsBasic,
                IOptionsMonitor<OptionMonitor> optionsMonitor,
                IOptionsSnapshot<OptionSnapshot> optionsSnapshot,
                IOptionsFactory<OptionCustomName> optionsFactory) =>
            {
                return Results.Ok(new
                {
                    Basic = optionsBasic.Value,
                    // Pay attention that OptionMonitor has Value property, but to get access we use CurrentValue
                    Monitor = optionsMonitor.CurrentValue,
                    Snapshot = optionsSnapshot.Value,
                    Custom1 = optionsFactory.Create("CustomName1"),
                    Custom2 = optionsFactory.Create("CustomName2")
                });
            })
            .WithName("ReadOptions");

        app.MapGet("/read/validated-options", (IOptions<OptionsWithValidation> optionsValidation) => Results.Ok(new
            {
                Validation = optionsValidation
        }))
            .WithName("Read Validated Options");
    }
}
