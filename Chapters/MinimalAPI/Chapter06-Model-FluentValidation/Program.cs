using System.Reflection;
using Chapter06_Model_FluentValidation;
using FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Validators
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Separate Package
// Adds Validation Rules Description in Swagger to all fields which use Fluent Validation
builder.Services.AddFluentValidationRulesToSwagger();

var app = builder.Build();

app.MapAllEndpoints(Assembly.GetExecutingAssembly());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
