using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.Identity;

public class RegisterRequest : Request
{
    [Required]
    [MaxLength(length: 160)]
    public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}