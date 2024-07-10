using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.ProgramContent;

public class GetProgramContentByCourseRequest : PagedRequest
{
    [Required]
    public long CourseId { get; set; }
}