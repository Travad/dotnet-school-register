namespace SchoolRegister.Api.Models.Dto.School;

public class SchoolCoursesDto
{
    // public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int TotalCourseAttendees { get; set; }
}