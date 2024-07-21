using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests.Client;

public class CreateClientRequest
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Ein { get; set; } = String.Empty;
    [Required]
    public string Email { get; set; } = String.Empty;
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [Required]
    public EStatus Status { get; set; }
    public long CreateBy { get; set; }
    public long? UpdatedBy { get; set; }
}