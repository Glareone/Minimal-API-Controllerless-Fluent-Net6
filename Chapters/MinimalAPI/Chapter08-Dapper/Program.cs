using System.Reflection;
using Chapter08_Dapper;
using Chapter08_Dapper.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dapper & Repository
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IIcecreamsRepository, IcecreamsRepository>();

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
