namespace Sigetre.Core.Models;

public class Specialization : BaseClass
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    // relationship
    public ICollection<Instructor> Instructors { get; set; } = null!;
}