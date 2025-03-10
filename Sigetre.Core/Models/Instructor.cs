using System.Text.Json.Serialization;

namespace Sigetre.Core.Models;

public class Instructor : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Ssn { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Registry { get; set; } = String.Empty;
    public string Telephone { get; set; } = String.Empty;
    public Byte[]? Signature { get; set; }
    // relationship
    [JsonIgnore]
    public ICollection<Training> Trainings { get; set; } = new List<Training>();
    public long SpecializationId { get; set; }
    public Specialization Specialization { get; set; } = null!;
}