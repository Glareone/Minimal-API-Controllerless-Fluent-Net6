using System.Globalization;
using System.Reflection;
using Chapter10_localization;
using Chapter10_localization.OperationFilter;
using FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AcceptLanguageHeaderOperationFilter> ();
});

// Register Validators
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Separate Package
// Adds Validation Rules Description in Swagger to all fields which use Fluent Validation
// Could be found under Schema section
builder.Services.AddFluentValidationRulesToSwagger();


// Support Localization
var supportedCultures = new CultureInfo[] { new("en"), new("it"), new("fr") };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());
});

var app = builder.Build();
app.MapAllEndpoints(Assembly.GetExecutingAssembly());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// set the current culture of each request
// even it it's not declared in request (handled by default behavior as well)
// We usually set the request culture through the Accept-Language HTTP header
// Options:
// QueryStringRequestCultureProvider: Searches for the culture and ui-culture query string parameters
// CookieRequestCultureProvider: Uses the ASP.NET Core cookie
// AcceptLanguageHeaderRequestProvider: Reads the requested culture from the Accept-Language HTTP header
// https://docs.microsoft.com/aspnet/core/fundamentals/localization#use-a-custom-provider 
app.UseRequestLocalization();

app.Run();
