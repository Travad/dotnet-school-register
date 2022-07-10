using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_school_register.Entities.CourseAttendees;
using dotnet_school_register.Entities.Schools;

namespace dotnet_school_register.Entities.Courses;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;
    
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = String.Empty;
    
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }

    [ForeignKey(nameof(SchoolId))]
    public School? School { get; set; }
    public int SchoolId { get; set; }
    
    public ICollection<CourseAttendee> CourseAttendees { get; set; } =
        new List<CourseAttendee>();
}