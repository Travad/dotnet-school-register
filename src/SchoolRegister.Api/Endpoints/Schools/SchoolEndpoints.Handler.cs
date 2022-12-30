using FluentValidation.Results;
using SchoolRegister.Api.Data.Repositories;
using SchoolRegister.Api.Models.Dto.School;

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

    private static async Task<IResult> GetSchoolById(int schoolId, 
        ISchoolRepository schoolRepository, IMapper mapper, ILogger<Program> logger)
    {
        var school = await schoolRepository.GetSchoolByIdAsync(schoolId);
        return school is not null ? 
            Results.Ok(mapper.Map<SchoolDto>(school)) : 
            Results.NotFound();
    }

    private static async Task<IResult> CreateSchoolHandler(
        School school, ISchoolRepository schoolRepository, IValidator<School> validator,
        ILogger<Program> logger)
    {
        
        var validatorResult = await validator.ValidateAsync(school);
        if (!validatorResult.IsValid)
        {
            return Results.BadRequest(validatorResult.Errors);
        }

        var createdBook = await schoolRepository.CreateAsync(school);
        if (!createdBook)
        {
            logger.LogError($"School with name {school.Id} was NOT created");
            return Results.BadRequest(new List<ValidationFailure>()
            {
                new("Id", "A school with this Id already exists")
            });
        }
        
        logger.LogTrace($"School with Name {school.Name} was created successfully");
        return Results.CreatedAtRoute("GetBook", new { id = school.Id }, school);

    }

    private static Task PutSchoolHandler(
        int schoolId, School school, 
        ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        throw new NotImplementedException();
    }

    private static Task DeleteSchoolHandler(
        int schoolId, 
        ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        throw new NotImplementedException();
    }
}