using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

namespace SchoolRegister.Api.Extensions.Application;

internal static class WebApplicationBuilderExtensions
{
    internal static WebApplicationBuilder AddSchoolRegisterServices(
        this WebApplicationBuilder builder)
    {
        // Check validity of the WebApplicationBuilder
        ArgumentNullException.ThrowIfNull(builder);
        
        // Enable CORS policies between SchoolRegister API and application
        // TODO: Update once the Blazor app is in place
        var webClientPort = builder.Configuration["WebClientPort"];
        var webClientOrigin = builder.Configuration["WebClientOrigin"];
        
        ArgumentException.ThrowIfNullOrEmpty(webClientOrigin);
        ArgumentException.ThrowIfNullOrEmpty(webClientPort);

        builder.Services.AddCors(
            options =>
                options.AddDefaultPolicy(policy =>
                    policy.WithOrigins(webClientOrigin, $"https://localhost:{webClientPort}")
                        .AllowAnyHeader()
                        .AllowAnyHeader()
                        .AllowCredentials()));
        
        // Handle circular references in System.Text.Json 
        // More info: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/preserve-references?pivots=dotnet-6-0
        builder.Services.Configure<JsonOptions>(options =>
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
   
        // Adding swagger and explorer (metadata information)
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Adding the fluent validation for database entities
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        
        // Adding the database context
        builder.Services.AddDbContext<SchoolRegisterDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
            // options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQL")));
            
        // Auto-mapper between entities (DB) and DTOs (CSharp Model)
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // scan the assembly for AutoMapper profiles

        // Adding all the required services for the endpoints dynamically (using reflection)
        builder.Services.AddEndpoints<Program>(builder.Configuration);

        return builder;
    }
}