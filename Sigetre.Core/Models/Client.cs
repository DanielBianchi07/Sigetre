using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Client
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }
    
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    
    // relationship
    public Address Address { get; set; } = null!;
    public ICollection<Phones> Telephones { get; set; } = null!;
}