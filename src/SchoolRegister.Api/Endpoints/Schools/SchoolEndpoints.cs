using FluentValidation.Results;

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
            .Produces<IEnumerable<School>>(200)
            .AllowAnonymous()
            .WithTags(Tag);
        
        app.MapGet($"{BaseRoute}/{{schoolId}}", GetSchoolByIdHandler)
            .WithName("GetSchool")
            .Produces(200)
            .Produces(404)
            .AllowAnonymous()
            .WithTags(Tag);
        
        app.MapPost(BaseRoute, CreateSchoolHandler)
            .WithName("PostSchool")
            .Accepts<School>(ContentType)
            .Produces<School>(201).Produces(409)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags(Tag);
        
        app.MapPut($"{BaseRoute}", PutSchoolHandler)
            .WithName("PutSchool")
            .Accepts<School>(ContentType)
            .Produces<School>(200)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags(Tag);

        app.MapDelete($"{BaseRoute}/{{schoolId}}", DeleteSchoolHandler)
            .WithName("DeleteSchool")
            .Produces(204)
            .Produces(404)
            .WithTags(Tag);
    }
    
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISchoolRepository, SchoolRepository>();
    }
}