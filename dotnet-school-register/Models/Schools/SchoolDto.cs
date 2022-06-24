using dotnet_school_register.Models.Courses;
using dotnet_school_register.Models.Locations;

namespace dotnet_school_register.Models.Schools;

public class SchoolDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; } = String.Empty;
    public int YearOfConstruction { get; set; }

    public string Email { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;

    public LocationSchoolDto LocationSchoolDto { get; set; } = new LocationSchoolDto();
    public ICollection<CourseDto> Courses = new List<CourseDto>();
}