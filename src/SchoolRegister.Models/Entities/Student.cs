using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Models.Entities;

public sealed record Student
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

    [ForeignKey(nameof(BirthPlaceId))] 
    public Location? BirthPlace { get; set; }
    public int? BirthPlaceId { get; set; }

    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
    
}