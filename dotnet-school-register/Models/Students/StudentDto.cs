using dotnet_school_register.Models.Attendee;
using dotnet_school_register.Models.Locations;

namespace dotnet_school_register.Models.Students;

public class StudentDto
{
    /* Properties */
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? MiddleName { get; set; }
    public string Surname { get; set; } = String.Empty;
    public int DayOfBirth { get; set; }
    public int MonthOfBirth { get; set; }
    public int YearOfBirth { get; set; }
    public string Email { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    
    public LocationStudentDto? Birthplace { get; set; }
    public ICollection<AttendeeDto> Attendees { get; set; }

    /* Methods */
    public string FullName => 
        !string.IsNullOrWhiteSpace(MiddleName) 
            ? $"{Name} {MiddleName} {Surname}" 
            : $"{Name} {Surname}";
}