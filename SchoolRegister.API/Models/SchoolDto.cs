namespace SchoolRegister.API.Models;

public class SchoolDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    public DateTime? DateOfConstruction { get; set; }

    public string Email { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;

    public LocationSchoolDto? LocationSchoolDto { get; set; } = new LocationSchoolDto();
    public ICollection<CourseDto> Courses = new List<CourseDto>();
}