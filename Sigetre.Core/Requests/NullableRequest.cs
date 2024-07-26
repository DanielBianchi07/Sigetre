using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests;

public abstract class NullableRequest
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [Required]
    public EStatus Status { get; set; }
    public long? ClientId { get; set; }
    [Required]

    public string User = string.Empty;
    public string CreateBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
}