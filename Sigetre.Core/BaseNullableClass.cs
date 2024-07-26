using Sigetre.Core.Enums;

namespace Sigetre.Core;

public abstract class BaseNullableClass
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }

    public long? ClientId { get; set; }
    public long? CompanyId { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
}