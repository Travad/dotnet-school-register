using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.API.Entities;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = String.Empty;
    
    [MaxLength(50)]
    public string? MiddleName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = String.Empty;
    
    [Required]
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    
    [MaxLength(50)]
    public string? Email { get; set; } = String.Empty;
    
    [MaxLength(50)]
    public string? PhoneNumber { get; set; } = String.Empty;
    
    [ForeignKey("BirthPlaceId")]
    public LocationStudent? BirthPlace { get; set; }
    public int BirthPlaceId { get; set; }

    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
    
}