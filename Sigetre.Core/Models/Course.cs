namespace Sigetre.Core.Models;

public class Course : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int? InitialWorkload { get; set; }
    public int? PeriodicWorkload { get; set; }
    public int? Validity { get; set; }
    public Byte[]? Logo { get; set; }
    public long SpecializationId { get; set; }
    // relationship
    public ICollection<Training> Trainings { get; set; } = null!;
    public ICollection<ProgramContent> ProgramContents { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = null!;

}