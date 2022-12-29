namespace SchoolRegister.Api.Endpoints.Schools;

public partial class SchoolEndpoints : IEndpoints
{
    private static async Task<IResult> GetSchoolsHandler(
        ISchoolRepository schoolRepository, IMapper mapper, string? searchTerm)
    {
        // If a search term is specified, look for one
        if (searchTerm is not null && !string.IsNullOrWhiteSpace(searchTerm))
            return Results.Ok(mapper.Map<SchoolDto>(await schoolRepository.SearchByNameAsync(searchTerm)));
        
        // Otherwise, return all
        return Results.Ok(
            mapper.Map<IEnumerable<SchoolDto>>(await schoolRepository.GetAllAsync()));
    }

    private static Task CreateSchoolHandler(
        School school, ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        throw new NotImplementedException();
    }

    private static Task PutSchoolHandler(
        Guid guid, School school, ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        throw new NotImplementedException();
    }

    private static Task DeleteSchoolHandler(
        Guid guid, ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        throw new NotImplementedException();
    }
}