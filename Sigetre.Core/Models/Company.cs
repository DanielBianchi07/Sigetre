using System.Text.Json.Serialization;
using Sigetre.Core.Enums;
using Sigetre.Core.Models.Birrelational;

namespace Sigetre.Core.Models;

public class Company : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ein { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    
    // relationship
    public Address Address { get; set; } = null!;
    [JsonIgnore]
    public ICollection<Phone> Telephones { get; set; } = new List<Phone>();
    [JsonIgnore]
    public ICollection<Student> Students { get; set; } = new List<Student>();
}