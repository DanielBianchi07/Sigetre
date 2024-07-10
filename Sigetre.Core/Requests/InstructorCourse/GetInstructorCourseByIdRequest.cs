using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.InstructorCourse;

public class GetInstructorCourseByIdRequest : Request
{
    [Required]
    public long InstructorId { get; set; }
    [Required]
    public long CourseId { get; set; }
}