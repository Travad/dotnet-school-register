using SchoolRegister.Api.Models.Dto.School;

namespace SchoolRegister.Api.Models.Dto;

public class StudentDto
{
    /* Properties */
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = String.Empty;
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public string Email { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    
    public LocationDto? BirthPlace { get; set; }
    public ICollection<AttendeeDto> Attendees { get; set; } = 
        new List<AttendeeDto>();
    public int TotalNumberOfCoursesTakenByStudent => Attendees.Count;

    /* Methods */
    public string FullName => 
        string.IsNullOrWhiteSpace(MiddleName) 
            ? $"{FirstName} {MiddleName} {LastName}" 
            : $"{FirstName} {LastName}";
}