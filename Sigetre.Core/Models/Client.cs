using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Client : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    // relationship
    public long ClientAddressId { get; set; }
    public Addresses ClientAddress { get; set; } = null!;
    
    public ICollection<CompanyPhone> Telephone { get; set; } = null!;
}