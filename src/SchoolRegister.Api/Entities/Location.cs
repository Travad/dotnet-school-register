using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Api.Entities;

public sealed record Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MinLength(4), MaxLength(56)]
    public string Country { get; set; } = default!;
    
    // US-based
    public string? State { get; set; }
    // IT-based
    public string? Region { get; set; }
    public string? Province { get; set; }
    // CH-based
    public string? Canton { get; set; }
    
    [Required]
    [MinLength(2), MaxLength(52)]
    public string City { get; set; } = default!;
    
    [Required]
    [StringLength(5, ErrorMessage = "CAP is 5 digits long, e.g. 38046")]
    public string Cap { get; set; } = default!;
    
    [Required]
    [MinLength(2)]
    public string Address1 { get; set; } = default!;
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    
}
