using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests.Alternative;

public class CreateAlternativeRequest : Request
{
    [Required]
    public string Content { get; set; } = String.Empty;
    [Required]
    public EAnswer Answer { get; set; }
    // relationship
    [Required]
    public long QuestionId { get; set; }
}