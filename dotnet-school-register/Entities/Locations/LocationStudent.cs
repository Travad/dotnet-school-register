using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace dotnet_school_register.Entities.Locations;

public class LocationStudent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
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
    public string City { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(5)]
    public string Cap { get; set; } = string.Empty;
    
    [Required]
    public string Address1 { get; set; } = string.Empty;
    
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
}