namespace Sigetre.Core.Models;

public class ProgramContent : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Subject { get; set; } = String.Empty;
    public int? Workload { get; set; }
    // relationship
    public long CourseId { get; set; }
    public Course Course { get; set; } = null!;
}