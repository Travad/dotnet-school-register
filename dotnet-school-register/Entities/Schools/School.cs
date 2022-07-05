using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_school_register.Entities.Locations;

namespace dotnet_school_register.Entities.Schools;

public class School
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;
    
    [MaxLength(512)]
    public string? Description { get; set; }
    
    public DateTime? DateOfConstruction { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Please, make sure you entered a valid email address")]
    public string Email { get; set; } = String.Empty;
    
    [Required]
    [Phone(ErrorMessage = "Please, make sure you entered a valid phone number")]
    public string PhoneNumber { get; set; } = String.Empty;

    [ForeignKey(name: nameof(LocationSchoolId))]
    public LocationSchool? LocationSchool { get; set; }
    public int LocationSchoolId { get; set; } 
    
    public ICollection<Course> Courses = new List<Course>();
}

public class Course
{
}