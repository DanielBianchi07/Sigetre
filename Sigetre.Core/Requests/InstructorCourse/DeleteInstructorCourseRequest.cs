using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.InstructorCourse;

public class DeleteInstructorCourseRequest : Request
{
    [Required]
    public long InstructorId { get; set; }
    [Required]
    public long CourseId { get; set; }
}