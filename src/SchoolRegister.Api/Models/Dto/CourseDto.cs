namespace SchoolRegister.Api.Models.Dto;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // public SchoolDto School { get; set; } = default!;

    public ICollection<CourseAttendeeDto> CourseAttendees { get; set; } =
        new List<CourseAttendeeDto>();

    public int TotalCourseAttendees => CourseAttendees.Count;
}