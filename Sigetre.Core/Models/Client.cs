using Sigetre.Core.Enums;
using Sigetre.Core.Models.Birrelational;

namespace Sigetre.Core.Models;

public class Client
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ein { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }
    
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
    
    // relationship
    public Address Address { get; set; } = null!;
    public ICollection<Phone> Telephones { get; set; } = null!;
}