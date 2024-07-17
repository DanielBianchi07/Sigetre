using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Client;

public class CreateClientRequest : Request
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Ein { get; set; } = String.Empty;
    [Required]
    public string Email { get; set; } = String.Empty;
    
    public new long? ClientId { get; set; }
}