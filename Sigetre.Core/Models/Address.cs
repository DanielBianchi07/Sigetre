using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Address
{
    public long Id { get; set; }
    public string ZipCode { get; set; } = String.Empty;
    public string State { get; set; } = String.Empty;
    public string City { get; set; } = String.Empty;
    public string Neighborhood { get; set; } = String.Empty;
    public string StreetName { get; set; } = String.Empty;
    public string Number { get; set; } = String.Empty;
    public string? Complement { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }
    
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }

    
    public long? CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public long? ClientId { get; set; }
    public Client Client { get; set; } = null!;

}