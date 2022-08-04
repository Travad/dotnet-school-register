namespace SchoolRegister.API.Models;

public class CourseAttendeeDto
{
    public int CourseId { get; set; }
    public CourseDto Course { get; set; } = new CourseDto();
    public int AttendeeId { get; set; }
    public AttendeeDto Attendee { get; set; } = new AttendeeDto();
    
    public ICollection<GradeDto> Grades { get; set; } =
        new List<GradeDto>();
}