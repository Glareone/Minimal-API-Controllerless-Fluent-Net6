using System.Reflection;
using System.Text.Json;
using Chapter05_Logging;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// W3C Logging which is not well-known
// Will write to w3clog file located in logs/w3clog....txt
//
/*
 builder.Services.AddW3CLogging(logging =>
 {
     logging.LoggingFields = W3CLoggingFields.All;
 });
*/

builder.Logging.AddJsonConsole(options =>
    options.JsonWriterOptions = new JsonWriterOptions()
    {
        Indented = true
    });

var app = builder.Build();

// register all endpoints using reflection
app.MapAllEndpoints(Assembly.GetExecutingAssembly());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// W3C Logging
//
//app.UseW3CLogging();

app.UseHttpsRedirection();

app.Run();
