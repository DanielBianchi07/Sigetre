using System.Text.Json.Serialization;

namespace Sigetre.Core.Models;

public class Specialization : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    // relationship
    [JsonIgnore]
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}