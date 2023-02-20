using FluentValidation.Results;
using SchoolRegister.Api.Entities;
using SchoolRegister.Api.Models.Dto.School;

namespace SchoolRegister.Api.Endpoints.Schools;

public partial class SchoolEndpoints
{
    private static async Task<IResult> GetSchoolsHandler(
        ISchoolRepository schoolRepository, IMapper mapper, string? searchTerm)
    {
        // If a search term is specified, look for one
        if (searchTerm is not null && !string.IsNullOrWhiteSpace(searchTerm))
            return Results.Ok(mapper.Map<IEnumerable<SchoolDto>>(await schoolRepository.SearchByNameAsync(searchTerm)));
        
        // Otherwise, return all
        return Results.Ok(
            mapper.Map<IEnumerable<SchoolDto>>(await schoolRepository.GetAllAsync()));
    }

    private static async Task<IResult> GetSchoolByIdHandler(int schoolId, 
        ISchoolRepository schoolRepository, IMapper mapper, ILogger<Program> logger)
    {
        var school = await schoolRepository.GetSchoolByIdAsync(schoolId);
        return school is not null ? 
            Results.Ok(mapper.Map<SchoolDto>(school)) : 
            Results.NotFound();
    }

    private static async Task<IResult> CreateSchoolHandler(
        School school, 
        ISchoolRepository schoolRepository, IValidator<School> validator, ILogger<Program> logger)
    {
        
        var validatorResult = await validator.ValidateAsync(school);
        if (!validatorResult.IsValid)
        {
            return Results.BadRequest(validatorResult.Errors);
        }

        var existingSchool = await schoolRepository.GetSchoolByIdAsync(school.Id);
        if (existingSchool is not null)
            return Results.Conflict(new List<ValidationFailure>()
            {
                new("Id", $"The resource with Id {school.Id} already exists!")
            });

        var createdSchool = await schoolRepository.CreateAsync(school);
        if (!createdSchool)
        {
            logger.LogError($"School with name {school.Id} was NOT created");
            return Results.BadRequest(new List<ValidationFailure>()
            {
                new("Id", $"There was an error creating this resource with Id: {school.Id}")
            });
        }
        
        logger.LogTrace($"School with Name {school.Name} was created successfully");
        return Results.CreatedAtRoute(
            "GetSchool", 
            new { schoolId = school.Id }, 
            school);

    }

    private static async Task<IResult> PutSchoolHandler(
        School school, 
        ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        var validatorResult = await validator.ValidateAsync(school);
        if (!validatorResult.IsValid)
            return Results.BadRequest(validatorResult.Errors);

        var schoolUpdated = await schoolRepository.UpdateAsync(school);
        return schoolUpdated ? Results.Ok(school) : Results.NotFound();
    }

    private static async Task<IResult> DeleteSchoolHandler(
        int schoolId, 
        ISchoolRepository schoolRepository, IValidator<School> validator)
    {
        var schoolToDelete = await schoolRepository.GetSchoolByIdAsync(schoolId);
        if (schoolToDelete is null)
            return Results.NotFound();
        
        var delete = await schoolRepository.DeleteAsync(schoolToDelete);
        return delete ? Results.NoContent() : Results.NotFound();
    }
}