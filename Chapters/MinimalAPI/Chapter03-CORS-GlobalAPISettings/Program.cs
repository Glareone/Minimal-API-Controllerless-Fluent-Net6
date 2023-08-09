using System.Reflection;
using Chapter03_CORS_GlobalAPISettings;
using Chapter03_CORS_GlobalAPISettings.Configuration;
using Chapter03_CORS_GlobalAPISettings.OperationFilters;
using Chapter03_CORS_GlobalAPISettings.Options;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Read Configuration Settings
// 
var startupConfig = builder.Configuration.GetSection(nameof(MyCustomStartupObject)).Get<MyCustomStartupObject>();
var myCustomValue = builder.Configuration.GetValue<string>("MyCustomValue");


// Read Configuration using Options
//
builder.Services.Configure<OptionBasic>(builder.Configuration.GetSection("OptionBasic"));
builder.Services.Configure<OptionMonitor>(builder.Configuration.GetSection("OptionMonitor"));
builder.Services.Configure<OptionSnapshot>(builder.Configuration.GetSection("OptionSnapshot"));
builder.Services.Configure<OptionCustomName>("CustomName1", builder.Configuration.GetSection("CustomName1"));
builder.Services.Configure<OptionCustomName>("CustomName2", builder.Configuration.GetSection("CustomName2"));
// Reread and Configure new ConfigOptions
builder.Services.PostConfigure<MyConfigOptions>(myOptions =>
{
    myOptions.Key1 = "my_new_value_post_configuration";
});

builder.Services.AddOptions<OptionsWithValidation>()
    .Bind(builder.Configuration.GetSection(nameof(OptionsWithValidation)))
    .ValidateDataAnnotations()
    // Custom inline validation
    .Validate((config) => !string.Equals(config.Email, "wrongemail@gmail.com", StringComparison.CurrentCultureIgnoreCase));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<CorrelationIdOperationFilter>();

    // Swagger versioning
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1",
        Contact = new()
        {
            Name = "Aleksei Kolesnikov",
            Email = "my-work-email@gmail.com",
            Url = new Uri("https://github.com/Glareone")
        },
        Description = "Minimal API - Chapter 02",
        License = new Microsoft.OpenApi.Models.
            OpenApiLicense(),
        TermsOfService = new("https://github.com/Glareone")
    });
});

builder.Services.AddScoped<PeopleService>();

var corsPolicy = new CorsPolicyBuilder("http://localhost:5200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .Build();

// Add CORS You registered without specifying a name
// builder.Services.AddCors(c => c.AddDefaultPolicy(corsPolicy));

// Add named CORS. It could be associated to selected endpoints or request types. Useful in case of microservices
builder.Services.AddCors(c => c.AddPolicy("My Defined CORS Policy", corsPolicy));

var app = builder.Build();

// Use CORS for the whole application
//app.UseCors();

app.UseCors("My Defined CORS Policy");

// CORS Also could be specified on Endpoint level
// .RequireCors("MyCustomPolicy");
// [EnableCors("Name")]

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// register all endpoints using reflection
app.MapAllEndpoints(Assembly.GetExecutingAssembly());

app.UseHttpsRedirection();

app.Run();
