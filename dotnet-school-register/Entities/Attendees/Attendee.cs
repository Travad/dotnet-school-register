using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_school_register.Entities.CourseAttendees;
using dotnet_school_register.Entities.Students;

namespace dotnet_school_register.Entities.Attendees;

public class Attendee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    // [Required]
    // public AttendeeType Type { get; set; }
    
    [Required]
    public DateTime StartDay { get; set; }
    
    [Required]
    public DateTime EndDay { get; set; }
    
    [ForeignKey(nameof(StudentId))]
    public Student? Student { get; set; }
    public int StudentId { get; set; }

    public ICollection<CourseAttendee> CourseAttendees { get; set; } =
        new List<CourseAttendee>();
}

public enum AttendeeType
{
    RemoteOnly,
    PhysicalOnly,
    RemoteAndPhysical
}