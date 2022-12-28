using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.API.Entities;

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
