using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests.Alternative;

public class UpdateAlternativeRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Content { get; set; } = String.Empty;
    [Required]
    public EAnswer Answer { get; set; }

    [Required] public long QuestionId { get; set; }
}