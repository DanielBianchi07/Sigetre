using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Test;

public class GetTestByCourseRequest : PagedRequest
{
    [Required]
    public long CourseId { get; set; }
}