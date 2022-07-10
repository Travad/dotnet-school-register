using dotnet_school_register.Models.CourseAttendees;
using dotnet_school_register.Models.Courses;
using dotnet_school_register.Models.Students;

namespace dotnet_school_register.Models.Grades;

public class GradeDto
{
    public int Id { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public double Mark { get; set; }

    public CourseAttendeeDto CourseAttendee { get; set; }
}