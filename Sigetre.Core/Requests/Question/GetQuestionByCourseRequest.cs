using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Question;

public class GetQuestionByCourseRequest : PagedRequest
{
    [Required]
    public long CourseId { get; set; }
}