namespace SchoolRegister.Api.Models.Dto;

public class GradeDto
{
    public int Id { get; set; }
    public DateTime RegistrationTime { get; set; }
    // public GradeType VoteType { get; set; }
    public double GradeMark { get; set; }
    
    public CourseAttendeeDto? CourseAttendee { get; set; }
}

public enum GradeType
{
    Oral,
    Written,
    Exam
}