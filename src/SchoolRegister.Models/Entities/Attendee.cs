using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.API.Entities;

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