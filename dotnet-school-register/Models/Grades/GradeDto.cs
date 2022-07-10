using dotnet_school_register.Models.CourseAttendees;
using dotnet_school_register.Models.Courses;
using dotnet_school_register.Models.Students;

namespace dotnet_school_register.Models.Grades;

public class GradeDto
{
    public int Id { get; set; }
    public DateTimeOffset RegistrationTime { get; set; }
    public GradeType VoteType { get; set; }
    public double Grade { get; set; }
    
    public CourseAttendeeDto CourseAttendee { get; set; }
}

public enum GradeType
{
    Oral,
    Written,
    Exam
}