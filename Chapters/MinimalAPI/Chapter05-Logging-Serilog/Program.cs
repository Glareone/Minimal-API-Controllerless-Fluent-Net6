using System.Reflection;
using Chapter05_Logging_Serilog;
using Microsoft.ApplicationInsights.Extensibility;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// for MinimalAPI metadata
// information is here: https://stackoverflow.com/questions/71932980/what-is-addendpointsapiexplorer-in-asp-net-core-6
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Azure AppInsights Logging and Telemetry using default logger
//
// builder.Services.AddApplicationInsightsTelemetry();
// builder.Logging.AddApplicationInsights();

// Using Serilog for AppInsights and Console
builder.Logging.AddSerilog();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure where to write our logs
// AppInsights & Console. They have different output format which is declared in appsettings
Log.Logger = new LoggerConfiguration()
    // To AppInsights
    .WriteTo.ApplicationInsights(app.Services.GetRequiredService<TelemetryConfiguration>(), TelemetryConverter.Traces)
    // To Console
    .WriteTo.Console()                // Console 2
    .CreateLogger();


app.MapAllEndpoints(Assembly.GetExecutingAssembly());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
