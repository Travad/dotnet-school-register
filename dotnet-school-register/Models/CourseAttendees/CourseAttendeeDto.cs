using dotnet_school_register.Models.Attendee;
using dotnet_school_register.Models.Courses;

namespace dotnet_school_register.Models.CourseAttendees;

public class CourseAttendeeDto
{
    public int CourseId { get; set; }
    public CourseDto Course { get; set; }
    public int AttendeeId { get; set; }
    public AttendeeDto Attendee { get; set; }
}