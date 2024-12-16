using System.Reflection;
using Chapter12_API_Error_Format;
using Chapter12_API_Error_Format.ErrorHandling;
using Chapter12_API_Error_Format.WeatherServiceHttpClient;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Supported by old 7807 and new RFC 9457
// You may add specific status codes which could be assigned to endpoints
builder.Services.AddProblemDetails(options =>
{
    // we customize problem details format used on output in the middleware
    // app.UseProblemDetails();
    // and using registered service
    // builder.Services.AddExceptionHandler<ProblemExceptionHandler>();
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
        
        // add request identifier to the output
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

        // add traceid if possible
        var activity = context.HttpContext.Features.Get<IHttpActivityFeature?>()?.Activity;
        context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
    };
});

// To Handle Error according IETF Standard and new RFC 9457 (July 2023)
builder.Services.AddExceptionHandler<ProblemExceptionHandler>();

// typed Http client
builder.Services.AddHttpClient<OpenWeatherService>();

var app = builder.Build();

// IETF Standard of error handling.
// app.UseProblemDetails();

// To pack all details and make it according RFC 9457 using standardized way
// we can use UseExceptionHandler instead of UseProblemDetails method
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// register all endpoints using reflection
app.MapAllEndpoints(Assembly.GetExecutingAssembly());


app.UseHttpsRedirection();

// If you want to handle error manually and do not follow IETF Standards
//
// app.UseExceptionHandler(exceptionHandlerApp =>
//     exceptionHandlerApp.Run(async context =>
//     {
//         context.Response.StatusCode = StatusCodes.Status500InternalServerError;
//         context.Response.ContentType = MediaTypeNames.Application.Json;
//         
//         var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>()!;
//         var errorMessage = new
//         {
//             Message = exceptionHandlerPathFeature.Error.Message
//         };
//
//         await context.Response.WriteAsync
//             (JsonSerializer.Serialize(errorMessage));
//         if (exceptionHandlerPathFeature?.
//                 Error is FileNotFoundException)
//         {
//             await context.Response.
//                 WriteAsync(" The file was not found.");
//         }
//         if (exceptionHandlerPathFeature?.Path == "/")
//         {
//             await context.Response.WriteAsync("Page: Home.");
//         }
//     }));

app.Run();
