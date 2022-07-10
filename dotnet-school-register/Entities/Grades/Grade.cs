using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_school_register.Models.CourseAttendees;

namespace dotnet_school_register.Entities.Grades;

public class Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public DateTimeOffset DateTime { get; set; }
    
    [Required]
    [Range(0.0, 10.0, ErrorMessage = "Please, insert a valid grade between 0 and 10")]
    public double Mark { get; set; }

    [ForeignKey(nameof(CourseAttendeeId))]
    public CourseAttendee? CourseAttendee { get; set; }
    public int CourseAttendeeId { get; set; }

}

public class CourseAttendee
{
}