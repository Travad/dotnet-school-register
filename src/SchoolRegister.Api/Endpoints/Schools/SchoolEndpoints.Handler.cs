namespace SchoolRegister.Api.Endpoints.Schools;

public partial class SchoolEndpoints : IEndpoints
{
    private static async Task<IResult> GetSchoolsHandler(
        ISchoolRepository schoolRepository, string? searchTerm)
    {
        if (searchTerm is not null && !string.IsNullOrWhiteSpace(searchTerm))
            return Results.Ok(await schoolRepository.SearchByNameAsync(searchTerm));

        return Results.Ok(await schoolRepository.GetAllAsync());
    }

}