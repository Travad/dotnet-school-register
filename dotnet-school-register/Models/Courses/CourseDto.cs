using dotnet_school_register.Models.Attendee;
using dotnet_school_register.Models.CourseAttendees;
using dotnet_school_register.Models.Schools;
using dotnet_school_register.Models.Students;

namespace dotnet_school_register.Models.Courses;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTimeOffset YearOfTeaching { get; set; }

    public SchoolDto School { get; set; }

    public ICollection<CourseAttendeeDto> CourseAttendees { get; set; } =
        new List<CourseAttendeeDto>();
}