using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using dotnet_school_register.Entities.Locations;

namespace dotnet_school_register.Entities.Students;

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

    public ICollection<Attendee> Attendees = new List<Attendee>();
    
}

public class Attendee
{
}