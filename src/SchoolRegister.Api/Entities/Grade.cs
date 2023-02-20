using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Api.Entities;

public sealed record Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public DateTime RegistrationTime { get; set; }
    
    [Required]
    [Range(0.0, 10.0, ErrorMessage = "Please, insert a valid grade between 0 and 10")]
    public double GradeMark { get; set; }
    
    [Required]
    public GradeType GradeType { get; set; }
    
    public CourseAttendee? CourseAttendee { get; set; }
    public int? CourseId { get; set; }
    public int? AttendeeId { get; set; }

}

public enum GradeType
{
    Oral,
    Written,
    Exam
}

