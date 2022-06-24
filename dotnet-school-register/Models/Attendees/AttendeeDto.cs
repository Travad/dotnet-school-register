using dotnet_school_register.Models.Schools;
using dotnet_school_register.Models.Students;
using dotnet_school_register.Models.CourseAttendees;

namespace dotnet_school_register.Models.Attendee;

public class AttendeeDto
{
    public int Id { get; set; }
    public DateTimeOffset StartingDay { get; set; }
    public DateTimeOffset EndingDay { get; set; }
    
    public StudentDto Student { get; set; }

    public ICollection<CourseAttendee> CourseAttendees { get; set; } =
        new List<CourseAttendee>();
}