namespace Sigetre.Core.Models;

public class Test : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Title { get; set; } = String.Empty;
    // relationship
    public long CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = null!;
}