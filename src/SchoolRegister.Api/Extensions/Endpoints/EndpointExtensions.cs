using System.Reflection;

namespace SchoolRegister.Api.Extensions.Endpoints;

internal static class EndpointExtensions
{
    /// <summary>
    /// Add all the required services for each endpoint that implement the IEndpoints interface
    /// </summary>
    /// <param name="services">The DI service collection object (builder.Services)</param>
    /// <param name="configuration">The DI configuration object (builder.Services.Configuration)</param>
    /// <typeparam name="TMarker">The assembly type from where to scan for IEndpoints references</typeparam>
    internal static void AddEndpoints<TMarker>(
        this IServiceCollection services, IConfiguration configuration)
    {
        AddEndpoints(services, typeof(TMarker), configuration);
    }
    
    internal static void AddEndpoints(
        IServiceCollection services, Type typeMarker, IConfiguration configuration)
    {
        // Retrieve all the endpoints implementations across the specified assembly type
        var endpointTypes =
            GetEndpointTypesFromAssemblyContaining(typeMarker);
        
        // Add all the services
        endpointTypes.ToList().ForEach(endpoint => 
            endpoint.GetMethod(nameof(IEndpoints.AddServices))?
                .Invoke(null, new object[]{services, configuration}));
    }
    
    /// <summary>
    /// Map all the defined endpoints implementing the IEndpoints interface across the whole application
    /// </summary>
    /// <param name="app">The running application</param>
    /// <typeparam name="TMarker">The assembly type from where to start scanning the project for IEndpoints implementations</typeparam>
    internal static void UseEndpoints<TMarker>(
        this IApplicationBuilder app)
    {
        UseEndpoints(app, typeof(TMarker));
    }

    private static void UseEndpoints(
        IApplicationBuilder app, Type typeMarker)
    {
        // Retrieve all the endpoints implementations across the specified assembly type
        var endpointTypes =
            GetEndpointTypesFromAssemblyContaining(typeMarker);
        
        // Define all the mapped endpoints through minimal APIs
        endpointTypes.ToList().ForEach(endpoint => 
            endpoint.GetMethod(nameof(IEndpoints.DefineEndpoints))?
                .Invoke(null, new object[]{ app }));
    }

    private static IEnumerable<TypeInfo> GetEndpointTypesFromAssemblyContaining(Type typeMarker)
    {
        return typeMarker.Assembly.DefinedTypes.Where(t =>
            t is { IsAbstract: false, IsInterface: false } && typeof(IEndpoints).IsAssignableFrom(t));
    }
}