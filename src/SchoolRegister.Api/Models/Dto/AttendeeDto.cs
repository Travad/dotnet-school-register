namespace SchoolRegister.Api.Models.Dto;

public class AttendeeDto
{
    public Guid Id { get; set; }
    public DateTime StartingDay { get; set; }
    public DateTime EndingDay { get; set; }

    public StudentDto Student { get; set; } = default!;

    public ICollection<CourseAttendeeDto> CourseAttendees { get; set; } =
        new List<CourseAttendeeDto>();
}