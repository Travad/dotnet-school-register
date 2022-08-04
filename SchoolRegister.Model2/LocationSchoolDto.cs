namespace SchoolRegister.Model;

public class LocationSchoolDto
{
    public int Id { get; set; }
    public string Country { get; set; } = string.Empty;
    
    // US-based
    public string? State { get; set; }
    // IT-based
    public string? Region { get; set; }
    public string? Province { get; set; }
    // CH-based
    public string? Canton { get; set; }

    public string City { get; set; } = string.Empty;
    public string Cap { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
}