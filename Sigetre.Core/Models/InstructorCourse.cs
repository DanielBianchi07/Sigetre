namespace Sigetre.Core.Models;

public class InstructorCourse
{
    public long InstructorId { get; set; }
    public Instructor Instructor { get; set; } = null!;
    public long CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public bool TechnicalManager { get; set; }
}