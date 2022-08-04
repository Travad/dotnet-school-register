// 1. Configurations

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.API.DbContexts;
using SchoolRegister.API.Services.Repositories.Students;

var builder = WebApplication.CreateBuilder(args);

// 2. Services (Dependency Injection)
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); // enable 1-1 relationships (since potential cycle reference)

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<SchoolRegisterDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqllite")));

// Services

// Query repository
builder.Services.AddScoped<IStudentRepository, StudentRepository>(); // re-create at every request
// Auto-mapper between entities (DB) and DTOs (CSharp Model)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // scan the assembly for AutoMapper profiles

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();