using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.InstructorCourse;

public class CreateInstructorCourseRequest : Request
{
    [Required]
    public long InstructorId { get; set; }
    [Required]
    public long CourseId { get; set; }
    [Required]
    public bool TechnicalManager { get; set; }
}