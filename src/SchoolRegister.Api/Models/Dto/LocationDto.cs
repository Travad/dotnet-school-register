namespace SchoolRegister.Api.Models.Dto;

public sealed record LocationDto
{
    public Guid Id { get; set; }
    public string Country { get; set; } = default!;
    
    // // US-based
    // public string? State { get; set; }
    // // IT-based
    // public string? Region { get; set; }
    // public string? Province { get; set; }
    // // CH-based
    // public string? Canton { get; set; }

    public string City { get; set; } = default!;
    public string Cap { get; set; } = default!;
    public string Address1 { get; set; } = default!;
    
    // public string? Address2 { get; set; }
    // public string? Address3 { get; set; }
}