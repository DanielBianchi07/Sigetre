using System.Text.Json.Serialization;

namespace Sigetre.Core.Models;

public class Student : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ssn { get; set; } = string.Empty;
    public string Ic { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public Byte[]? Signature { get; set; }
    // relationship
    [JsonIgnore]
    public ICollection<Company> Companies { get; set; } = new List<Company>();
    [JsonIgnore]
    public ICollection<Training> Trainings { get; set; } = new List<Training>();
}