using Sigetre.Core.Enums;

namespace Sigetre.Core.Models;

public class Training : BaseClass
{
    // fields
    public long Id { get; set; }
    public ETrainingType Type { get; set; }
    public ETrainingSituation Situation { get; set; }
    // relationship
    public long CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
    public ICollection<Instructor> Instructors { get; set; } = null!;

    public ICollection<Certificate> Certificates { get; set; } = null!;
    public ICollection<AttendanceList> AttendanceLists { get; set; } = null!;
}