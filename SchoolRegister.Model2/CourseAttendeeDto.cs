namespace SchoolRegister.Model;

public class CourseAttendeeDto
{
    public int CourseId { get; set; }
    public CourseDto Course { get; set; }
    public int AttendeeId { get; set; }
    public AttendeeDto Attendee { get; set; }
}