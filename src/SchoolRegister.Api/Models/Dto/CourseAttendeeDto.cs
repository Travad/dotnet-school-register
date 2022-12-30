using SchoolRegister.Api.Models.Dto.School;

namespace SchoolRegister.Api.Models.Dto;

public class CourseAttendeeDto
{
    public int CourseId { get; set; }
    public SchoolCoursesDto SchoolCourses { get; set; } = new SchoolCoursesDto();
    public int AttendeeId { get; set; }
    public AttendeeDto Attendee { get; set; } = new AttendeeDto();
    
    public ICollection<GradeDto> Grades { get; set; } =
        new List<GradeDto>();
}