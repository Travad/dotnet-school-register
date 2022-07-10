using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_school_register.Entities.Attendees;
using dotnet_school_register.Entities.Courses;
using dotnet_school_register.Entities.Grades;

namespace dotnet_school_register.Entities.CourseAttendees;

public class CourseAttendee
{   
    [ForeignKey(nameof(CourseId))]
    public Course? Course { get; set; }
    public int CourseId { get; set; }
    
    [ForeignKey(nameof(AttendeeId))]
    public Attendee? Attendee { get; set; }
    public int AttendeeId { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
