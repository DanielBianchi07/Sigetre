using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Company : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    // relationship
    public long AddressId { get; set; }
    public CompanyAddress Address { get; set; } = null!;
    
    public ICollection<CompanyPhone> Telephone { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
}