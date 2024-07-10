using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Company : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    // relationship
    public long CompanyAddressId { get; set; }
    public Addresses CompanyAddress { get; set; } = null!;
    
    public ICollection<CompanyPhone> Telephone { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
}