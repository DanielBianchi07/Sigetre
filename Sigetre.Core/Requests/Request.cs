using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests;

public abstract class Request
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [Required]
    public EStatus Status { get; set; }
    public long ClientId { get; set; }
    public long CreateBy { get; set; }
    public long? UpdatedBy { get; set; }
}