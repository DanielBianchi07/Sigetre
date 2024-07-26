using System.Text.Json.Serialization;

namespace Sigetre.Core.Models;

public class Question : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Content { get; set; } = String.Empty;
    public long? CorrectAnswer { get; set; }
    // relationship
    public long CourseId { get; set; }
    public Course Course { get; set; } = null!;
    [JsonIgnore]
    public ICollection<Test> Tests { get; set; } = new List<Test>();
    [JsonIgnore]
    public ICollection<Alternative> Alternatives { get; set; } = new List<Alternative>();
}