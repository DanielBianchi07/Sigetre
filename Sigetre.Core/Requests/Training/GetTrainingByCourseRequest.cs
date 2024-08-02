using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Training;

public class GetTrainingByCourseRequest : PagedRequest
{
    [Required] public long CourseId { get; set; }
}