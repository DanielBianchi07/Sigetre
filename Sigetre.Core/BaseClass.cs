using Sigetre.Core.Enums;

namespace Sigetre.Core;

public abstract class BaseClass
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }
    
    public long ClientId { get; set; }
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
}