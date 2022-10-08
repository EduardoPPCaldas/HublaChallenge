using Application.Sales.Ports;
using Application.Sales.UseCases;
using Data;
using Data.Data.Sales;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Setup Database
    var server = builder.Configuration["DatabaseServer"] ?? "";
    var port = builder.Configuration["DatabasePort"] ?? "";
    var user = builder.Configuration["DatabaseUser"] ?? "";
    var password = builder.Configuration["DatabasePassword"] ?? "";
    var databaseName = builder.Configuration["DatabaseName"] ?? "";

    var connectionString = builder.Configuration.GetConnectionString("Main");

    if (!string.IsNullOrEmpty(server) &&
        !string.IsNullOrEmpty(port) &&
        !string.IsNullOrEmpty(user) &&
        !string.IsNullOrEmpty(password) &&
        !string.IsNullOrEmpty(databaseName))
    {
        connectionString = $"Server={server};Database={databaseName};Port={port};User Id={user};Password={password}";
    }
    builder.Services.AddDbContext<DatabaseContext>(
        options => options.UseNpgsql(connectionString)
    );
#endregion

#region Dependency Injection
    builder.Services.AddScoped<ISaleRepository, SaleRepository>();
    builder.Services.AddScoped<ISaleUseCase, SaleUseCase>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
