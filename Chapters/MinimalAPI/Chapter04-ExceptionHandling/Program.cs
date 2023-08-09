using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using Chapter04_ExceptionHandling;
using Chapter04_ExceptionHandling.ErrorHandling;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// To Handle Error according IETF Standard
builder.Services.AddSingleton<IActionResultExecutor<ObjectResult>, ProblemDetailsResultExecutor>();
// You may add specific status codes which could be assigned to endpoints
builder.Services.AddProblemDetails(options =>
{
    options.MapToStatusCode<NotImplementedException>
        (StatusCodes.Status501NotImplemented);
});


var app = builder.Build();

// IETF Standard of error handling.
// Use Problem Details Package in our middleware
app.UseProblemDetails();

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
