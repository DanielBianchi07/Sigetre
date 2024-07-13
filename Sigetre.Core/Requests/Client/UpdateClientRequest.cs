using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Client;

public class UpdateClientRequest : Request
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Ein { get; set; } = String.Empty;
    [Required]
    public string Email { get; set; } = String.Empty;
    [Required]
    public long ClientAddressId { get; set; }
}