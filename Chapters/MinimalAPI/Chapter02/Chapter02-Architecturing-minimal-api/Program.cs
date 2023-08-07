using System.Reflection;
using Chapter02_Architecturing_minimal_api;
using Chapter02_Architecturing_minimal_api.OperationFilters;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

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
