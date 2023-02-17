using Microsoft.Extensions.Logging.Console;
using SchoolRegister.Api.Extensions.Endpoints;

namespace SchoolRegister.Api.Extensions.Application;

internal static class WebApplicationExtensions
{
    internal static WebApplication UseSchoolRegisterServices(
        this WebApplication app)
    {
        // Register console logging
        app.Services.GetService<ILoggerFactory>()!.CreateLogger<ConsoleLoggerProvider>();

        // Register documentation (swagger) usage
        app.UseSwagger();
        app.UseSwaggerUI();
        
        // Register usage of endpoints across the entire program
        app.UseEndpoints<Program>();

        return app;
    }
}