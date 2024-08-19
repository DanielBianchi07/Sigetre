using Sigetre.Core.Enums;

namespace Sigetre.Core;

public abstract class BaseClass
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }

    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }

    public string User { get; set; } = string.Empty;
}