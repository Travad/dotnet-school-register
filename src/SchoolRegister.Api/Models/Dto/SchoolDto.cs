namespace SchoolRegister.Api.Models.Dto;

public sealed record SchoolDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime? DateOfConstruction { get; set; }

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public LocationDto? LocationSchoolDto { get; set; } = default!;
    
    public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
    public int TotalNumberOfCoursesOffered => Courses.Count;

}