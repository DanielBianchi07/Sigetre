using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Course;

public class DeleteCourseRequest : Request
{
    [Required]
    public long Id { get; set; }
}