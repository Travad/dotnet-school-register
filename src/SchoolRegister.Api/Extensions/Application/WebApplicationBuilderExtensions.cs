namespace SchoolRegister.Api.Extensions;

internal static class WebApplicationBuilderExtensions
{
    internal static WebApplicationBuilder AddSchoolRegisterEndpoints(
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


        // builder.Services.AddEndpoints<Program>(builder.Configuration);
        
        
        return builder;
    }
}