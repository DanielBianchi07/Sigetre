using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.ProgramContent;

public class CreateProgramContentRequest : Request
{
    [Required]
    public string Subject { get; set; } = String.Empty;
    public int? Workload { get; set; }
    [Required]
    public long CourseId { get; set; }
}