namespace SchoolRegister.Api.Models.Dto;

public class CourseAttendeeDto
{
    public Guid CourseId { get; set; }
    public CourseDto Course { get; set; } = new CourseDto();
    public Guid AttendeeId { get; set; }
    public AttendeeDto Attendee { get; set; } = new AttendeeDto();
    
    public ICollection<GradeDto> Grades { get; set; } =
        new List<GradeDto>();
}