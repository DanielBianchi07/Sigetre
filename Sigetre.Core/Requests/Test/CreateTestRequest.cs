using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Test;

public class CreateTestRequest : Request
{
    [Required]
    public string Title { get; set; } = String.Empty;
    // relationship
    [Required]
    public long CourseId { get; set; }
}