using AvailabilityAPI.Data;
using AvailabilityAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//// Database Context Dependency Injection

//string dbServer = "THE-RHINO\\MSSQLSERVER01";
//string dbName = "Availability_DB";
//string dbUser = "sa";
//string dbPassword = "sa";

// Passing Environment variables for db credentials

var dbServer = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = "sa";
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString = $"Data Source={dbServer};Initial Catalog={dbName};User ID={dbUser};Password={dbPassword};TrustServerCertificate=True";
builder.Services.AddDbContext<AvailabilityDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
builder.Services.AddScoped<IExamCenterService, ExamCenterService>();

/* ========================================= */

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();