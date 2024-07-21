using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Company : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    // relationship
    public Address Address { get; set; } = null!;
    
    public ICollection<Phone> Telephones { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
}