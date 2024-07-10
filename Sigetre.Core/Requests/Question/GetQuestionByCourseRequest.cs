using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Question;

public class GetQuestionByCourseRequest : Request
{
    [Required]
    public long CourseId { get; set; }
}