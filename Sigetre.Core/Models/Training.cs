using System.Text.Json.Serialization;
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
    
    [JsonIgnore]
    public ICollection<Student> Students { get; set; } = new List<Student>();
    [JsonIgnore]
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    [JsonIgnore]
    public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    [JsonIgnore]
    public ICollection<AttendanceList> AttendanceLists { get; set; } = new List<AttendanceList>();
}