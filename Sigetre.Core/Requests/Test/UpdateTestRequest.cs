using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Test;

public class UpdateTestRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Title { get; set; } = String.Empty;
    // relationship
    [Required]
    public long CourseId { get; set; }
}