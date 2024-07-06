namespace Sigetre.Core.Models;

public class Question : BaseClass
{
    // fields
    public long Id { get; set; }
    public string Content { get; set; } = String.Empty;
    public long? CorrectAnswer { get; set; }
    // relationship
    public ICollection<Course> Courses { get; set; } = null!;
    public ICollection<Test> Tests { get; set; } = null!;
    public ICollection<Alternative> Alternatives { get; set; } = null!;
}