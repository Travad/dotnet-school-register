using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.API.Entities;

public class LocationSchool
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
    
    // US-based
    public string? State { get; set; }
    // IT-based
    public string? Region { get; set; }
    public string? Province { get; set; }
    // CH-based
    public string? Canton { get; set; }

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(5)]
    public string Cap { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string Address1 { get; set; } = string.Empty;
    
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
}