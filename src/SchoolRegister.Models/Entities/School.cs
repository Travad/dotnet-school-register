using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SchoolRegister.Models.Entities;

public sealed record School
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    
    [MaxLength(512)]
    public string? Description { get; set; }
    
    public DateTime? DateOfConstruction { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Please, make sure you entered a valid email address")]
    public string Email { get; set; } = default!;
    
    [Required]
    [Phone(ErrorMessage = "Please, make sure you entered a valid phone number")]
    public string PhoneNumber { get; set; } = default!;

    [ForeignKey(name: nameof(LocationSchoolId))]
    public Location? LocationSchool { get; set; }
    public int? LocationSchoolId { get; set; } 
    
    public ICollection<Course> Courses { get; set; } = new List<Course>();

}