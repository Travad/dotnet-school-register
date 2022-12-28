namespace SchoolRegister.API.Models;

public class AttendeeDto
{
    public int Id { get; set; }
    public DateTime StartingDay { get; set; }
    public DateTime EndingDay { get; set; }

    public StudentDto Student { get; set; }

    public ICollection<CourseAttendeeDto> CourseAttendees { get; set; } =
        new List<CourseAttendeeDto>();
}