using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Course;

public class GetCourseByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}