namespace SchoolRegister.Model;

public class AttendeeDto
{
    public Guid Id { get; set; }
    public DateTimeOffset StartingDay { get; set; }
    public DateTimeOffset EndingDay { get; set; }
    
    public StudentDto Student { get; set; }

    public ICollection<CourseAttendeeDto> CourseAttendees { get; set; } =
        new List<CourseAttendeeDto>();
}