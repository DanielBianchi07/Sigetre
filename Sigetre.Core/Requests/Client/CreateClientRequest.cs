using System.ComponentModel.DataAnnotations;
using Sigetre.Core.Enums;

namespace Sigetre.Core.Requests.Client;

public class CreateClientRequest : NullableRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Ein { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}