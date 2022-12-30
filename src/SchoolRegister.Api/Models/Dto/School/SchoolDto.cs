namespace SchoolRegister.Api.Models.Dto.School;

public sealed record SchoolDto
{
    // public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime? DateOfConstruction { get; set; }

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public LocationDto? LocationSchool { get; set; }
    
    public ICollection<SchoolCoursesDto> Courses { get; set; } = new List<SchoolCoursesDto>();
    public int TotalNumberOfCoursesOffered { get; set; }

}