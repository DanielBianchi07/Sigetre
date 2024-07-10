using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.ProgramContent;

public class UpdateProgramContentRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Subject { get; set; } = String.Empty;
    public int? Workload { get; set; }
    [Required]
    public long CourseId { get; set; }
}