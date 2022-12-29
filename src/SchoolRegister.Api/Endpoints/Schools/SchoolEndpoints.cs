namespace SchoolRegister.Api.Endpoints.Schools;

public partial class SchoolEndpoints : IEndpoints
{
    private const string BaseRoute = "school";
    private const string Tag = "School";
    private const string ContentType = "application/json";
    
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute, GetSchoolsHandler)
            .WithName("GetSchools")
            .WithTags(Tag)
            .Produces<IEnumerable<School>>(200)
            .AllowAnonymous();
    }
    
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISchoolRepository, SchoolRepository>();
    }
}